using Commanders.Assets.Scripts.Game.Commanders;
using UnityEngine;

namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    internal class Command : Attribute {
        #region Shortcuts
        internal GameObject GameObject => GameObject.Find(GameObjectName);
        internal bool GameObject_Exists => GameObject != null;
        #endregion

        private string GameObjectName { get; }
        internal Commander Commander { get; set; }
        internal Command(Entity parent_Entity, string gameObject_name, Commander commander = null)
                    : base(parent_Entity) {
            if (string.IsNullOrEmpty(gameObject_name))
                throw new System.ArgumentNullException("GameObject name must have a value");
            GameObjectName = gameObject_name;
            if (!GameObject_Exists)
                throw new MissingReferenceException("Target GameObject was not found");
            Commander = commander ?? Commanders.Computers.Computer.MASTER;
        }
    }
}
