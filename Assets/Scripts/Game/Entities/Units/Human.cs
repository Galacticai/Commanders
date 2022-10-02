using Assets.Scripts.Game.Entities.Stats;

namespace Assets.Scripts.Game.Entities.Units {

    internal abstract class Human : Unit {

        internal record Defaults {
            internal const bool something = false;
        }

        private protected Human(Command command, StatDictionary stats = null)
                : base(command, stats) { }

        }
    }
}
