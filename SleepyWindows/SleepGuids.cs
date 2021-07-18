using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.JohnCook.dotnet.SleepyWindows
{
    public static class KnownGuids
    {
        public static readonly Dictionary<Guid, KeyValuePair<Type, string>> Descriptions = new()
        {
            { PowerNotificationGuids.AcDcPowerSource, new(typeof(PowerNotificationGuids), "AC/DC Power Source") },
            { PowerNotificationGuids.BatteryPercentRemaining, new(typeof(PowerNotificationGuids), "Battery Percent Remaining") },
            { PowerNotificationGuids.ConsoleDisplayState, new(typeof(PowerNotificationGuids), "Console Display State") },
            { PowerNotificationGuids.GlobalUserPresence, new(typeof(PowerNotificationGuids), "Global User Presence") },
            { PowerNotificationGuids.IdleBackgroundTask, new(typeof(PowerNotificationGuids), "Idle Background Task") },
            { PowerNotificationGuids.MonitorPowerOn, new(typeof(PowerNotificationGuids), "Monitor Power On") },
            { PowerNotificationGuids.PowerSavingStatus, new(typeof(PowerNotificationGuids), "Power Saving Status") },
            { PowerNotificationGuids.PowerSchemePersonality, new(typeof(PowerNotificationGuids), "Power Scheme Personality") },
            { PowerNotificationGuids.SessionDisplayStatus, new(typeof(PowerNotificationGuids), "Session Display State") },
            { PowerNotificationGuids.SessionUserPresence, new(typeof(PowerNotificationGuids), "Session User Presence") },
            { PowerNotificationGuids.SystemAwayMode, new(typeof(PowerNotificationGuids), "System Away Mode") },
            { PowerSchemePersonalityGuids.MinPowerSavings, new(typeof(PowerSchemePersonalityGuids), "Minimal Power Savings") },
            { PowerSchemePersonalityGuids.MaxPowerSavings, new(typeof(PowerSchemePersonalityGuids), "Maximum Power Savings") },
            { PowerSchemePersonalityGuids.TypicalPowerSavings, new(typeof(PowerSchemePersonalityGuids), "Typical Power Savings") },
            { PowerSchemeSubgroupGuids.Battery, new(typeof(PowerSchemeSubgroupGuids), "Battery") },
            { PowerSchemeSubgroupGuids.PowerButtonLid, new(typeof(PowerSchemeSubgroupGuids), "Power Button and Lid") },
            { PowerSchemeSubgroupGuids.Display, new(typeof(PowerSchemeSubgroupGuids), "Display") },
            { PowerSchemeSubgroupGuids.Disk, new(typeof(PowerSchemeSubgroupGuids), "Disk") },
            { PowerSchemeSubgroupGuids.EnergySaver, new(typeof(PowerSchemeSubgroupGuids), "Energy Saver") },
            { PowerSchemeSubgroupGuids.PciExpress, new(typeof(PowerSchemeSubgroupGuids), "PCI Express") },
            { PowerSchemeSubgroupGuids.Sleep, new(typeof(PowerSchemeSubgroupGuids), "Sleep") },
            { PowerSchemeSubgroupGuids.Miscellaneous, new(typeof(PowerSchemeSubgroupGuids), "Miscellaneous") },
            { PowerSchemeSubgroupGuids.InternetExplorer, new(typeof(PowerSchemeSubgroupGuids), "Internet Explorer") },
            { PowerSchemeSubgroupGuids.Desktop, new(typeof(PowerSchemeSubgroupGuids), "Desktop") },
            { PowerSchemeSubgroupGuids.WirelessAdapters, new(typeof(PowerSchemeSubgroupGuids), "Wireless Adapters") },
            { PowerSchemeSubgroupGuids.USB, new(typeof(PowerSchemeSubgroupGuids), "USB") },
            { PowerSchemeSubgroupGuids.IdleResiliency, new(typeof(PowerSchemeSubgroupGuids), "Idle Resiliency") },
            { PowerSchemeSubgroupGuids.InterruptSteering, new(typeof(PowerSchemeSubgroupGuids), "Interrupt Steering") },
            { PowerSchemeSubgroupGuids.Processor, new(typeof(PowerSchemeSubgroupGuids), "Processor") },
            { PowerSchemeSubgroupGuids.Presence, new(typeof(PowerSchemeSubgroupGuids), "Presence") },
            { PowerSchemeSubgroupGuids.Media, new(typeof(PowerSchemeSubgroupGuids), "Media") },
            { PowerSchemeSubgroupGuids.Graphics, new(typeof(PowerSchemeSubgroupGuids), "Graphics") },
            { PowerSchemeSettingGuids.Battery.CriticalBatteryAction, new(typeof(PowerSchemeSettingGuids.Battery), "Critical Battery Action") },
            { PowerSchemeSettingGuids.Battery.CriticalBatteryThreshold, new(typeof(PowerSchemeSettingGuids.Battery), "CriticalBatteryThreshold") },
            { PowerSchemeSettingGuids.Battery.CriticalBatteryWarning, new(typeof(PowerSchemeSettingGuids.Battery), "CriticalBatteryWarning") },
            { PowerSchemeSettingGuids.Battery.LowBatteryAction, new(typeof(PowerSchemeSettingGuids.Battery), "LowBatteryAction") },
            { PowerSchemeSettingGuids.Battery.LowBatteryThreshold, new(typeof(PowerSchemeSettingGuids.Battery), "LowBatteryThreshold") },
            { PowerSchemeSettingGuids.Battery.LowBatteryWarning, new(typeof(PowerSchemeSettingGuids.Battery), "LowBatteryWarning") },
            { PowerSchemeSettingGuids.Battery.ReserveBatteryLevel, new(typeof(PowerSchemeSettingGuids.Battery), "ReserveBatteryLevel") },
            { PowerSchemeSettingGuids.PowerButtonLid.LidOpenWakeAction, new(typeof(PowerSchemeSettingGuids.PowerButtonLid), "LidOpenWakeAction") },
            { PowerSchemeSettingGuids.PowerButtonLid.LidCloseAction, new(typeof(PowerSchemeSettingGuids.PowerButtonLid), "LidCloseAction") },
            { PowerSchemeSettingGuids.PowerButtonLid.PowerButtonAction, new(typeof(PowerSchemeSettingGuids.PowerButtonLid), "PowerButtonAction") },
            { PowerSchemeSettingGuids.PowerButtonLid.PowerButtonForcedShutdown, new(typeof(PowerSchemeSettingGuids.PowerButtonLid), "PowerButtonForcedShutdown") },
            { PowerSchemeSettingGuids.PowerButtonLid.SleepButtonAction, new(typeof(PowerSchemeSettingGuids.PowerButtonLid), "SleepButtonAction") },
            { PowerSchemeSettingGuids.PowerButtonLid.StartMenuPowerAction, new(typeof(PowerSchemeSettingGuids.PowerButtonLid), "StartMenuPowerAction") },
            { PowerSchemeSettingGuids.Display.AdaptiveDisplayIdleTimeout, new(typeof(PowerSchemeSettingGuids.Display), "AdaptiveDisplayIdleTimeout") },
            { PowerSchemeSettingGuids.Display.AdvancedColorQualityBias, new(typeof(PowerSchemeSettingGuids.Display), "AdvancedColorQualityBias") },
            { PowerSchemeSettingGuids.Display.AllowDisplayRequiredPolicy, new(typeof(PowerSchemeSettingGuids.Display), "AllowDisplayRequiredPolicy") },
            { PowerSchemeSettingGuids.Display.DimAnnoyanceTimeout, new(typeof(PowerSchemeSettingGuids.Display), "DimAnnoyanceTimeout") },
            { PowerSchemeSettingGuids.Display.DimDisplayBrightness, new(typeof(PowerSchemeSettingGuids.Display), "DimDisplayBrightness") },
            { PowerSchemeSettingGuids.Display.DimDisplayTimeout, new(typeof(PowerSchemeSettingGuids.Display), "DimDisplayTimeout") },
            { PowerSchemeSettingGuids.Display.DisplayBrightnessLevel, new(typeof(PowerSchemeSettingGuids.Display), "DisplayBrightnessLevel") },
            { PowerSchemeSettingGuids.Display.DisplayIdleTimeout, new(typeof(PowerSchemeSettingGuids.Display), "DisplayIdleTimeout") },
            { PowerSchemeSettingGuids.Display.ConsoleLockDisplayOffTimeout, new(typeof(PowerSchemeSettingGuids.Display), "ConsoleLockDisplayOffTimeout") },
            { PowerSchemeSettingGuids.Display.AdaptiveBrightness, new(typeof(PowerSchemeSettingGuids.Display), "AdaptiveBrightness") },
            { PowerSchemeSettingGuids.Disk.DiskBurstIgnoreTime, new(typeof(PowerSchemeSettingGuids.Disk), "DiskBurstIgnoreTime") },
            { PowerSchemeSettingGuids.Disk.DiskIdleTimeout, new(typeof(PowerSchemeSettingGuids.Disk), "DiskIdleTimeout") },
            { PowerSchemeSettingGuids.Disk.AhciLinkIdleTimeout, new(typeof(PowerSchemeSettingGuids.Disk), "AhciLinkIdleTimeout") },
            { PowerSchemeSettingGuids.Disk.AhciLinkPowerManagementMode, new(typeof(PowerSchemeSettingGuids.Disk), "AhciLinkPowerManagementMode") },
            { PowerSchemeSettingGuids.Disk.MaximumPowerLevel, new(typeof(PowerSchemeSettingGuids.Disk), "MaximumPowerLevel") },
            { PowerSchemeSettingGuids.Disk.NvmeNonOperationalPowerStatePermissiveMode, new(typeof(PowerSchemeSettingGuids.Disk), "NvmeNonOperationalPowerStatePermissiveMode") },
            { PowerSchemeSettingGuids.Disk.PrimaryNvmeIdleTimeout, new(typeof(PowerSchemeSettingGuids.Disk), "PrimaryNvmeIdleTimeout") },
            { PowerSchemeSettingGuids.Disk.PrimaryNvmePowerStateTransitionLatencyTolerance, new(typeof(PowerSchemeSettingGuids.Disk), "PrimaryNvmePowerStateTransitionLatencyTolerance") },
            { PowerSchemeSettingGuids.Disk.SecondaryNvmeIdleTimeout, new(typeof(PowerSchemeSettingGuids.Disk), "SecondaryNvmeIdleTimeout") },
            { PowerSchemeSettingGuids.Disk.SecondaryNvmePowerStateTransitionLatencyTolerance, new(typeof(PowerSchemeSettingGuids.Disk), "SecondaryNvmePowerStateTransitionLatencyTolerance") },
            { PowerSchemeSettingGuids.EnergySaver.BatteryThreshold, new(typeof(PowerSchemeSettingGuids.EnergySaver), "BatteryThreshold") },
            { PowerSchemeSettingGuids.EnergySaver.Brightness, new(typeof(PowerSchemeSettingGuids.EnergySaver), "Brightness") },
            { PowerSchemeSettingGuids.EnergySaver.EnergySaverPolicy, new(typeof(PowerSchemeSettingGuids.EnergySaver), "EnergySaverPolicy") },
            { PowerSchemeSettingGuids.PciExpress.LinkStatePowerManagement, new(typeof(PowerSchemeSettingGuids.PciExpress), "LinkStatePowerManagement") },
            { PowerSchemeSettingGuids.Sleep.AwayMode, new(typeof(PowerSchemeSettingGuids.Sleep), "AwayMode") },
            { PowerSchemeSettingGuids.Sleep.AllowRemoteOpenSleep, new(typeof(PowerSchemeSettingGuids.Sleep), "AllowRemoteOpenSleep") },
            { PowerSchemeSettingGuids.Sleep.AllowStandby, new(typeof(PowerSchemeSettingGuids.Sleep), "AllowStandby") },
            { PowerSchemeSettingGuids.Sleep.AllowSystemRequired, new(typeof(PowerSchemeSettingGuids.Sleep), "AllowSystemRequired") },
            { PowerSchemeSettingGuids.Sleep.WakeTimers, new(typeof(PowerSchemeSettingGuids.Sleep), "WakeTimers") },
            { PowerSchemeSettingGuids.Sleep.HibernateIdleTimeout, new(typeof(PowerSchemeSettingGuids.Sleep), "HibernateIdleTimeout") },
            { PowerSchemeSettingGuids.Sleep.HybridSleep, new(typeof(PowerSchemeSettingGuids.Sleep), "HybridSleep") },
            { PowerSchemeSettingGuids.Sleep.StandbyIdleTimeout, new(typeof(PowerSchemeSettingGuids.Sleep), "StandbyIdleTimeout") },
            { PowerSchemeSettingGuids.Sleep.UnattendIdleTimeout, new(typeof(PowerSchemeSettingGuids.Sleep), "UnattendIdleTimeout") },
            { PowerSchemeSettingGuids.Sleep.LegacyWakeMitigations, new(typeof(PowerSchemeSettingGuids.Sleep), "LegacyWakeMitigations") },
            { PowerSchemeSettingGuids.Miscellaneous.DeviceIdlePolicy, new(typeof(PowerSchemeSettingGuids.Miscellaneous), "DeviceIdlePolicy") },
            { PowerSchemeSettingGuids.Miscellaneous.LockConsoleOnWake, new(typeof(PowerSchemeSettingGuids.Miscellaneous), "LockConsoleOnWake") },
            { PowerSchemeSettingGuids.Miscellaneous.ConnectivityInStandby, new(typeof(PowerSchemeSettingGuids.Miscellaneous), "ConnectivityInStandby") },
            { PowerSchemeSettingGuids.LegacyOptions.PerfBoostMode, new(typeof(PowerSchemeSettingGuids.LegacyOptions), "PerfBoostMode") },
            { PowerSchemeSettingGuids.LegacyOptions.PerfBoostPol, new(typeof(PowerSchemeSettingGuids.LegacyOptions), "PerfBoostPol") },
            { PowerSchemeSettingGuids.InternetExplorer.JavaScriptTimerFrequency, new(typeof(PowerSchemeSettingGuids.InternetExplorer), "JavaScriptTimerFrequency") },
            { PowerSchemeSettingGuids.Desktop.BackgroundSlideShow, new(typeof(PowerSchemeSettingGuids.Desktop), "BackgroundSlideShow") },
            { PowerSchemeSettingGuids.WirelessAdapters.PowerSaveMode, new(typeof(PowerSchemeSettingGuids.WirelessAdapters), "PowerSaveMode") },
            { PowerSchemeSettingGuids.USB.HubSelectiveSuspendTimeout, new(typeof(PowerSchemeSettingGuids.USB), "HubSelectiveSuspendTimeout") },
            { PowerSchemeSettingGuids.USB.SelectiveSuspend, new(typeof(PowerSchemeSettingGuids.USB), "SelectiveSuspend") },
            { PowerSchemeSettingGuids.USB.SettingIocOnAllTds, new(typeof(PowerSchemeSettingGuids.USB), "SettingIocOnAllTds") },
            { PowerSchemeSettingGuids.USB.LinkPowerManagement, new(typeof(PowerSchemeSettingGuids.USB), "LinkPowerManagement") },
            { PowerSchemeSettingGuids.IdleResiliency.ExecutionRequiredPowerRequestTimeout, new(typeof(PowerSchemeSettingGuids.IdleResiliency), "ExecutionRequiredPowerRequestTimeout") },
            { PowerSchemeSettingGuids.IdleResiliency.IOCoalescingTimeout, new(typeof(PowerSchemeSettingGuids.IdleResiliency), "IOCoalescingTimeout") },
            { PowerSchemeSettingGuids.IdleResiliency.ProcessorIdleResiliencyTimerResolution, new(typeof(PowerSchemeSettingGuids.IdleResiliency), "ProcessorIdleResiliencyTimerResolution") },
            { PowerSchemeSettingGuids.IdleResiliency.DeepSleep, new(typeof(PowerSchemeSettingGuids.IdleResiliency), "DeepSleep") },
            { PowerSchemeSettingGuids.InterruptSteering.InterruptSteeringMode, new(typeof(PowerSchemeSettingGuids.InterruptSteering), "InterruptSteeringMode") },
            { PowerSchemeSettingGuids.InterruptSteering.TargetLoad, new(typeof(PowerSchemeSettingGuids.InterruptSteering), "TargetLoad") },
            { PowerSchemeSettingGuids.InterruptSteering.UnparkedTimeTrigger, new(typeof(PowerSchemeSettingGuids.InterruptSteering), "UnparkedTimeTrigger") },
            { PowerSchemeSettingGuids.Processor.EnergyPerformancePreferencePolicy, new(typeof(PowerSchemeSettingGuids.Processor), "EnergyPerformancePreferencePolicy") },
            { PowerSchemeSettingGuids.Processor.EnergyPerformancePreferencePolicyClass1, new(typeof(PowerSchemeSettingGuids.Processor), "EnergyPerformancePreferencePolicyClass1") },
            { PowerSchemeSettingGuids.Processor.PerformanceAutonomousMode, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceAutonomousMode") },
            { PowerSchemeSettingGuids.Processor.PerformanceAntonomousWindow, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceAntonomousWindow") },
            { PowerSchemeSettingGuids.Processor.PerformanceTimeCheckInterval, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceTimeCheckInterval") },
            { PowerSchemeSettingGuids.Processor.PerformanceHistoryCount, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceHistoryCount") },
            { PowerSchemeSettingGuids.Processor.PerformanceHistoryCountClass1, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceHistoryCountClass1") },
            { PowerSchemeSettingGuids.Processor.PerformanceIncreasePolicy, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceIncreasePolicy") },
            { PowerSchemeSettingGuids.Processor.PerformanceIncreasePolicyClass1, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceIncreasePolicyClass1") },
            { PowerSchemeSettingGuids.Processor.PerformanceIncreaseThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceIncreaseThreshold") },
            { PowerSchemeSettingGuids.Processor.PerformanceIncreaseThresholdClass1, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceIncreaseThresholdClass1") },
            { PowerSchemeSettingGuids.Processor.PerformanceIncreaseTime, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceIncreaseTime") },
            { PowerSchemeSettingGuids.Processor.PerformanceIncreaseTimeClass1, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceIncreaseTimeClass1") },
            { PowerSchemeSettingGuids.Processor.PerformanceDecreasePolicy, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceDecreasePolicy") },
            { PowerSchemeSettingGuids.Processor.PerformanceDecreasePolicyClass1, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceDecreasePolicyClass1") },
            { PowerSchemeSettingGuids.Processor.PerformanceDecreaseThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceDecreaseThreshold") },
            { PowerSchemeSettingGuids.Processor.PerformanceDecreaseThresholdClass1, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceDecreaseThresholdClass1") },
            { PowerSchemeSettingGuids.Processor.PerformanceDecreaseTime, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceDecreaseTime") },
            { PowerSchemeSettingGuids.Processor.PerformanceDecreaseTimeClass1, new(typeof(PowerSchemeSettingGuids.Processor), "PerformanceDecreaseTimeClass1") },
            { PowerSchemeSettingGuids.Processor.CoreParkedPerformanceState, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkedPerformanceState") },
            { PowerSchemeSettingGuids.Processor.CoreParkedPerformanceStateClass1, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkedPerformanceStateClass1") },
            { PowerSchemeSettingGuids.Processor.CoreParkingMinCores, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingMinCores") },
            { PowerSchemeSettingGuids.Processor.CoreParkingMinCoresClass1, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingMinCoresClass1") },
            { PowerSchemeSettingGuids.Processor.CoreParkingMaxCores, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingMaxCores") },
            { PowerSchemeSettingGuids.Processor.CoreParkingMaxCoresClass1, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingMaxCoresClass1") },
            { PowerSchemeSettingGuids.Processor.CoreParkingDistributionThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingDistributionThreshold") },
            { PowerSchemeSettingGuids.Processor.CoreParkingUtilityDistribution, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingUtilityDistribution") },
            { PowerSchemeSettingGuids.Processor.CoreParkingConcurrencyThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingConcurrencyThreshold") },
            { PowerSchemeSettingGuids.Processor.CoreParkingConcurrencyHeadroomThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingConcurrencyHeadroomThreshold") },
            { PowerSchemeSettingGuids.Processor.CoreParkingIncreasePolicy, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingIncreasePolicy") },
            { PowerSchemeSettingGuids.Processor.CoreParkingIncreaseTime, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingIncreaseTime") },
            { PowerSchemeSettingGuids.Processor.CoreParkingDecreasePolicy, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingDecreasePolicy") },
            { PowerSchemeSettingGuids.Processor.CoreParkingDecreaseTime, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingDecreaseTime") },
            { PowerSchemeSettingGuids.Processor.CoreParkingOverutilizationThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingOverutilizationThreshold") },
            { PowerSchemeSettingGuids.Processor.CoreParkingSoftParkLatency, new(typeof(PowerSchemeSettingGuids.Processor), "CoreParkingSoftParkLatency") },
            { PowerSchemeSettingGuids.Processor.InitialUnparkedPerformanceClass1, new(typeof(PowerSchemeSettingGuids.Processor), "InitialUnparkedPerformanceClass1") },
            { PowerSchemeSettingGuids.Processor.LatencySensitivityHintPerformance, new(typeof(PowerSchemeSettingGuids.Processor), "LatencySensitivityHintPerformance") },
            { PowerSchemeSettingGuids.Processor.LatencySensitivityHintPerformanceClass1, new(typeof(PowerSchemeSettingGuids.Processor), "LatencySensitivityHintPerformanceClass1") },
            { PowerSchemeSettingGuids.Processor.LatencySensitivityHintMinUnparkedCores, new(typeof(PowerSchemeSettingGuids.Processor), "LatencySensitivityHintMinUnparkedCores") },
            { PowerSchemeSettingGuids.Processor.LatencySensitivityHintMinUnparkedCoresClass1, new(typeof(PowerSchemeSettingGuids.Processor), "LatencySensitivityHintMinUnparkedCoresClass1") },
            { PowerSchemeSettingGuids.Processor.IdleDisable, new(typeof(PowerSchemeSettingGuids.Processor), "IdleDisable") },
            { PowerSchemeSettingGuids.Processor.IdlePromoteThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "IdlePromoteThreshold") },
            { PowerSchemeSettingGuids.Processor.IdleDemoteThreshold, new(typeof(PowerSchemeSettingGuids.Processor), "IdleDemoteThreshold") },
            { PowerSchemeSettingGuids.Processor.IdleThresholdScaling, new(typeof(PowerSchemeSettingGuids.Processor), "IdleThresholdScaling") },
            { PowerSchemeSettingGuids.Processor.IdleStateMaximum, new(typeof(PowerSchemeSettingGuids.Processor), "IdleStateMaximum") },
            { PowerSchemeSettingGuids.Processor.IdleCheckTime, new(typeof(PowerSchemeSettingGuids.Processor), "IdleCheckTime") },
            { PowerSchemeSettingGuids.Processor.AllowThrottleStates, new(typeof(PowerSchemeSettingGuids.Processor), "AllowThrottleStates") },
            { PowerSchemeSettingGuids.Processor.DutyCycling, new(typeof(PowerSchemeSettingGuids.Processor), "DutyCycling") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousPolicy, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousPolicy") },
            { PowerSchemeSettingGuids.Processor.MinimumProcessorState, new(typeof(PowerSchemeSettingGuids.Processor), "MinimumProcessorState") },
            { PowerSchemeSettingGuids.Processor.MinimumProcessorStateClass1, new(typeof(PowerSchemeSettingGuids.Processor), "MinimumProcessorStateClass1") },
            { PowerSchemeSettingGuids.Processor.MaximumProcessorState, new(typeof(PowerSchemeSettingGuids.Processor), "MaximumProcessorState") },
            { PowerSchemeSettingGuids.Processor.MaximumProcessorStateClass1, new(typeof(PowerSchemeSettingGuids.Processor), "MaximumProcessorStateClass1") },
            { PowerSchemeSettingGuids.Processor.MaximumFrequency, new(typeof(PowerSchemeSettingGuids.Processor), "MaximumFrequency") },
            { PowerSchemeSettingGuids.Processor.MaximumFrequencyClass1, new(typeof(PowerSchemeSettingGuids.Processor), "MaximumFrequencyClass1") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousPerformanceFloorClass0UnparkedClass1, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousPerformanceFloorClass0UnparkedClass1") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousPerformanceDecreaseTimeClass1, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousPerformanceDecreaseTimeClass1") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousPerformanceDecreaseThresholdClass1, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousPerformanceDecreaseThresholdClass1") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousPerformanceIncreaseTimeClass1, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousPerformanceIncreaseTimeClass1") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousPerformanceIncreaseThresholdClass1, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousPerformanceIncreaseThresholdClass1") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousThreadSchedulePolicy, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousThreadSchedulePolicy") },
            { PowerSchemeSettingGuids.Processor.HeterogeneousShortRunningThreadSchedulePolicy, new(typeof(PowerSchemeSettingGuids.Processor), "HeterogeneousShortRunningThreadSchedulePolicy") },
            { PowerSchemeSettingGuids.Processor.SystemCoolingPolicy, new(typeof(PowerSchemeSettingGuids.Processor), "SystemCoolingPolicy") },
            { PowerSchemeSettingGuids.Presence.StandbyBudgetPercent, new(typeof(PowerSchemeSettingGuids.Presence), "StandbyBudgetPercent") },
            { PowerSchemeSettingGuids.Presence.StandbyBudgetGracePeriod, new(typeof(PowerSchemeSettingGuids.Presence), "StandbyBudgetGracePeriod") },
            { PowerSchemeSettingGuids.Presence.StandbyReserveTime, new(typeof(PowerSchemeSettingGuids.Presence), "StandbyReserveTime") },
            { PowerSchemeSettingGuids.Presence.StandbyReserveGracePeriod, new(typeof(PowerSchemeSettingGuids.Presence), "StandbyReserveGracePeriod") },
            { PowerSchemeSettingGuids.Presence.StandbyResetPercentage, new(typeof(PowerSchemeSettingGuids.Presence), "StandbyResetPercentage") },
            { PowerSchemeSettingGuids.Presence.NonSensorInputPresenceTimeout, new(typeof(PowerSchemeSettingGuids.Presence), "NonSensorInputPresenceTimeout") },
            { PowerSchemeSettingGuids.Presence.UserPresencePredictionMode, new(typeof(PowerSchemeSettingGuids.Presence), "UserPresencePredictionMode") },
            { PowerSchemeSettingGuids.Media.WhenSharingMedia, new(typeof(PowerSchemeSettingGuids.Media), "WhenSharingMedia") },
            { PowerSchemeSettingGuids.Media.VideoPlaybackQualityBias, new(typeof(PowerSchemeSettingGuids.Media), "VideoPlaybackQualityBias") },
            { PowerSchemeSettingGuids.Media.WhenPlayingVideo, new(typeof(PowerSchemeSettingGuids.Media), "WhenPlayingVideo") },
            { PowerSchemeSettingGuids.Graphics.GpuPreferencePolicy, new(typeof(PowerSchemeSettingGuids.Graphics), "GpuPreferencePolicy") }
        };
    }

    public static class PowerNotificationGuids
    {
        public static readonly Guid AcDcPowerSource = new("5D3E9A59-E9D5-4B00-A6BD-FF34FF516548");
        public static readonly Guid BatteryPercentRemaining = new("A7AD8041-B45A-4CAE-87A3-EECBB468A9E1");
        public static readonly Guid ConsoleDisplayState = new("6FE69556-704A-47A0-8F24-C28D936FDA47");
        public static readonly Guid GlobalUserPresence = new("786E8A1D-B427-4344-9207-09E70BDCBEA9");
        public static readonly Guid IdleBackgroundTask = new("515C31D8-F734-163D-A0FD-11A08C91E8F1");
        public static readonly Guid MonitorPowerOn = new("02731015-4510-4526-99E6-E5A17EBD1AEA");
        public static readonly Guid PowerSavingStatus = new("E00958C0-C213-4ACE-AC77-FECCED2EEEA5");
        public static readonly Guid PowerSchemePersonality = new("245d8541-3943-4422-b025-13A784F679B7");
        public static readonly Guid SessionDisplayStatus = new("2B84C20E-AD23-4ddf-93DB-05FFBD7EFCA5");
        public static readonly Guid SessionUserPresence = new("3C0F4548-C03F-4c4d-B9F2-237EDE686376");
        public static readonly Guid SystemAwayMode = new("98A7F580-01F7-48AA-9C0F-44352C29E5C0");
    }

    public static class PowerSchemePersonalityGuids
    {
        public static readonly Guid MinPowerSavings = new("8C5E7FDA-E8BF-4A96-9A85-A6E23A8C635C");
        public static readonly Guid MaxPowerSavings = new("A1841308-3541-4FAB-BC81-F71556F20B4A");
        public static readonly Guid TypicalPowerSavings = new("381B4222-F694-41F0-9685-FF5BB260DF2E");
    }

    public static class PowerSchemeSubgroupGuids
    {
        public static readonly Guid Battery = new("e73a048d-bf27-4f12-9731-8b2076e8891f");
        public static readonly Guid PowerButtonLid = new("4f971e89-eebd-4455-a8de-9e59040e7347");
        public static readonly Guid Display = new("7516b95f-f776-4464-8c53-06167f40cc99");
        public static readonly Guid Disk = new("0012ee47-9041-4b5d-9b77-535fba8b1442");
        public static readonly Guid EnergySaver = new("de830923-a562-41af-a086-e3a2c6bad2da");
        public static readonly Guid PciExpress = new("501a4d13-42af-4429-9fd1-a8218c268e20");
        public static readonly Guid Sleep = new("238c9fa8-0aad-41ed-83f4-97be242c8f20");
        public static readonly Guid Miscellaneous = new("fea3413e-7e05-4911-9a71-700331f1c294");
        public static readonly Guid InternetExplorer = new("02f815b5-a5cf-4c84-bf20-649d1f75d3d8");
        public static readonly Guid Desktop = new("0d7dbae2-4294-402a-ba8e-26777e8488cd");
        public static readonly Guid WirelessAdapters = new("19cbb8fa-5279-450e-9fac-8a3d5fedd0c1");
        public static readonly Guid USB = new("2a737441-1930-4402-8d77-b2bebba308a3");
        public static readonly Guid IdleResiliency = new("2e601130-5351-4d9d-8e04-252966bad054");
        public static readonly Guid InterruptSteering = new("48672f38-7a9a-4bb2-8bf8-3d85be19de4e");
        public static readonly Guid Processor = new("54533251-82be-4824-96c1-47b60b740d00");
        public static readonly Guid Presence = new("8619b916-e004-4dd8-9b66-dae86f806698");
        public static readonly Guid Media = new("9596fb26-9850-41fd-ac3e-f7c3c00afd4b");
        public static readonly Guid Graphics = new("5fb4938d-1ee8-4b0f-9a3c-5036b0ab995c");
    }

    public static class PowerSchemeSettingGuids
    {
        public static class Battery
        {
            public static readonly Guid CriticalBatteryAction = new("637ea02f-bbcb-4015-8e2c-a1c7b9c0b546");
            public static readonly Guid CriticalBatteryThreshold = new("9a66d8d7-4ff7-4ef9-b5a2-5a326ca2a469");
            public static readonly Guid CriticalBatteryWarning = new("5dbb7c9f-38e9-40d2-9749-4f8a0e9f640f");
            public static readonly Guid LowBatteryAction = new("d8742dcb-3e6a-4b3c-b3fe-374623cdcf06");
            public static readonly Guid LowBatteryThreshold = new("8183ba9a-e910-48da-8769-14ae6dc1170a");
            public static readonly Guid LowBatteryWarning = new("bcded951-187b-4d05-bccc-f7e51960c258");
            public static readonly Guid ReserveBatteryLevel = new("f3c5027d-cd16-4930-aa6b-90db844a8f00");
        }

        public static class PowerButtonLid
        {
            public static readonly Guid LidOpenWakeAction = new("99ff10e7-23b1-4c07-a9d1-5c3206d741b4");
            public static readonly Guid LidCloseAction = new("5ca83367-6e45-459f-a27b-476b1d01c936");
            public static readonly Guid PowerButtonAction = new("7648efa3-dd9c-4e3e-b566-50f929386280");
            public static readonly Guid PowerButtonForcedShutdown = new("833a6b62-dfa4-46d1-82f8-e09e34d029d6");
            public static readonly Guid SleepButtonAction = new("96996bc0-ad50-47ec-923b-6f41874dd9eb");
            public static readonly Guid StartMenuPowerAction = new("a7066653-8d6c-40a8-910e-a1f54b84c7e5");
        }

        public static class Display
        {
            public static readonly Guid AdaptiveDisplayIdleTimeout = new("90959d22-d6a1-49b9-af93-bce885ad335b");
            public static readonly Guid AdvancedColorQualityBias = new("684C3E69-A4F7-4014-8754-D45179A56167");
            public static readonly Guid AllowDisplayRequiredPolicy = new("a9ceb8da-cd46-44fb-a98b-02af69de4623");
            public static readonly Guid DimAnnoyanceTimeout = new("82dbcf2d-cd67-40c5-bfdc-9f1a5ccd4663");
            public static readonly Guid DimDisplayBrightness = new("f1fbfde2-a960-4165-9f88-50667911ce96");
            public static readonly Guid DimDisplayTimeout = new("17aaa29b-8b43-4b94-aafe-35f64daaf1ee");
            public static readonly Guid DisplayBrightnessLevel = new("aded5e82-b909-4619-9949-f5d71dac0bcb");
            public static readonly Guid DisplayIdleTimeout = new("3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e");
            public static readonly Guid ConsoleLockDisplayOffTimeout = new("8ec4b3a5-6868-48c2-be75-4f3044be88a7");
            public static readonly Guid AdaptiveBrightness = new("fbd9aa66-9553-4097-ba44-ed6e9d65eab8");
        }

        public static class Disk
        {
            public static readonly Guid DiskBurstIgnoreTime = new("80e3c60e-bb94-4ad8-bbe0-0d3195efc663");
            public static readonly Guid DiskIdleTimeout = new("6738e2c4-e8a5-4a42-b16a-e040e769756e");
            public static readonly Guid AhciLinkIdleTimeout = new("dab60367-53fe-4fbc-825e-521d069d2456");
            public static readonly Guid AhciLinkPowerManagementMode = new("0b2d69d7-a2a1-449c-9680-f91c70521c60");
            public static readonly Guid MaximumPowerLevel = new("51dea550-bb38-4bc4-991b-eacf37be5ec8");
            public static readonly Guid NvmeNonOperationalPowerStatePermissiveMode = new("fc7372b6-ab2d-43ee-8797-15e9841f2cca");
            public static readonly Guid PrimaryNvmeIdleTimeout = new("d639518a-e56d-4345-8af2-b9f32fb26109");
            public static readonly Guid PrimaryNvmePowerStateTransitionLatencyTolerance = new("fc95af4d-40e7-4b6d-835a-56d131dbc80e");
            public static readonly Guid SecondaryNvmeIdleTimeout = new("d3d55efd-c1ff-424e-9dc3-441be7833010");
            public static readonly Guid SecondaryNvmePowerStateTransitionLatencyTolerance = new("dbc9e238-6de9-49e3-92cd-8c2b4946b472");
        }

        public static class EnergySaver
        {
            public static readonly Guid BatteryThreshold = new("e69653ca-cf7f-4f05-aa73-cb833fa90ad4");
            public static readonly Guid Brightness = new("13d09884-f74e-474a-a852-b6bde8ad03a8");
            public static readonly Guid EnergySaverPolicy = new("5c5bb349-ad29-4ee2-9d0b-2b25270f7a81");
        }

        public static class PciExpress
        {
            public static readonly Guid LinkStatePowerManagement = new("ee12f906-d277-404b-b6da-e5fa1a576df5");
        }

        public static class Sleep
        {
            public static readonly Guid AwayMode = new("25dfa149-5dd1-4736-b5ab-e8a37b5b8187");
            public static readonly Guid AllowRemoteOpenSleep = new("d4c1d4c8-d5cc-43d3-b83e-fc51215cb04d");
            public static readonly Guid AllowStandby = new("abfc2519-3608-4c2a-94ea-171b0ed546ab");
            public static readonly Guid AllowSystemRequired = new("a4b195f5-8225-47d8-8012-9d41369786e2");
            public static readonly Guid WakeTimers = new("bd3b718a-0680-4d9d-8ab2-e1d2b4ac806d");
            public static readonly Guid HibernateIdleTimeout = new("9d7815a6-7ee4-497e-8888-515a05f02364");
            public static readonly Guid HybridSleep = new("94ac6d29-73ce-41a6-809f-6363ba21b47e");
            public static readonly Guid StandbyIdleTimeout = new("29f6c1db-86da-48c5-9fdb-f2b67b1f44da");
            public static readonly Guid UnattendIdleTimeout = new("7bc4a2f9-d8fc-4469-b07b-33eb785aaca0");
            public static readonly Guid LegacyWakeMitigations = new("1a34bdc3-7e6b-442e-a9d0-64b6ef378e84");
        }

        public static class Miscellaneous
        {
            public static readonly Guid DeviceIdlePolicy = new("4faab71a-92e5-4726-b531-224559672d19");
            public static readonly Guid LockConsoleOnWake = new("0e796bdb-100d-47d6-a2d5-f7d2daa51f51");
            public static readonly Guid ConnectivityInStandby = new("f15576e8-98b7-4186-b944-eafa664402d9");
        }

        public static class LegacyOptions
        {
            public static readonly Guid PerfBoostMode = new("be337238-0d82-4146-a960-4f3749d470c7");
            public static readonly Guid PerfBoostPol = new("45bcc044-d885-43e2-8605-ee0ec6e96b59");
        }

        public static class InternetExplorer
        {
            public static readonly Guid JavaScriptTimerFrequency = new("4c793e7d-a264-42e1-87d3-7a0d2f523ccd");
        }

        public static class Desktop
        {
            public static readonly Guid BackgroundSlideShow = new("309dce9b-bef4-4119-9921-a851fb12f0f4");
        }

        public static class WirelessAdapters
        {
            public static readonly Guid PowerSaveMode = new("12bbebe6-58d6-4636-95bb-3217ef867c1a");
        }

        public static class USB
        {
            public static readonly Guid HubSelectiveSuspendTimeout = new("0853a681-27c8-4100-a2fd-82013e970683");
            public static readonly Guid SelectiveSuspend = new("48e6b7a6-50f5-4782-a5d4-53bb8f07e226");
            public static readonly Guid SettingIocOnAllTds = new("498c044a-201b-4631-a522-5c744ed4e678");
            public static readonly Guid LinkPowerManagement = new("d4e98f31-5ffe-4ce1-be31-1b38b384c009");
        }

        public static class IdleResiliency
        {
            public static readonly Guid ExecutionRequiredPowerRequestTimeout = new("3166bc41-7e98-4e03-b34e-ec0f5f2b218e");
            public static readonly Guid IOCoalescingTimeout = new("c36f0eb4-2988-4a70-8eee-0884fc2c2433");
            public static readonly Guid ProcessorIdleResiliencyTimerResolution = new("c42b79aa-aa3a-484b-a98f-2cf32aa90a28");
            public static readonly Guid DeepSleep = new("d502f7ee-1dc7-4efd-a55d-f04b6f5c0545");
        }

        public static class InterruptSteering
        {
            public static readonly Guid InterruptSteeringMode = new("2bfc24f9-5ea2-4801-8213-3dbae01aa39d");
            public static readonly Guid TargetLoad = new("73cde64d-d720-4bb2-a860-c755afe77ef2");
            public static readonly Guid UnparkedTimeTrigger = new("d6ba4903-386f-4c2c-8adb-5c21b3328d25");
        }

        public static class Processor
        {
            public static readonly Guid EnergyPerformancePreferencePolicy = new("36687f9e-e3a5-4dbf-b1dc-15eb381c6863");
            public static readonly Guid EnergyPerformancePreferencePolicyClass1 = new("36687f9e-e3a5-4dbf-b1dc-15eb381c6864");

            public static readonly Guid PerformanceAutonomousMode = new("8baa4a8a-14c6-4451-8e8b-14bdbd197537");
            public static readonly Guid PerformanceAntonomousWindow = new("cfeda3d0-7697-4566-a922-a9086cd49dfa");
            public static readonly Guid PerformanceTimeCheckInterval = new("4d2b0152-7d5c-498b-88e2-34345392a2c5");
            public static readonly Guid PerformanceHistoryCount = new("7d24baa7-0b84-480f-840c-1b0743c00f5f");
            public static readonly Guid PerformanceHistoryCountClass1 = new("7d24baa7-0b84-480f-840c-1b0743c00f60");

            public static readonly Guid PerformanceIncreasePolicy = new("465e1f50-b610-473a-ab58-00d1077dc418");
            public static readonly Guid PerformanceIncreasePolicyClass1 = new("465e1f50-b610-473a-ab58-00d1077dc419");
            public static readonly Guid PerformanceIncreaseThreshold = new("06cadf0e-64ed-448a-8927-ce7bf90eb35d");
            public static readonly Guid PerformanceIncreaseThresholdClass1 = new("06cadf0e-64ed-448a-8927-ce7bf90eb35e");
            public static readonly Guid PerformanceIncreaseTime = new("984cf492-3bed-4488-a8f9-4286c97bf5aa");
            public static readonly Guid PerformanceIncreaseTimeClass1 = new("984cf492-3bed-4488-a8f9-4286c97bf5ab");

            public static readonly Guid PerformanceDecreasePolicy = new("40fbefc7-2e9d-4d25-a185-0cfd8574bac6");
            public static readonly Guid PerformanceDecreasePolicyClass1 = new("40fbefc7-2e9d-4d25-a185-0cfd8574bac7");
            public static readonly Guid PerformanceDecreaseThreshold = new("12a0ab44-fe28-4fa9-b3bd-4b64f44960a6");
            public static readonly Guid PerformanceDecreaseThresholdClass1 = new("12a0ab44-fe28-4fa9-b3bd-4b64f44960a7");
            public static readonly Guid PerformanceDecreaseTime = new("d8edeb9b-95cf-4f95-a73c-b061973693c8");
            public static readonly Guid PerformanceDecreaseTimeClass1 = new("d8edeb9b-95cf-4f95-a73c-b061973693c9");

            public static readonly Guid CoreParkedPerformanceState = new("447235c7-6a8d-4cc0-8e24-9eaf70b96e2b");
            public static readonly Guid CoreParkedPerformanceStateClass1 = new("447235c7-6a8d-4cc0-8e24-9eaf70b96e2c");
            public static readonly Guid CoreParkingMinCores = new("0cc5b647-c1df-4637-891a-dec35c318583");
            public static readonly Guid CoreParkingMinCoresClass1 = new("0cc5b647-c1df-4637-891a-dec35c318584");
            public static readonly Guid CoreParkingMaxCores = new("ea062031-0e34-4ff1-9b6d-eb1059334028");
            public static readonly Guid CoreParkingMaxCoresClass1 = new("ea062031-0e34-4ff1-9b6d-eb1059334029");
            public static readonly Guid CoreParkingDistributionThreshold = new("4bdaf4e9-d103-46d7-a5f0-6280121616ef");
            public static readonly Guid CoreParkingUtilityDistribution = new("e0007330-f589-42ed-a401-5ddb10e785d3");
            public static readonly Guid CoreParkingConcurrencyThreshold = new("2430ab6f-a520-44a2-9601-f7f23b5134b1");
            public static readonly Guid CoreParkingConcurrencyHeadroomThreshold = new("f735a673-2066-4f80-a0c5-ddee0cf1bf5d");
            public static readonly Guid CoreParkingIncreasePolicy = new("c7be0679-2817-4d69-9d02-519a537ed0c6");
            public static readonly Guid CoreParkingIncreaseTime = new("2ddd5a84-5a71-437e-912a-db0b8c788732");
            public static readonly Guid CoreParkingDecreasePolicy = new("71021b41-c749-4d21-be74-a00f335d582b");
            public static readonly Guid CoreParkingDecreaseTime = new("dfd10d17-d5eb-45dd-877a-9a34ddd15c82");
            public static readonly Guid CoreParkingOverutilizationThreshold = new("943c8cb6-6f93-4227-ad87-e9a3feec08d1");
            public static readonly Guid CoreParkingSoftParkLatency = new("97cfac41-2217-47eb-992d-618b1977c907");
            public static readonly Guid InitialUnparkedPerformanceClass1 = new("1facfc65-a930-4bc5-9f38-504ec097bbc0");

            public static readonly Guid LatencySensitivityHintPerformance = new("619b7505-003b-4e82-b7a6-4dd29c300971");
            public static readonly Guid LatencySensitivityHintPerformanceClass1 = new("619b7505-003b-4e82-b7a6-4dd29c300972");
            public static readonly Guid LatencySensitivityHintMinUnparkedCores = new("616cdaa5-695e-4545-97ad-97dc2d1bdd88");
            public static readonly Guid LatencySensitivityHintMinUnparkedCoresClass1 = new("616cdaa5-695e-4545-97ad-97dc2d1bdd89");

            public static readonly Guid IdleDisable = new("5d76a2ca-e8c0-402f-a133-2158492d58ad");
            public static readonly Guid IdlePromoteThreshold = new("7b224883-b3cc-4d79-819f-8374152cbe7c");
            public static readonly Guid IdleDemoteThreshold = new("4b92d758-5a24-4851-a470-815d78aee119");
            public static readonly Guid IdleThresholdScaling = new("6c2993b0-8f48-481f-bcc6-00dd2742aa06");
            public static readonly Guid IdleStateMaximum = new("9943e905-9a30-4ec1-9b99-44dd3b76f7a2");
            public static readonly Guid IdleCheckTime = new("c4581c31-89ab-4597-8e2b-9c9cab440e6b");

            public static readonly Guid AllowThrottleStates = new("3b04d4fd-1cc7-4f23-ab1c-d1337819c4bb");
            public static readonly Guid DutyCycling = new("4e4450b3-6179-4e91-b8f1-5bb9938f81a1");
            public static readonly Guid HeterogeneousPolicy = new("7f2f5cfa-f10c-4823-b5e1-e93ae85f46b5");
            public static readonly Guid MinimumProcessorState = new("893dee8e-2bef-41e0-89c6-b55d0929964c");
            public static readonly Guid MinimumProcessorStateClass1 = new("893dee8e-2bef-41e0-89c6-b55d0929964d");
            public static readonly Guid MaximumProcessorState = new("bc5038f7-23e0-4960-96da-33abaf5935ec");
            public static readonly Guid MaximumProcessorStateClass1 = new("bc5038f7-23e0-4960-96da-33abaf5935ed");
            public static readonly Guid MaximumFrequency = new("75b0ae3f-bce0-45a7-8c89-c9611c25e100");
            public static readonly Guid MaximumFrequencyClass1 = new("75b0ae3f-bce0-45a7-8c89-c9611c25e101");

            public static readonly Guid HeterogeneousPerformanceFloorClass0UnparkedClass1 = new("fddc842b-8364-4edc-94cf-c17f60de1c80");
            public static readonly Guid HeterogeneousPerformanceDecreaseTimeClass1 = new("7f2492b6-60b1-45e5-ae55-773f8cd5caec");
            public static readonly Guid HeterogeneousPerformanceDecreaseThresholdClass1 = new("f8861c27-95e7-475c-865b-13c0cb3f9d6b");
            public static readonly Guid HeterogeneousPerformanceIncreaseTimeClass1 = new("4009efa7-e72d-4cba-9edf-91084ea8cbc3");
            public static readonly Guid HeterogeneousPerformanceIncreaseThresholdClass1 = new("b000397d-9b0b-483d-98c9-692a6060cfbf");
            public static readonly Guid HeterogeneousThreadSchedulePolicy = new("93b8b6dc-0698-4d1c-9ee4-0644e900c85d");
            public static readonly Guid HeterogeneousShortRunningThreadSchedulePolicy = new("bae08b81-2d5e-4688-ad6a-13243356654b");

            public static readonly Guid SystemCoolingPolicy = new("94d3a615-a899-4ac5-ae2b-e4d8f634367f");

        }

        public static class Presence
        {
            public static readonly Guid StandbyBudgetPercent = new("9fe527be-1b70-48da-930d-7bcf17b44990");
            public static readonly Guid StandbyBudgetGracePeriod = new("60c07fe1-0556-45cf-9903-d56e32210242");
            public static readonly Guid StandbyReserveTime = new("468fe7e5-1158-46ec-88bc-5b96c9e44fd0");
            public static readonly Guid StandbyReserveGracePeriod = new("c763ee92-71e8-4127-84eb-f6ed043a3e3d");
            public static readonly Guid StandbyResetPercentage = new("49cb11a5-56e2-4afb-9d38-3df47872e21b");
            public static readonly Guid NonSensorInputPresenceTimeout = new("5adbbfbc-074e-4da1-ba38-db8b36b2c8f3");
            public static readonly Guid UserPresencePredictionMode = new("82011705-fb95-4d46-8d35-4042b1d20def");
        }

        public static class Media
        {
            public static readonly Guid WhenSharingMedia = new("03680956-93bc-4294-bba6-4e0f09bb717f");
            public static readonly Guid VideoPlaybackQualityBias = new("10778347-1370-4ee0-8bbd-33bdacaade49");
            public static readonly Guid WhenPlayingVideo = new("34c7b99f-9a6d-4b3c-8dc7-b6693b78cef4");
        }

        public static class Graphics
        {
            public static readonly Guid GpuPreferencePolicy = new("dd848b2a-8a5d-4451-9ae2-39cd41658f6c");
        }
    }
}
