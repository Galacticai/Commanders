namespace Assets.Scripts.Game.Entities.Stats {
    internal class Weapon : Stat {

        internal enum WeaponType {
            Nearby, Ranged
        }

        internal WeaponType Type { get; set; }
        internal Damage Damage { get; set; }
        internal float Radius { get; set; }
        private Weapon(WeaponType type, Damage damage, float radius = 0) {
            Type = type;
            Damage = damage;
            Radius = radius < 0 ? 0 : radius;
        }
        internal Weapon Nearby(Damage damage)
            => new(WeaponType.Nearby, damage);
        internal Weapon Ranged(Damage damage, float radius)
            => new(WeaponType.Ranged, damage, radius);
    }
}
