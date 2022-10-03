/// —————————————————————————————————————————————
//? 
//!? 📜 Platform.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + (Galacticai) WindowsVersion.cs
//? 
/// —————————————————————————————————————————————

using System;
using System.Runtime.InteropServices;

namespace Commanders.Assets.Scripts.Lib.Platforms {

    /// <summary> Determine current platform information </summary>
    public static class Platform {

        /// <summary> Indicates whether the current platform is supported by ScreenFIRE (Linux or Windows) </summary>
        internal static bool IsSupported => RunningLinux | RunningWindows;

        /// <summary> Indicate if the current platform is Linux based </summary>
        public static bool RunningLinux
            => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);


        /// <summary> <see cref="true"/> if running Win32NT base (Windows NT and above) </summary>
        public static bool RunningWindows
            => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);


        /// <returns> <see cref="true"/> if running Windows 10 (22000 > Build >= 10240) </returns>
        public static bool RunningWindows10() {
            if (!RunningWindows) return false;
            bool isAbove_Win10 = Environment.OSVersion.Version.Build >= WindowsVersion.Windows10.Build;
            bool isBelow_Win11 = Environment.OSVersion.Version.Build < WindowsVersion.Windows11.Build;
            return isAbove_Win10 && isBelow_Win11;
        }
        /// <returns> <see cref="true"/> if running Windows 11 (Build >= 22000) </returns>
        public static bool RunningWindows11_orAbove() {
            if (!RunningWindows) return false;
            bool isAbove_Win11 = Environment.OSVersion.Version.Build >= WindowsVersion.Windows11.Build;
            return isAbove_Win11;
        }

    }
}
