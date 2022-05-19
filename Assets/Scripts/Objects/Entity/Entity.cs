using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Entity {

    internal abstract partial class Entity {

        /// <summary> Places where the <see cref="Entity"/> can stay alive </summary>
        internal enum Territory {
            Land, Water, Air
        }


        /// <summary> Available <see cref="Territory"/>'s that can be used by this <see cref="Entity"/> </summary>
        internal protected List<Territory> territoryAllowed { get; private set; }

        /// <summary> Unity's <see cref="GameObject"/> of this <see cref="Entity"/> </summary>
        internal protected GameObject gameObject { get; private set; }

        /// <summary> Current <see cref="Territory"/> used by this <see cref="Entity"/> </summary>
        internal protected Territory territory { get; protected set; }

        internal protected Dictionary<System.Type, Stat.Stat> stats { get; set; }

        /// <summary> Simple <see cref="string"/> alias derived from <see cref="gameObject"/>.name </summary>
        internal protected string name { get; protected set; }

        /// <summary> <see cref="GameObject"/> with extra sauce
        /// <br/><br/> Note:  The first item of <paramref name="territoryAllowed"/> will be <see cref="this.territory"/>
        /// </summary>
        internal Entity(
                ref GameObject gameObject,
                List<Territory> territoryAllowed,
                Dictionary<System.Type, Stat.Stat> stats) {
            this.gameObject = gameObject;
            this.name = this.gameObject.name;
            this.stats = stats;

            if (territoryAllowed.Count == 0)
                throw new System.ArgumentOutOfRangeException("territoryAllowed must contain at least 1 item.");
            else this.territoryAllowed.TrimExcess();
            this.territory = territoryAllowed[0];
            this.territoryAllowed = territoryAllowed;
        }
    }
}
