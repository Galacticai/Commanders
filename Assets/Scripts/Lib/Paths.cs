/// —————————————————————————————————————————————
//? 
//!? 📜 Paths.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: 
//      + (Galacticai) Platforms/Platform.cs
//? 
/// —————————————————————————————————————————————

using Commanders.Assets.Scripts.Lib.Platforms;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Commanders.Assets.Scripts.Lib {
    /// <summary> Various tools for path (filesystem) manipulation </summary>
    public static class Paths {
        #region Extra

        public enum PathType {
            None, File, Directory
        }
        public enum PathOS {
            None, Windows, Unix
        }
        public record PathRegex {
            public const string WINDOWS
                = @"^(?<drive>[a-z]:)?(?<path>(?:[\\]?(?:[\w !#()-]+|[.]{1,2})+)*[\\])?(?<filename>(?:[.]?[\w !#()-]+)+)?[.]?$";
            public const string UNIX
                = @"^(/[^/ ]*)+/?$";
        }

        #endregion


        #region Properties

        /// <returns> (ApplicationData) </returns>
        public static string ApplicationData
            => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        /// <returns> (ApplicationData)/(AppName) </returns>
        public static string ThisApplicationData
            => Path.Combine(ApplicationData, Assembly.GetExecutingAssembly().GetName().Name);

        #endregion


        #region Methods

        public static void Create_ThisApplicationData()
            => new DirectoryInfo(ThisApplicationData).Create();

        /// <returns> <list type="bullet">
        /// <item> Windows: '\' </item> <item> Linux: '/' </item>
        /// </list> </returns>
        public static char GetPathSlash()
            => Platform.RunningWindows ? '\\' : '/';
        public static char GetPathSlash(PathOS pathOS)
            => pathOS == PathOS.Windows ? '\\' : '/';

        public static PathType GetPathType(this string path) {
            if (File.Exists(path))
                return PathType.File;
            else if (Directory.Exists(path))
                return PathType.Directory;
            else return PathType.None;
        }
        public static PathOS GetPathOS(this string path) {
            if (Regex.IsMatch(path, PathRegex.WINDOWS))
                return PathOS.Windows;
            else if (Regex.IsMatch(path, PathRegex.UNIX))
                return PathOS.Unix;
            else return PathOS.None;
        }

        public static bool PathExists(this string path)
            => path.GetPathType() != PathType.None;
        public static bool PathIsValid(this string path)
            => Regex.IsMatch(path, PathRegex.WINDOWS)
            || Regex.IsMatch(path, PathRegex.UNIX);
        public static bool PathIsSymbolic(this FileInfo fileInfo)
            => fileInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
        public static string[] GetPathParts(this string path)
            => GetPathParts(path, path.GetPathOS());
        public static string[] GetPathParts(this string path, PathOS pathOS)
            => pathOS switch {
                PathOS.Windows => path.Split('\\'),
                PathOS.Unix => path.Split('/'),
                _ => new[] { path }
            };

        public static bool DeletePath(string path) {
            if (!path.PathExists()) return true;
            //? invalid path: cannot delete
            if (!path.PathIsValid()) return false;

            PathType pathType = path.GetPathType();
            if (pathType == PathType.File)
                File.Delete(path);
            else if (pathType == PathType.Directory)
                Directory.Delete(path);
            return false;
        }

        /// <returns><list type="bullet">
        /// <item> "path/to/file (index).extension"</item>
        /// <item> "path/to/file (GUID).extension" if exceeding 20 tries </item>
        /// </list></returns>
        public static string GetUnusedPath(this string path)
            => GetUnusedPath(path, 20);
        /// <returns><list type="bullet">
        /// <item> "path/to/file (index).extension"</item>
        /// <item> "path/to/file (GUID).extension" if exceeding <paramref name="maxTries"/> </item>
        /// </list></returns>
        public static string GetUnusedPath(this string path, int maxTries) {
            if (!path.PathExists() || !path.PathIsValid())
                return path;
            string directory = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string dot_extension = Path.GetExtension(path) ?? string.Empty;
            string newPath = string.Empty;
            for (int i = 1; i <= maxTries; ++i) {
                if (!newPath.PathExists()) return newPath;
                newPath = Path.Combine(directory, $"{name} ({i}){dot_extension}");
            }
            //? not returned in the loop = failed to get a unique name
            //?     > use GUID instead of numbers
            return Path.Combine(directory, $"{name} ({Guid.NewGuid()}){dot_extension}");
        }

        #endregion

    }
}
