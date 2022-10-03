namespace Commanders.Assets.Scripts.Game.Commanders {
    internal abstract partial class Commander {
        //? cameraID is null when not found by GameObject.Find(string ID)
        /// <summary> This <see cref="Commander"/> was created on this client
        /// <br/> ✅ Can access <see cref="UnityEngine.Camera"/> using <see cref="cameraID"/> </summary>
        internal bool IsMe
            => CameraID != null;

        /// <summary> This <see cref="Commander"/> is the MASTER </summary>
        internal bool IsMASTER
            => Name == "MASTER" || Provenance == Provenance.MASTER;
        /// <summary> This <see cref="Commander"/> is controlled by AI </summary>
        internal bool IsComputer
            => Name.Contains("Computer");
        /// <summary> This <see cref="Commander"/> is controlled by humen </summary>
        internal bool IsPlayer
            => Name.Contains("Player");

        internal bool IsAlliesWith(Commander commander)
            => Alliance == commander.Alliance;
        internal bool IsAlliesWith(int alliance)
            => Alliance == alliance;

    }
}
