using Commanders.Assets.Scripts.Lib.Math.Numerics;

namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    internal sealed class Damage {

        internal enum DamageType {
            Direct, Area
        }

        internal DamageType Type { get; }

        private double _Radius;
        internal double Radius { get => _Radius; set => _Radius = value.Positive(); }

        internal double Amount { get; set; }

        private double _Piercing;
        internal double Piercing { get => _Piercing; set => _Piercing = value.AtOrBetween(0, 1); }

        private Damage(DamageType type, double amount, double radius = 0, double piercing = 0) {
            Type = type;
            Amount = amount;
            Piercing = piercing;
            Radius = radius;
        }

        internal static Damage Direct(double amount, double piercing = 0)
            => new(DamageType.Direct, amount, radius: 0, piercing);
        internal static Damage Area(double amount, double radius, double piercing = 0)
            => new(DamageType.Area, amount, radius, piercing);
    }
}
