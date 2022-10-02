using Assets.Scripts.Lib.Math.Numerics;

namespace Assets.Scripts.Game.Entities.Stats {
    internal sealed class Damage {

        internal enum DamageType {
            Direct, Area
        }

        internal DamageType Type { get; }

        private float _Radius;
        internal float Radius { get => _Radius; set => _Radius = value.Positive(); }

        internal float Amount { get; set; }

        private float _Piercing;
        internal float Piercing { get => _Piercing; set => _Piercing = value.AtOrBetween(0, 1); }

        private Damage(DamageType type, float amount, float radius = 0, float piercing = 0) {
            Type = type;
            Amount = amount;
            Piercing = piercing;
            Radius = radius;
        }

        internal static Damage Direct(float amount, float piercing = 0)
            => new(DamageType.Direct, amount, radius: 0, piercing);
        internal static Damage Area(float amount, float radius, float piercing = 0)
            => new(DamageType.Area, amount, radius, piercing);
    }
}
