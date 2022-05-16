namespace Assets.Scripts.Objects.Entity.Stat {

    internal sealed class Damage {
        internal enum Type {
            None, Direct, Area
        }
        internal Type type { get; set; }
        internal float amount { get; set; }

        internal Damage(Type type, float amount) {
            this.type = type;
            this.amount = amount;
        }

    }
}
