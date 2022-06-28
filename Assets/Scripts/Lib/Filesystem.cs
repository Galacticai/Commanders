using System.IO;

namespace Assets.Scripts.Lib {
    public static class Filesystem {
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

            if (!File.Exists(Path.Combine(directory, name)))
                return name;

            string fileX = $"{Path.GetFileName(name)} ({i}).{Path.GetExtension(name)}";
            return getUnusedName(fileX, directory, ++i);
        }
    }
}