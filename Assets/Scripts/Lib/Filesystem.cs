using System;
using System.IO;
using System.Reflection;

namespace Assets.Scripts.Lib {

    public static class Filesystem {
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


        #region Shortcuts

        /// <returns> (ApplicationData) </returns>
        public static string ApplicationData
            => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        /// <returns> (ApplicationData)/(AppName) </returns>
        public static string ThisApplicationData
            => Path.Combine(ApplicationData, Assembly.GetExecutingAssembly().GetName().Name);
        public static string Prepare_ThisApplicationData()
            => CreateTree(ThisApplicationData);

        /// <summary> Path slash ('/' or '\') character that's valid for the current OS </summary>
        /// <returns> <list type="bullet">
        /// <item> Windows: '\' </item>
        /// <item> Linux: '/' </item>
        /// </list> </returns>
        public static char PathSlash
            => Platform.RunningWindows ? '\\' : '/';

#pragma warning disable IDE1006 // Naming Styles
        /// <summary> Just a shortcut for <see cref="Environment.NewLine"/> </summary>
        /// <returns> Line break
        /// <br/> <list type="bullet">
        /// <item> Windows: "\r\n" </item>
        /// <item> Linux: "\n" </item>
        /// </list> </returns>
        public static string n => Environment.NewLine;
#pragma warning restore IDE1006 // Naming Styles

        #endregion


        /// <summary> Check whether <paramref name="input"/> contains a line break for any OS ('\n') </summary>
        public static bool Contains_LineBreak(this string input)
            => input.Contains('\n');
        /// <summary> Check whether <paramref name="input"/> contains a line break that's valid on the current OS (<see cref="n"/>) </summary>
        public static bool Contains_LineBreak_currentOS(this string input)
            => input.Contains(n);


        public static PathOS GetPathOS(string path) {
            //? Should not contain a line break 
            if (path.Contains_LineBreak())
                return PathOS.None;

            //? Matches an OS path regex
            if (Regex.IsMatch(path, PathRegex.WINDOWS))
                return PathOS.Windows;
            else if (Regex.IsMatch(path, PathRegex.UNIX))
                return PathOS.Unix;

            //? Doesn't match an OS path regex
            return PathOS.None;
        }


        public static PathType getPathType(this string path) {
            if (File.Exists(path)) return PathType.File;
            else if (Directory.Exists(path)) return PathType.Directory;
            else return PathType.None;
        }
        public static bool exists(this string path)
            => path.getPathType() != PathType.None;

        public static bool delete(this string path) {
            PathType pathType = path.getPathType();
            if (pathType == PathType.File)
                File.Delete(path);
            else if (pathType == PathType.Directory)
                Directory.Delete(path);
            return pathType != PathType.None;
        }

        public static string prepareDir(this string path) {
            string[] parts = path.Split('/');
            string currentPath = "";
            for (int i = 0; i < parts.Length; i++) {
                currentPath += parts[i] + "/";
                if (!currentPath.exists())
                    Directory.CreateDirectory(currentPath);
            }
            return currentPath;
        }

        //TODO: TEST file name accuracy
        /// <summary> Generates file name with numbers if it already exists in the target <paramref name="directory"/> </summary>
        /// <param name="name"> File name </param>
        /// <param name="directory"> Target directory</param>
        /// <param name="i"> Current file name index </param>
        /// <returns> <list type="bullet">
        /// <item> <paramref name="name"/> — if <paramref name="directory"/> doesn't exist </item>
        /// <item> <paramref name="name"/> — if <paramref name="name"/> doesn't exist in the <paramref name="directory"/> </item>
        /// <item> "NameWithoutExtension (<paramref name="i"/>).extension" — if <paramref name="name"/> exist in the <paramref name="directory"/></item>
        /// </list> </returns>
        public static string getUnusedName(string name, string directory, int i = 1) {
            if (!Directory.Exists(directory))
                //throw new IOException($"Target directory was not found ({directory})");
                return name;

            if (!Path.Combine(directory, name).exists())
                return name;

            string fileX = $"{Path.GetFileName(name)} ({i}).{Path.GetExtension(name)}";
            return getUnusedName(fileX, directory, ++i);
        }
    }
}
