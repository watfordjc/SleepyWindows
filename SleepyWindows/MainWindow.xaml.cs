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
            InitializeComponent();
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
            SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
            SystemEvents.PowerModeChanged -= OnPowerModeChanged;
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
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Effective Power Mode Changed - {0}", effectivePowerMode.ToString()));
            string effectivePowerModeString = StringUtils.GetEffectivePowerModeString(effectivePowerMode);
            _ = Dispatcher.Invoke(() => tbPowerPlan.Text = effectivePowerModeString, System.Windows.Threading.DispatcherPriority.Normal);
            GetPowerProfile();
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
            tbVideoTimeout.Text = new TimeSpan(0, 0, (int)currentPowerPolicy.VideoTimeout).ToString();
            tbDiskTimeout.Text = new TimeSpan(0, 0, (int)currentPowerPolicy.SpindownTimeout).ToString();
            tbIdleThreshold.Text = string.Format(CultureInfo.CurrentCulture, "{0}%", currentPowerPolicy.IdleSensitivity);
            tbIdleTimeout.Text = new TimeSpan(0, 0, (int)currentPowerPolicy.IdleTimeout).ToString();
            tbIdleAction.Text = StringUtils.PowerActionToDescription(currentPowerPolicy.Idle.Action);
            tbSleepButtonAction.Text = StringUtils.PowerActionToDescription(currentPowerPolicy.SleepButton.Action);
            tbPowerButtonAction.Text = StringUtils.PowerActionToDescription(currentPowerPolicy.PowerButton.Action);
            tbLidCloseAction.Text = StringUtils.PowerActionToDescription(currentPowerPolicy.LidClose.Action);
            int dozeS4Timeout = (int)currentPowerPolicy.DozeS4Timeout;
            tbS3S4Timeout.Text = dozeS4Timeout == 0 ? "Never" : new TimeSpan(0, 0, dozeS4Timeout).ToString();
        }

        #endregion
    }
}
