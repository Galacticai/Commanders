using UnityEngine;

namespace Assets.Objects.Entity.Unit {

    /// <summary> A tank, an airplane, a soldier,
    /// or any game entity that acts similarly </summary>
    internal class Unit : Entity {

        internal record Default {
            internal const float range = 5;
            internal const float vision_to_range_factor = 0.2f;
            internal const float power_criticalMultiplier = 1.5f;
        }

        internal protected float power { get; protected set; }
        internal protected float power_critical { get; protected set; }
        internal protected float range { get; protected set; }

        internal protected virtual float update_vision() {
            base.update_vision();
            this.update_range();
            return this.vision;
        }
        internal protected virtual float update_range() {
            this.range
                = Default.range
                + (base.vision * Default.vision_to_range_factor);
            return this.range;
        }

        internal Unit(
                GameObject gameObject,
                float health, float power,
                Territory territoryOption,
                params Territory[] territoryOptionsAllowed)
                    : base(gameObject, health, territoryOption, territoryOptionsAllowed) {
            this.power = power;
            this.power_critical = power * Default.power_criticalMultiplier;
            this.update_range();
        }
    }

}