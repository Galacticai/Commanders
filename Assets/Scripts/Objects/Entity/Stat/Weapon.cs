namespace Assets.Scripts.Objects.Entity.Stat {
    internal abstract partial class Stat {
        internal class Weapon : Stat {
            internal enum WeaponType {
                Nearby, Ranged
            }

            internal WeaponType type { get; set; }
            internal Damage damage { get; set; }
            internal float radius { get; set; }
            private Weapon(WeaponType type, Damage damage, float radius = 0) {
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
}
