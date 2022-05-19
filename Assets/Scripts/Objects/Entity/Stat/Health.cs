using System;

namespace Assets.Scripts.Objects.Entity.Stat {

    internal abstract partial class Stat {
        internal sealed class Health : Stat {
            internal bool isDamaged
                => this.health < this.healthTotal;
            internal bool isHealed
                => this.health == this.healthTotal;

            internal float health_percent
                => (this.health / this.healthTotal) * 100;


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

            internal float heal(float amount) {
                this.health_delta(Math.Abs(amount));
                return this.health;
            }
            internal float hurt(float amount) {
                this.health_delta(-Math.Abs(amount));
                return this.health;
            }
            internal float hurtBy(Damage damage) {
                this.hurt(damage.amount);
                return this.health;
            }
            internal float hurtBy(Entity entity) {
                if (entity.stats.ContainsKey(typeof(Damage))) {
                    entity.stats.TryGetValue(typeof(Damage), out Stat damage);
                    this.hurtBy((Damage)damage);
                }
                return this.health;
            }

            internal float restore_health() {
                this.health = this.healthTotal;
                return this.health;
            }
            internal void kill() {
                this.health = 0;
            }

            internal float healthTotal { get; set; }
            internal float health { get; set; }

            internal Health(float healthTotal) {
                this.healthTotal = healthTotal;
                this.health = this.healthTotal;
            }
        }
    }
}
