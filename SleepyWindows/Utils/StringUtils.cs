using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.JohnCook.dotnet.SleepyWindows.Utils
{
    public static class StringUtils
    {
        /// <summary>
        /// Converts a <see cref="Windows.Win32.System.Power.POWER_ACTION"/> to a description string.
        /// </summary>
        /// <param name="action">A <see cref="Windows.Win32.System.Power.POWER_ACTION"/>.</param>
        /// <returns>A string representation of the <see cref="Windows.Win32.System.Power.POWER_ACTION"/>.</returns>
        internal static string PowerActionToDescription(Windows.Win32.System.Power.POWER_ACTION action)
        {
            return action switch
            {
                Windows.Win32.System.Power.POWER_ACTION.PowerActionNone => "None",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionSleep => "Sleep",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionHibernate => "Hibernate",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionShutdown => "Shutdown",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionShutdownOff => "Shutdown and power off",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionShutdownReset => "Shutdown and reset",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionWarmEject => "Eject",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionDisplayOff => "Turn off display",
                Windows.Win32.System.Power.POWER_ACTION.PowerActionReserved => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Converts a <see cref="Guid"/> to an effective power mode string.
        /// </summary>
        /// <param name="powerPolicyGuid">A <see cref="Guid"/> representing a power policy.</param>
        /// <returns>A string description for the effective power mode.</returns>
        public static string GetEffectivePowerModeString(Guid powerPolicyGuid)
        {
            const string powerSaverProfile = "a1841308-3541-4fab-bc81-f71556f20b4a";
            const string balancedProfile = "381b4222-f694-41f0-9685-ff5bb260df2e";
            const string highPerformanceProfile = "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";
            return powerPolicyGuid.ToString() switch
            {
                powerSaverProfile => "Power Saver",
                balancedProfile => "Balanced",
                highPerformanceProfile => "High Performance",
                _ => "Unknown"
            };
        }

        /// <summary>
        /// Converts a <see cref="Windows.Win32.System.Power.EFFECTIVE_POWER_MODE"/> to an effective power mode string.
        /// </summary>
        /// <param name="effectivePowerMode">A Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.</param>
        /// <returns>A string description for the effective power mode.</returns>
        internal static string GetEffectivePowerModeString(Windows.Win32.System.Power.EFFECTIVE_POWER_MODE effectivePowerMode)
        {
            return effectivePowerMode switch
            {
                Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.EffectivePowerModeBatterySaver => "Battery Saver",
                Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.EffectivePowerModeBetterBattery => "Better Battery",
                Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.EffectivePowerModeBalanced => "Balanced",
                Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.EffectivePowerModeHighPerformance => "High Performance",
                Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.EffectivePowerModeMaxPerformance => "Max Performance",
                Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.EffectivePowerModeGameMode => "Game Mode",
                Windows.Win32.System.Power.EFFECTIVE_POWER_MODE.EffectivePowerModeMixedReality => "Mixed Reality",
                _ => throw new NotImplementedException()
            };
        }
    }
}
