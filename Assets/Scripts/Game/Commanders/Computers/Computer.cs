using System;
using System.Security;

namespace Commanders.Assets.Scripts.Game.Commanders.Computers {

    internal class Computer : Commander {
        /// <summary> The master of all <see cref="Player"/>s and <see cref="Computer"/>s <br/>
        /// Controls everything </summary>
        internal static readonly Computer MASTER = new();

        /// <summary> The fighting technique of a <see cref="Computer"/> </summary>
        internal enum ComputerStrategy {
            NONE, //? No AI
            Easy, Hard, Brutal
        }
        internal ComputerStrategy Strategy { get; }

        private Computer() : base("MASTER", Provenance.MASTER, 0) {
            Strategy = ComputerStrategy.NONE;
        }

        internal Computer(int computerIndex, ComputerStrategy strategy, Provenance provenance, int alliance)
                    : base($"Computer_{computerIndex}_{strategy}_{provenance}_{alliance}", provenance, alliance) {
            //!?
            //!? Commander.Computer.MASTER is the only real MASTER commander (Already created above)
            //!?
            //?     > Clone of the real MASTER Commander is being created
            if (IsMASTER)
                throw new VerificationException("Fake MASTER Commander detected! Aborting.");
            //?     > New MASTER Commander is being created (not an accurate clone)
            if (Name == "MASTER" || Provenance == Provenance.MASTER || Alliance == 0)
                throw new UnauthorizedAccessException("MASTER Commander is created automatically for better security. (Commander.Computer.MASTER)");
            Strategy = strategy;
        }

    }
}
