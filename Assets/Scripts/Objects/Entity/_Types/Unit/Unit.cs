using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Entity._Types.Unit {

    internal abstract class Unit : Entity {

        internal record Default {
            internal const float range = 5;
            internal const float vision_to_range_Factor = 0.2f;
            internal const float powerCritical_Factor = 1.5f;
        }

        internal protected float power { get; protected set; }
        internal protected float power_critical { get; protected set; }
        internal protected float range { get; protected set; }

        internal protected override float update_vision() {
            base.update_vision();
            this.update_range();
            return this.vision;
        }

        internal protected virtual float update_range() {
            this.range
                = Default.range
                + (base.vision * Default.vision_to_range_Factor);
            return this.range;
        }

        /// <summary> A tank, an airplane, a soldier,
        /// or any game entity that acts similarly </summary>
        internal Unit(
                ref GameObject gameObject,
                float health,
                List<Territory> territoryAllowed,
                List<Stat.Stat> stats)
                    : base(ref gameObject, health, territoryAllowed, stats) {
            this.power = power;
            this.power_critical = power * Default.powerCritical_Factor;
            this.update_range();
        }
    }
}
