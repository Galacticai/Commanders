using Assets.Scripts.Game.Entities.Stats;

namespace Assets.Scripts.Game.Entities.Units {
    internal abstract class Unit : Entity {

        /// <summary> A tank, an airplane, a soldier,
        /// or any game entity that acts similarly </summary>
        private protected Unit(Command command, StatDictionary stats = null)
                    : base(command, stats) { }
    }
}
