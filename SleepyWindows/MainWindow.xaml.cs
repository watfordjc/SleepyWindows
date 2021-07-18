using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using uk.JohnCook.dotnet.SleepyWindows.Utils;
using Windows.Win32;

namespace uk.JohnCook.dotnet.SleepyWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public unsafe partial class MainWindow : Window
    {
        private Guid currentPowerScheme;
        private void* effectivePowerModeCallback;
        private Windows.Win32.System.Power.DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS deviceNotifySubscribeParameters = new() { Context = null, Callback = OnPowerSettingChanged };
        private readonly IntPtr unmanagedDeviceNotifySubscribeParameters;
        private readonly DeviceNotifyCallbackRoutineSafeHandle deviceNotifyCallbackRoutineSafeHandle;
        private readonly List<KeyValuePair<Guid, IntPtr>> powerNotificationCallbacks = new();
        private readonly List<KeyValuePair<Guid, IntPtr>> powerSettingCallbacks = new();
        private static WeakReference<MainWindow>? weakReference;

        #region Events
        /// <summary>
        /// An event that fires when <see cref="SystemEvents.UserPreferenceChanged"/> fires.
        /// </summary>
        public event EventHandler<UserPreferenceChangedEventArgs>? UserPreferenceChanged;
        /// <summary>
        /// An event that fires when <see cref="SystemEvents.PowerModeChanged"/> fires.
        /// </summary>
        public event EventHandler<PowerModeChangedEventArgs>? PowerModeChanged;
        #endregion

        #region Window and Window Event Handlers

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            unmanagedDeviceNotifySubscribeParameters = Marshal.AllocHGlobal(Marshal.SizeOf(deviceNotifySubscribeParameters));
            Marshal.StructureToPtr(deviceNotifySubscribeParameters, unmanagedDeviceNotifySubscribeParameters, false);
            deviceNotifyCallbackRoutineSafeHandle = new(unmanagedDeviceNotifySubscribeParameters);
            InitializeComponent();
            weakReference = new(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Add event handlers for static system events
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
            SystemEvents.PowerModeChanged += OnPowerModeChanged;
            // Add event handlers for forwarding static system events
            UserPreferenceChanged += OnForwardedUserPreferenceChanged;
            PowerModeChanged += OnForwardedPowerModeChanged;

            // Register for effective power mode change notifications on Windows 10 version 1089 and later
            if (effectivePowerModeCallback == null && OperatingSystem.IsWindowsVersionAtLeast(10, 0, 1089, 0))
            {
                // Registering the callback for changes to effective power mode will also call the callback with the current effective power mode
                _ = PInvoke.PowerRegisterForEffectivePowerModeNotifications(Constants.EFFECTIVE_POWER_MODE_V2, OnEffectivePowerModeChanged, null, out void* newEffectivePowerModeCallback);
                effectivePowerModeCallback = newEffectivePowerModeCallback;
            }
            else
            {
                // Get the current power profile
                GetPowerProfile();
                AddPowerPolicyChangeHandlers();
            }
        }

        /// <summary>
        /// Dipose of unmanaged objects before window is closed.
        /// </summary>
        /// <inheritdoc cref="System.ComponentModel.CancelEventHandler" path="param"/>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (effectivePowerModeCallback != null)
            {
                if (!ErrorUtils.IsSuccess(PInvoke.PowerUnregisterFromEffectivePowerModeNotifications(effectivePowerModeCallback)))
                {
                    Debug.WriteLine("Unable to unregister effective power mode change notification callback.");
                }
                effectivePowerModeCallback = null;
            }
            foreach (KeyValuePair<Guid, IntPtr> callbackHandle in powerNotificationCallbacks)
            {
                if (!ErrorUtils.IsSuccess(PInvoke.PowerSettingUnregisterNotification((Windows.Win32.System.Power.HPOWERNOTIFY)callbackHandle.Value)))
                {
                    Debug.WriteLine($"Unable to unregister power setting change notification callback for GUID {callbackHandle.Value}");
                }
            }
            foreach (KeyValuePair<Guid, IntPtr> callbackHandle in powerSettingCallbacks)
            {
                if (!ErrorUtils.IsSuccess(PInvoke.PowerSettingUnregisterNotification((Windows.Win32.System.Power.HPOWERNOTIFY)callbackHandle.Value)))
                {
                    Debug.WriteLine($"Unable to unregister power setting change notification callback for GUID {callbackHandle.Value}");
                }
            }
            powerSettingCallbacks.Clear();
            Marshal.FreeHGlobal(unmanagedDeviceNotifySubscribeParameters);
            SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
            SystemEvents.PowerModeChanged -= OnPowerModeChanged;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource? hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            hwndSource?.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch ((uint)msg)
            {
                case Constants.WM_POWERBROADCAST:
                    _ = OnPowerSettingChanged(null, (uint)wParam, (void*)lParam);
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        }

        private unsafe void AddPowerPolicyChangeHandlers()
        {
            List<Guid> desiredPowerNotificationSubscriptions = new()
            {
                PowerNotificationGuids.PowerSchemePersonality
            };
            foreach (Guid notificationGuid in desiredPowerNotificationSubscriptions)
            {
                if (ErrorUtils.IsSuccess(PInvoke.PowerSettingRegisterNotification(notificationGuid, Windows.Win32.System.Power.POWER_SETTING_REGISTER_NOTIFICATION_FLAGS.DEVICE_NOTIFY_CALLBACK, deviceNotifyCallbackRoutineSafeHandle, out void* powerNotificationCallbackHandle)))
                {
                    powerNotificationCallbacks.Add(new(notificationGuid, (IntPtr)powerNotificationCallbackHandle));
                    bool knownSetting = KnownGuids.Descriptions.TryGetValue(notificationGuid, out KeyValuePair<Type, string> notificationDescription);
                    Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Power Notification Callback Added: {0}", knownSetting ? notificationDescription.Value : notificationGuid));
                }
            }

            List<Guid> desiredPowerChangeSettingSubscriptions = new()
            {
                PowerSchemeSettingGuids.Display.DisplayIdleTimeout,
                PowerSchemeSettingGuids.Disk.DiskIdleTimeout,
                PowerSchemeSettingGuids.Sleep.StandbyIdleTimeout,
                PowerSchemeSettingGuids.PowerButtonLid.SleepButtonAction,
                PowerSchemeSettingGuids.PowerButtonLid.PowerButtonAction,
                PowerSchemeSettingGuids.PowerButtonLid.LidCloseAction,
                PowerSchemeSettingGuids.Sleep.HibernateIdleTimeout
            };
            List<Guid> currentSchemeSubgroups = new();
            uint index = 0;
            uint bufferSize = 0;
            Debug.WriteLine($"Current Power Scheme GUID: {currentPowerScheme}");
            while ((Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR)PInvoke.PowerEnumerate(null, currentPowerScheme, null, Windows.Win32.System.Power.POWER_DATA_ACCESSOR.ACCESS_SUBGROUP, index, null, ref bufferSize) == Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR.ERROR_MORE_DATA)
            {
                IntPtr buffer = Marshal.AllocHGlobal((int)bufferSize);
                _ = PInvoke.PowerEnumerate(null, currentPowerScheme, null, Windows.Win32.System.Power.POWER_DATA_ACCESSOR.ACCESS_SUBGROUP, index, (byte*)buffer, ref bufferSize);
                byte[] bufferManaged = new byte[bufferSize];
                Marshal.Copy(buffer, bufferManaged, 0, (int)bufferSize);
                Marshal.FreeHGlobal(buffer);
                Guid guid = new(bufferManaged);
                if (!currentSchemeSubgroups.Contains(guid))
                {
                    currentSchemeSubgroups.Add(guid);
                }
                index++;
            }
            List<Guid> currentSchemePowerSettings = new();
            foreach (Guid subgroupGuid in currentSchemeSubgroups)
            {
                bool knownSubgroup = KnownGuids.Descriptions.TryGetValue(subgroupGuid, out KeyValuePair<Type, string> subgroupDescription);
                Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Parsing {0}Power Scheme Sub-Group {1}...", knownSubgroup ? "" : "Unknown ", knownSubgroup ? subgroupDescription.Value : subgroupGuid));
                index = 0;
                while ((Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR)PInvoke.PowerEnumerate(null, currentPowerScheme, subgroupGuid, Windows.Win32.System.Power.POWER_DATA_ACCESSOR.ACCESS_INDIVIDUAL_SETTING, index, null, ref bufferSize) == Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR.ERROR_MORE_DATA)
                {
                    IntPtr buffer = Marshal.AllocHGlobal((int)bufferSize);
                    _ = PInvoke.PowerEnumerate(null, currentPowerScheme, subgroupGuid, Windows.Win32.System.Power.POWER_DATA_ACCESSOR.ACCESS_INDIVIDUAL_SETTING, index, (byte*)buffer, ref bufferSize);
                    byte[] bufferManaged = new byte[bufferSize];
                    Marshal.Copy(buffer, bufferManaged, 0, (int)bufferSize);
                    Marshal.FreeHGlobal(buffer);
                    Guid guid = new(bufferManaged);
                    if (!currentSchemePowerSettings.Contains(guid))
                    {
                        currentSchemePowerSettings.Add(guid);
                    }
                    bool knownSetting = KnownGuids.Descriptions.TryGetValue(guid, out KeyValuePair<Type, string> settingDescription);
                    Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Found Power Setting: {0}/{1}", knownSubgroup ? subgroupDescription.Value : subgroupGuid, knownSetting ? settingDescription.Value : guid));
                    index++;
                }
            }
            foreach (Guid settingGuid in desiredPowerChangeSettingSubscriptions)
            {
                if (currentSchemePowerSettings.Contains(settingGuid) && ErrorUtils.IsSuccess(PInvoke.PowerSettingRegisterNotification(settingGuid, Windows.Win32.System.Power.POWER_SETTING_REGISTER_NOTIFICATION_FLAGS.DEVICE_NOTIFY_CALLBACK, deviceNotifyCallbackRoutineSafeHandle, out void* powerSettingCallbackHandle)))
                {
                    powerSettingCallbacks.Add(new(settingGuid, (IntPtr)powerSettingCallbackHandle));
                    bool knownSetting = KnownGuids.Descriptions.TryGetValue(settingGuid, out KeyValuePair<Type, string> settingDescription);
                    Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Power Setting Change Callback Added: {0}/{1}", knownSetting ? settingDescription.Key.Name : "Unknown", knownSetting ? settingDescription.Value : settingGuid));
                }
            }
        }

        private class DeviceNotifyCallbackRoutineSafeHandle : SafeHandle
        {
            public DeviceNotifyCallbackRoutineSafeHandle() : base(IntPtr.Zero, true)
            {
            }

            public DeviceNotifyCallbackRoutineSafeHandle(IntPtr handle) : base(IntPtr.Zero, true)
            {
                this.handle = handle;
            }

            public override bool IsInvalid => handle == IntPtr.Zero;

            protected override bool ReleaseHandle()
            {
                return true;
            }
        }

        private static uint OnPowerSettingChanged(void* context, uint eventType, void* setting)
        {
            switch (eventType)
            {
                case Constants.PBT_POWERSETTINGCHANGE:
                    Windows.Win32.System.Power.POWERBROADCAST_SETTING settingChange
                        = Marshal.PtrToStructure<Windows.Win32.System.Power.POWERBROADCAST_SETTING>((IntPtr)setting);
                    bool knownSetting = KnownGuids.Descriptions.TryGetValue(settingChange.PowerSetting, out KeyValuePair<Type, string> settingDescription);
                    Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Power settings changed: {0}/{1}", knownSetting ? settingDescription.Key.Name : "Unknown", knownSetting ? settingDescription.Value : settingChange.PowerSetting));
                    MainWindow? window = null;
                    _ = weakReference?.TryGetTarget(out window);
                    if (knownSetting && window != null)
                    {
                        int bufferOffset = (int)Marshal.OffsetOf<Windows.Win32.System.Power.POWERBROADCAST_SETTING>("Data");
                        IntPtr buffer = (IntPtr)setting + bufferOffset;

                        if (settingChange.PowerSetting == PowerNotificationGuids.PowerSchemePersonality)
                        {
                            byte[] guidBytes = new byte[settingChange.DataLength];
                            Marshal.Copy(buffer, guidBytes, 0, (int)settingChange.DataLength);
                            Guid guid = new Guid(guidBytes);
                            _ = window.Dispatcher.Invoke(() => window.tbPowerPlan.Text = StringUtils.GetEffectivePowerModeString(guid));
                        }
                        else if (settingChange.PowerSetting == PowerSchemeSettingGuids.Display.DisplayIdleTimeout)
                        {
                            int seconds = Marshal.ReadInt32(buffer);
                            _ = window.Dispatcher.Invoke(() => window.tbVideoTimeout.Text = seconds == 0 ? "Never" : new TimeSpan(0, 0, seconds).ToString());
                        }
                        else if (settingChange.PowerSetting == PowerSchemeSettingGuids.Disk.DiskIdleTimeout)
                        {
                            int seconds = Marshal.ReadInt32(buffer);
                            _ = window.Dispatcher.Invoke(() => window.tbDiskTimeout.Text = seconds == 0 ? "Never" : new TimeSpan(0, 0, seconds).ToString());
                        }
                        else if (settingChange.PowerSetting == PowerSchemeSettingGuids.Sleep.StandbyIdleTimeout)
                        {
                            int seconds = Marshal.ReadInt32(buffer);
                            _ = window.Dispatcher.Invoke(() => window.tbIdleTimeout.Text = seconds == 0 ? "Never" : new TimeSpan(0, 0, seconds).ToString());
                        }
                        else if (settingChange.PowerSetting == PowerSchemeSettingGuids.Sleep.HibernateIdleTimeout)
                        {
                            int seconds = Marshal.ReadInt32(buffer);
                            _ = window.Dispatcher.Invoke(() => window.tbS3S4Timeout.Text = seconds == 0 ? "Never" : new TimeSpan(0, 0, seconds).ToString());
                        }
                        else if (settingChange.PowerSetting == PowerSchemeSettingGuids.PowerButtonLid.SleepButtonAction)
                        {
                            Windows.Win32.System.Power.POWER_ACTION action = (Windows.Win32.System.Power.POWER_ACTION)Marshal.ReadInt32(buffer);
                            _ = window.Dispatcher.Invoke(() => window.tbSleepButtonAction.Text = StringUtils.PowerActionToDescription(action));
                        }
                        else if (settingChange.PowerSetting == PowerSchemeSettingGuids.PowerButtonLid.PowerButtonAction)
                        {
                            Windows.Win32.System.Power.POWER_ACTION action = (Windows.Win32.System.Power.POWER_ACTION)Marshal.ReadInt32(buffer);
                            _ = window.Dispatcher.Invoke(() => window.tbPowerButtonAction.Text = StringUtils.PowerActionToDescription(action));
                        }
                        else if (settingChange.PowerSetting == PowerSchemeSettingGuids.PowerButtonLid.LidCloseAction)
                        {
                            Windows.Win32.System.Power.POWER_ACTION action = (Windows.Win32.System.Power.POWER_ACTION)Marshal.ReadInt32(buffer);
                            _ = window.Dispatcher.Invoke(() => window.tbLidCloseAction.Text = StringUtils.PowerActionToDescription(action));
                        }
                    }
                    break;
                default:
                    Debug.WriteLine($"Power settings changed? Unhandled EventType: {eventType}");
                    break;
            }
            return 0;
        }
        #endregion

        #region Power Mode Changed

        /// <summary>
        /// Forwards static system event for power mode changes.
        /// </summary>
        /// <inheritdoc cref="UserPreferenceChangedEventHandler.Invoke(object, UserPreferenceChangedEventArgs)" path="param"/>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void OnPowerModeChanged(object? sender, PowerModeChangedEventArgs e)
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Power Mode Changed - {0}", e.Mode.ToString()));
            /*
             * "Do not perform time-consuming processing on the thread that raises a system event handler
             *  because it might prevent other applications from functioning."
             *  -- https://docs.microsoft.com/en-us/dotnet/api/microsoft.win32.systemevents?view=net-5.0
             *
             *  Forward system events in a separate thread.
             */
            Thread thread = new(() =>
            {
                // Forward event to static event handlers
                // Forward event to instance event handlers that are subscribed
                PowerModeChanged?.Invoke(sender, e);
            });
            thread.Start();
        }

        /// <inheritdoc cref="SystemEvents.PowerModeChanged"/>
        private void OnForwardedPowerModeChanged(object? sender, PowerModeChangedEventArgs e)
        {
            // Power source (AC/DC) or battery level has changed.
            if (e.Mode == PowerModes.StatusChange)
            {
                GetPowerProfile();
            }
        }

        /// <inheritdoc cref="Windows.Win32.System.Power.EFFECTIVE_POWER_MODE_CALLBACK"/>
        private void OnEffectivePowerModeChanged(Windows.Win32.System.Power.EFFECTIVE_POWER_MODE effectivePowerMode, void* context)
        {
            bool addPowerPolicyChangeHandlers = currentPowerScheme == Guid.Empty;
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Effective Power Mode Changed - {0}", effectivePowerMode.ToString()));
            string effectivePowerModeString = StringUtils.GetEffectivePowerModeString(effectivePowerMode);
            _ = Dispatcher.Invoke(() => tbPowerPlan.Text = effectivePowerModeString, System.Windows.Threading.DispatcherPriority.Normal);
            GetPowerProfile();
            if (addPowerPolicyChangeHandlers)
            {
                AddPowerPolicyChangeHandlers();
            }
        }

        #endregion

        #region User Preference Changed

        /// <summary>
        /// Forwards static system event for user preference changes.
        /// </summary>
        /// <inheritdoc cref="UserPreferenceChangedEventHandler.Invoke(object, UserPreferenceChangedEventArgs)" path="param"/>
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void OnUserPreferenceChanged(object? sender, UserPreferenceChangedEventArgs e)
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "User Preferences Changed - {0}", e.Category.ToString()));
            /*
             * "Do not perform time-consuming processing on the thread that raises a system event handler
             *  because it might prevent other applications from functioning."
             *  -- https://docs.microsoft.com/en-us/dotnet/api/microsoft.win32.systemevents?view=net-5.0
             *
             *  Forward system events in a separate thread.
             */
            Thread thread = new(() =>
            {
                // Forward event to static event handlers
                // Forward event to instance event handlers that are subscribed
                UserPreferenceChanged?.Invoke(sender, e);
            });
            thread.Start();
        }

        /// <inheritdoc cref="SystemEvents.UserPreferenceChanged"/>
        private void OnForwardedUserPreferenceChanged(object? sender, UserPreferenceChangedEventArgs e)
        {
            // Power settings have been changed.
            if (e.Category == UserPreferenceCategory.Power)
            {
                GetPowerProfile();
            }
        }

        #endregion

        #region Get Power Profile and Update UI

        /// <summary>
        /// Get the current power profile settings.
        /// </summary>
        private unsafe void GetPowerProfile()
        {
            uint win32ErrorCode;
            int ntStatus;

            win32ErrorCode = PInvoke.PowerGetActiveScheme(null, out Guid* activePolicyGuid);
            if (ErrorUtils.IsSuccess(win32ErrorCode))
            {
                currentPowerScheme = *activePolicyGuid;
                // PowerRegisterForEffectivePowerModeNotifications is only supported on Windows 10 1809+. On Vista+ use the scheme's name instead.
                if (effectivePowerModeCallback == null && OperatingSystem.IsWindowsVersionAtLeast(6, 0, 0, 0))
                {
                    string effectivePowerMode = StringUtils.GetEffectivePowerModeString(currentPowerScheme);
                    _ = Dispatcher.Invoke(() => tbPowerPlan.Text = effectivePowerMode);
                    _ = PInvoke.LocalFree((IntPtr)activePolicyGuid);
                }
            }

            // Get the current power policy and update the UI
            Windows.Win32.System.Power.SYSTEM_POWER_POLICY currentPowerPolicy = new();
            ntStatus = PInvoke.CallNtPowerInformation(Windows.Win32.System.SystemServices.POWER_INFORMATION_LEVEL.SystemPowerPolicyCurrent, null, 0, &currentPowerPolicy, 232);
            if (ErrorUtils.IsSuccess(ntStatus))
            {
                Windows.Win32.System.Power.SYSTEM_POWER_POLICY powerPolicy = currentPowerPolicy;
                Dispatcher.Invoke(() => UpdatePowerPolicyUI(powerPolicy), System.Windows.Threading.DispatcherPriority.Normal);
            }
        }

        /// <summary>
        /// Update the UI with values from <paramref name="currentPowerPolicy"/>.
        /// </summary>
        /// <param name="currentPowerPolicy">A <see cref="Windows.Win32.System.Power.SYSTEM_POWER_POLICY"/>.</param>
        private void UpdatePowerPolicyUI(Windows.Win32.System.Power.SYSTEM_POWER_POLICY currentPowerPolicy)
        {
            tbIdleThreshold.Text = string.Format(CultureInfo.CurrentCulture, "{0}%", currentPowerPolicy.IdleSensitivity);
            tbIdleAction.Text = StringUtils.PowerActionToDescription(currentPowerPolicy.Idle.Action);
        }

        #endregion
    }
}
