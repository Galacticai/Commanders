using Commanders.Assets.Scripts.Lib;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Commanders.Assets.Scripts.Game.Commanders {

    internal class Commander_Json {
        internal record Default {
            internal static readonly string directory = System.IO.Path.Combine(Paths.ThisApplicationData, "Skirmish");
            internal const string FILENAME = "Commanders.json";
            internal static readonly string path = System.IO.Path.Combine(directory, FILENAME);
        }
        internal string Path { get; }
        internal string Json { get; }
        internal Commander_Json(params Commander[] commanders) {
            if (commanders.Length > 8) Array.Resize(ref commanders, 8);
            Json = JsonConvert.SerializeObject(commanders);
            Filesystem.Prepare_ThisApplicationData();
            File.WriteAllText(Path, Json);
        }
    }
}
