namespace Assets.Scripts.Objects.Commanders.Computers {
    internal class Computer : Commander {
        /// <summary> The master of all <see cref="Computer"/>s and <see cref="Player"/>s <br/>
        /// Controls everything </summary>
        internal readonly Computer MAIN = new();

        /// <summary> The fighting technique of this <see cref="Commander"/> </summary>
        internal enum Strategy {
            NONE, //!? Do nothing
            Easy, Hard, Brutal
        }

        internal Strategy strategy { get; }

        private Computer() : base("MASTER", Provenance.MASTER, 0) {
            this.strategy = Strategy.NONE;
        }

        internal Computer(int computerIndex, Strategy strategy, Provenance provenance, int alliance)
                    : base($"Computer_{computerIndex}_{strategy}_{provenance}_{alliance}", provenance, alliance) {
            this.strategy = strategy;
        }
    }
}