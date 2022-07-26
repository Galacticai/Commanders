namespace Assets.Scripts.Game.Commanders {
    internal abstract partial class Commander {
        //? cameraID is null when not found by GameObject.Find(string ID)
        /// <summary> This <see cref="Commander"/> was created on this client
        /// <br/> ✅ Can access <see cref="UnityEngine.Camera"/> using <see cref="cameraID"/> </summary>
        internal bool isMe => this.cameraID != null;

        /// <summary> This <see cref="Commander"/> is the MASTER </summary>
        internal bool isMASTER => this.name == "MASTER";
        /// <summary> This <see cref="Commander"/> is controlled by AI </summary>
        internal bool isComputer => this.name[.."Computer".Length] == "Computer";
        /// <summary> This <see cref="Commander"/> is controlled by humen </summary>
        internal bool isPlayer => this.name[.."Player".Length] == "Player";

        internal bool isAlliesWith(Commander commander) => this.alliance == commander.alliance;
        internal bool isAlliesWith(int alliance) => this.alliance == alliance;

    }
}
