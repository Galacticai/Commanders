namespace Assets.Scripts.Objects.Entity.Stat {

    internal abstract partial class Stat {
        internal sealed class Damage : Stat {

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
    }
}
