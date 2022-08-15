using System;
using System.Security;

namespace Assets.Scripts.Game.Commanders.Computers {
    internal class Computer : Commander {
        /// <summary> The master of all <see cref="Player"/>s and <see cref="Computer"/>s <br/>
        /// Controls everything </summary>
        internal static readonly Computer MASTER = new();

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
            //!?
            //!? Commander.Computer.MASTER is the only real MASTER commander (Already created above)
            //!?
            //?     > Clone of the real MASTER Commander is being created
            if (base.isMASTER)
                throw new VerificationException("Fake MASTER Commander detected! Aborting.");
            //?     > New MASTER Commander is being created (not an accurate clone)
            if (base.name == "MASTER" || base.provenance == Provenance.MASTER || base.alliance == 0)
                throw new UnauthorizedAccessException("MASTER Commander is created automatically for better security. (Commander.Computer.MASTER)");
            this.strategy = strategy;
        }
    }
}
