using Assets.Scripts.Objects.Entities.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Entities {

    internal abstract partial class Entity {

        /// <summary> Places where the <see cref="Entity"/> can stay alive </summary>
        internal enum Territory {
            Land, Water, Air
        }


        /// <summary> Available <see cref="Territory"/>'s that can be used by this <see cref="Entity"/> </summary>
        internal protected List<Territory> territoryAllowed { get; }

        /// <summary> Unity's <see cref="GameObject"/> of this <see cref="Entity"/> </summary>
        internal protected string gameObject_name { get; }

        /// <summary> Current <see cref="Territory"/> used by this <see cref="Entity"/> </summary>
        internal protected Territory territory { get; protected set; }

        internal protected StatDictionary stats { get; set; }

        /// <summary> Simple <see cref="string"/> alias derived from <see cref="gameObject"/>.name </summary>
        internal protected string name { get; protected set; }

        /// <summary> The <see cref="Commander"/> who owns and controls this <see cref="Entity"/> </summary>
        internal protected string commanderID { get; protected set; }

        /// <summary> <see cref="GameObject"/> with extra sauce
        /// <br/><br/> Note:  The first item of <paramref name="territoryAllowed"/> will be <see cref="this.territory"/>
        /// </summary>
        internal Entity(
                string commanderID,
                string gameObject_name,
                List<Territory> territoryAllowed,
                StatDictionary stats) {
            this.name = gameObject_name;
            this.commanderID = commanderID;
            this.stats = stats;

            if (territoryAllowed.Count == 0)
                throw new System.ArgumentOutOfRangeException("territoryAllowed must contain at least 1 item.");
            else this.territoryAllowed.TrimExcess();
            this.territory = territoryAllowed[0];
            this.territoryAllowed = territoryAllowed;
        }
    }
}
