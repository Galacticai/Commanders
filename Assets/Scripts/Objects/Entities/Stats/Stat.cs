namespace Assets.Scripts.Objects.Entities.Stats {
    internal abstract partial class Stat {
        internal enum StatName {
            STAT,

            Buff,
            Defence,
            Health,
            Vision,
            Weapon
        }

        internal System.Type toStatType()
            => this.statName switch {
                StatName.Buff => typeof(Buff),
                StatName.Defence => typeof(Defence),
                StatName.Health => typeof(Health),
                StatName.Vision => typeof(Vision),
                StatName.Weapon => typeof(Weapon),
                _ => typeof(Stat)
            };

        internal virtual StatName statName { get; }
        internal Stat() {
            this.statName = StatName.STAT;
        }
    }
}
