using Assets.Scripts.Game.Commanders;
using UnityEngine;

namespace Assets.Scripts.Game.Entities.Stats {
    internal class Command : Stat {
        #region Shortcuts
        internal GameObject GameObject => GameObject.Find(GameObjectName);
        internal bool GameObject_Exists => GameObject != null;
        #endregion

        private string GameObjectName { get; }
        internal Commander Commander { get; set; }
        internal Command(string gameObject_name, Commander commander = null) {
            if (string.IsNullOrEmpty(gameObject_name))
                throw new System.ArgumentNullException("GameObject name must have a value");
            GameObjectName = gameObject_name;
            if (!GameObject_Exists)
                throw new MissingReferenceException("Target GameObject was not found");
            Commander = commander ?? Commanders.Computers.Computer.MASTER;
        }
    }
}
