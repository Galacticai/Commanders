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

        public static string AppData
            => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string this_AppData()
            => Path.Combine(AppData, Assembly.GetExecutingAssembly().GetName().Name);
        public static string prepare_this_AppData()
            => prepareDir(this_AppData());

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
