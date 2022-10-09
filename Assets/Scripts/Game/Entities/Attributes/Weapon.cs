using Commanders.Assets.Scripts.Lib.Math.Numerics;

namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    internal class Weapon : Attribute {

        internal enum WeaponType {
            Nearby, Ranged
        }

        internal WeaponType Type { get; set; }
        internal Damage Damage { get; set; }
        private double _Radius;
        /// <summary> Maximum distance this weapon can reach </summary>
        internal double Radius {
            get => _Radius;
            set => _Radius = value.Positive();
        }
        private Weapon(Entity parent_Entity, WeaponType type, Damage damage, double radius = 0)
                    : base(parent_Entity) {
            Type = type;
            Damage = damage;
            Radius = radius < 0 ? 0 : radius;
        }
        internal Weapon Nearby(Entity parent_Entity, Damage damage)
            => new(parent_Entity, WeaponType.Nearby, damage);
        internal Weapon Ranged(Entity parent_Entity, Damage damage, double radius)
            => new(parent_Entity, WeaponType.Ranged, damage, radius);
    }
}
