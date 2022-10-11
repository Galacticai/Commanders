using Commanders.Assets.Scripts.Game.Commanders;
using Commanders.Assets.Scripts.Game.Entities.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace Commanders.Assets.Scripts.Game.Entities {
    /// <summary> Bridge between the <see cref="Entities.Entity"/> backend and Unity's <see cref="MonoBehaviour"/> </summary>
    internal class UnityEntity : MonoBehaviour {
        internal Entity Entity = null;
    }

    /// <summary> Behavior and properties of a <see cref="GameObject"/> that's manipulated by a <see cref="Commanders.Commander"/> </summary>
    internal abstract class Entity {
        internal static readonly Dictionary<string, Entity> ActiveEntities = new();

        #region Shortcuts
        //!? Always present in StatDictionary
        internal Command Command => Stats.Get<Command>();
        internal GameObject GameObject => Command.GameObject;
        internal bool Exists => Command.GameObject_Exists;
        internal Commander Commander => Command.Commander;
        internal Territory Territory => Stats.Get<Territory>();
        internal Health Health => Stats.Get<Health>();
        #endregion

        #region Methods
        private protected GameObject Create<TEntity>(TEntity entity, Vector3 location, params Component[] components)
                    where TEntity : Entity {
            GameObject gameObject = new();
            //TODO: move Human.TestHuman code to this 
            throw new System.NotImplimentedException();
        }
        #endregion

        /// <summary> Properties of this <see cref="Entity"/> </summary>
        protected internal AttributeDictionary Attributes { get; protected set; }

        private protected Entity(Command command, StatDictionary stats = null) {
            Stats = stats ?? new(command);
            ActiveEntities[Command.GameObject.name] = this;
        }
    }
}
