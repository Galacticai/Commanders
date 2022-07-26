namespace Assets.Scripts.Game.Entities.Stats {
    internal class Weapon : Stat {

        internal struct Damage {

            internal enum DamageType {
                Direct, Area
            }

            internal DamageType damageType { get; set; }
            internal float amount { get; set; }
            internal float radius { get; set; }
            private Damage(DamageType damageType, float amount, float radius = 0) {
                this.damageType = damageType;
                this.amount = amount;
                if (damageType == DamageType.Area && radius <= 0)
                    throw new System.ArgumentOutOfRangeException("Damage.radius must greater than 0");
                this.radius = radius;
            }
            internal static Damage Direct(float amount)
                => new(DamageType.Direct, amount);
            internal static Damage Area(float amount, float radius)
                => new(DamageType.Area, amount, radius);
        }


        internal enum WeaponType {
            Nearby, Ranged
        }

        internal override StatName statName { get; }
        internal WeaponType type { get; set; }
        internal Damage damage { get; set; }
        internal float radius { get; set; }
        private Weapon(WeaponType type, Damage damage, float radius = 0) {
            this.statName = StatName.Weapon;
            this.type = type;
            this.damage = damage;
            if (type == WeaponType.Ranged && radius <= 0)
                throw new System.ArgumentOutOfRangeException("Weapon.radius must greater than 0");
            this.radius = radius;
        }
        internal Weapon Nearby(Damage damage)
            => new(WeaponType.Nearby, damage);
        internal Weapon Ranged(Damage damage, float radius)
            => new(WeaponType.Ranged, damage, radius);
    }
}
