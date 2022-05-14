using UnityEngine;

namespace Assets.Objects.Entity.Unit {

    /// <summary> A tank, an airplane, a soldier,
    /// or any game entity that acts similarly </summary>
    internal class Unit : Entity {

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        internal record Default {
            internal const float range = 5;
            internal const float vision_to_range_Factor = 0.2f;
            internal const float powerCritical_Factor = 1.5f;
        }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        internal protected float power { get; protected set; }
        internal protected float power_critical { get; protected set; }
        internal protected float range { get; protected set; }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        internal protected virtual float update_vision() {
            base.update_vision();
            this.update_range();
            return this.vision;
        }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        internal protected virtual float update_range() {
            this.range
                = Default.range
                + (base.vision * Default.vision_to_range_Factor);
            return this.range;
        }

        internal Unit(
                GameObject gameObject,
                float health, float power,
                Territory territory,
                params Territory[] territoryAllowed)
                    : base(gameObject, health, territory, territoryAllowed) {
            this.power = power;
            this.power_critical = power * Default.powerCritical_Factor;
            this.update_range();
        }
    }
}
