using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Commanders {
    internal abstract partial class Commander {

        internal protected static readonly Dictionary<string, Commander> activeCommanders = new();

        /// <summary> The origin of this <see cref="Commander"/> </summary>
        internal enum Provenance {
            MASTER, //!? Controls everything!
            //TODO: Figure out good names
            Provenance1, Provenance2, Provenance3
        }


        internal string name { get; }
        internal Provenance provenance { get; }
        internal protected int alliance { get; protected set; }
        internal string cameraID { get; }

        /// <summary> <see cref="Commander"/> controls <see cref="Entities.Entity"/> and other related stuff </summary>
        protected Commander(
                string name,
                Provenance provenance,
                int alliance,
                string cameraID = default,
                bool replace = false) {

            if (activeCommanders.ContainsKey(name) && !replace)
                throw new System.NotSupportedException(
                    $"Commander \"{name}\" already exists."
                    + " Replacing commander is not permitted."
                    + " Use the replace parameter to confirm replacing current commander with the same name.");

            this.name = name;
            this.provenance = provenance;
            this.alliance = alliance;

            GameObject camera = GameObject.Find(cameraID);
            if (camera != null) this.cameraID = cameraID;


            activeCommanders[this.name] = this;
        }
    }
}
