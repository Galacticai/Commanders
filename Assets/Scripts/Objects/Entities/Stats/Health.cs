using System;

namespace Assets.Scripts.Objects.Entities.Stats {

    internal sealed class Health : Stat {
        /// <returns> <see cref="health"/> &lt; <see cref="healthTotal"/> </returns>
        internal bool isDamaged
            => this.health < this.healthTotal;
        /// <returns> <see cref="health"/> == <see cref="healthTotal"/> </returns>
        internal bool isHealed
            => this.health == this.healthTotal;
        /// <returns> Ratio of <see cref="health"/> relative to <see cref="healthTotal"/> (0~1) </returns>
        internal float health_ratio
            => (this.health / this.healthTotal);
        /// <returns> Precentage of <see cref="health"/> relative to <see cref="healthTotal"/> (0~100) </returns>
        internal float health_percent
            => this.health_ratio * 100;


        private float health_delta(float delta) {
            if (delta == 0) return this.health;

            float health_new = this.health + delta;

            //! Never let health be negative or above total
            // to avoid any unexpected behavior
            if (health_new > this.healthTotal)
                this.restore_health();
            else if (health_new <= 0)
                this.kill();

            this.health += delta;
            return this.health;
        }

        /// <summary> Increase <see cref="health"/> directly using <paramref name="amount"/> </summary>
        /// <returns> Final <see cref="health"/> </returns>
        internal float heal(float amount)
            => this.health_delta(Math.Abs(amount));

        /// <summary> Decrease <see cref="health"/> directly using <paramref name="amount"/> </summary>
        /// <returns> Final <see cref="health"/> </returns>
        internal float hurt(float amount)
            => this.health_delta(-Math.Abs(amount));

        /// <summary> Decrease <see cref="health"/> using <see cref="Damage"/> </summary>
        /// <returns> Final <see cref="health"/> </returns>
        internal float hurtBy(Weapon weapon)
            => this.hurt(weapon.damage.amount);

        /// <summary> Decrease <see cref="health"/> using <see cref="Entity"/>.damage (if present) </summary>
        /// <returns> Final <see cref="health"/> </returns>
        internal float hurtBy(Entity entity) {
            entity.stats.TryGetValue(typeof(Weapon), out Stat weapon);
            if (weapon != null)
                this.hurtBy((Weapon)weapon);
            return this.health;
        }

        /// <summary> Set <see cref="health"/> to the the maximum <see cref="healthTotal"/> </summary>
        /// <returns> Final <see cref="health"/> </returns>
        internal float restore_health()
            => this.health = this.healthTotal;

        /// <summary> Set <see cref="health"/> to 0 </summary>
        /// <returns> Final <see cref="health"/> </returns>
        internal float kill()
            => this.health = 0;

        internal override StatName statName { get; }
        /// <summary> Maximum value for <see cref="health"/> </summary>
        internal float healthTotal { get; set; }
        internal float health { get; set; }

        internal Health(float healthTotal) {
            this.statName = StatName.Health;
            this.healthTotal = healthTotal;
            this.health = this.healthTotal;
        }
    }
}
