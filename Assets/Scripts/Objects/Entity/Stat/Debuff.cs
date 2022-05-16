namespace Assets.Scripts.Objects.Entity.Stat {

    internal sealed class Debuff {
        internal enum Type {
            Damage, Defence
        }
        internal Type type { get; set; }
        internal float multiplier { get; set; }

        internal Debuff(Type type, float multiplier) {
            this.type = type;
            this.multiplier = multiplier;
        }

    }
}
