using System;

namespace Assets.Scripts.Objects.Commanders {
    internal class Player : Commander {

        internal Player(string name, Provenance provenance, int alliance, string cameraID, bool replace = false)
                    : base($"Player_n{name}_p{provenance}_a{alliance}", provenance, alliance, cameraID, replace) {

            if (cameraID.Length <= "Camera_Player_".Length)
                throw new AccessViolationException($"The specified camera is invalid for the type \"{typeof(Player)}\"");

        }
    }
}