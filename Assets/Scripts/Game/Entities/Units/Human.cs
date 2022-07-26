using Assets.Scripts.Game.Entities.Stats;

namespace Assets.Scripts.Game.Entities.Units {

    internal abstract class Human : Unit {

        internal record Defaults {
            internal const bool something = false;
        }


        internal Human(string commanderID, string gameObject_name, StatDictionary stats)
                : base(commanderID, gameObject_name, new() { Territory.Land }, stats) {

        }
    }

}
