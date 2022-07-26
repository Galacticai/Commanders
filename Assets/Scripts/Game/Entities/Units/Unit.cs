
using Assets.Scripts.Game.Entities.Stats;
using System.Collections.Generic;

namespace Assets.Scripts.Game.Entities.Units {

    internal abstract class Unit : Entity {

        /// <summary> A tank, an airplane, a soldier,
        /// or any game entity that acts similarly </summary>
        internal Unit(
                string commanderID,
                string gameObject_name,
                List<Territory> territoryAllowed,
                StatDictionary stats)
                    : base(commanderID, gameObject_name, territoryAllowed, stats) { }
    }
}
