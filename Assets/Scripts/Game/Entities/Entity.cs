using Assets.Scripts.Game.Commanders;
using Assets.Scripts.Game.Entities.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Entities {
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
        internal GameObject Target => Command.Target;
        internal Commander Commander => Command.Commander;
        internal Territory Territory => Stats.Get<Territory>();
        internal Health Health => Stats.Get<Health>();
        #endregion

        /// <summary> This <see cref="Entity"/>'s properties </summary>
        protected internal StatDictionary Stats { get; protected set; }

        internal Entity(Command command, StatDictionary stats = null) {
            Stats = stats ?? new(command);
        }
    }
}
