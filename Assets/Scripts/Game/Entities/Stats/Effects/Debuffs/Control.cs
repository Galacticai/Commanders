using Assets.Scripts.Game.Commanders;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game.Entities.Stats.Effects.Debuffs {
    /// <summary> Let another <see cref="Commander"/> take over the <see cref="Entity"/> </summary>
    internal class Control : Debuff {

        internal Dictionary<Type, object> Modified => default;

        internal override dynamic Get<IStat>(IStat stat) => default;

        internal Commander Commander { get; set; }
        internal Control(Commander commander, bool active = true)
                : base(isUnique: true, active) {
            Commander = commander;
        }
    }
}
