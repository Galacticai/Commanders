using Commanders.Assets.Scripts.Lib.Math.Numerics;
using System.Collections.Generic;
using UnityEngine;

namespace Commanders.Assets.Scripts.Game.Commanders {
    /// <summary> The origin of a <see cref="Commander"/> </summary>
    internal enum Provenance {
        MASTER, //!? Controls everything!
                //TODO: Figure out good names
        Provenance1, Provenance2, Provenance3
    }
    internal abstract partial class Commander {
        internal static readonly Dictionary<string, Commander> ActiveCommanders = new();

        internal string Name { get; }
        internal Provenance Provenance { get; }
        private int _Alliance;
        protected internal int Alliance {
            get => _Alliance;
            protected set
                => _Alliance = Provenance == Provenance.MASTER ? -1 : value.Positive();
        }
        internal string CameraID { get; }

        /// <summary> <see cref="Commander"/> controls <see cref="Entities.Entity"/> and other related stuff </summary>
        private protected Commander(
                string name,
                Provenance provenance,
                int alliance,
                string cameraID = default,
                bool replace = false) {

            if (ActiveCommanders.ContainsKey(name) && !replace)
                throw new System.NotSupportedException(
                    $"Commander \"{name}\" already exists."
                    + " Replacing commander is not permitted."
                    + " Use the replace parameter to confirm replacing current commander with the same name.");

            Name = name;
            Provenance = provenance;
            Alliance = alliance;

            if (cameraID != default) {
                GameObject camera = GameObject.Find(cameraID);
                if (camera != null) CameraID = cameraID;
            }

            ActiveCommanders[Name] = this;
        }
    }
}
