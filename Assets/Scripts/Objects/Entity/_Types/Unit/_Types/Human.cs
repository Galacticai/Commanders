using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Entity._Types.Unit._Types {

    internal abstract class Human : Unit {

        internal record Defaults {
            internal const bool something = false;
        }


        internal Human(ref GameObject gameObject, float health, List<Territory> territoryAllowed)
                : base(ref gameObject, health, new() { Territory.Land }) {

        }
    }

}