using Assets.Scripts.Game.Commanders.Computers;
using Assets.Scripts.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Game.Entities.Stats {
    /// <summary> Special type of <see cref="TypeDictionary{TValue}"/> that's specialized for <see cref="Stat"/>s </summary>
    internal class StatDictionary : TypeDictionary<Stat> {

        internal record Default {
            internal static readonly Type[] Required
                = { typeof(Command), typeof(Territory), typeof(Health) };
            internal static Command Command(string gameObject_name)
                => new(gameObject_name, Computer.MASTER);
            internal static Territory Territory
                => new(allowed: Territory.TerritoryType.Land);
            internal static Health Health
                => Health.Immortal();
        }

        #region Methods
        internal static bool StatIsRequired(Type statType)
            => Default.Required.Contains(statType);
        public override void Clear() {
            base.Clear();
            var currentCommand = Get<Command>();
            _SetDefaults(currentCommand, force: true);
        }
        public override bool Remove<IStat>() {
            if (StatIsRequired(typeof(IStat)))
                return false;
            return base.Remove<IStat>();
        }
        #endregion

        private void _SetDefaults(Command command, bool force = false) {
            Set(command, force);
            Set(Default.Territory, force);
            Set(Default.Health, force);
        }

        public StatDictionary(Command command, params Stat[] values)
                    : base(values) {
            _SetDefaults(command);
        }
        public StatDictionary(Command command, Dictionary<Type, Stat> dictionary)
                    : base(dictionary) {
            _SetDefaults(command);
        }
        public StatDictionary(Command command, List<Stat> list)
                    : base(list) {
            _SetDefaults(command);
        }
        public StatDictionary(Command command) {
            _SetDefaults(command);
        }

        /// <returns> <see cref="StatDictionary"/> with <see cref="Default"/> stats </returns>
        internal static StatDictionary CreateDefault(Command command)
            => new(command);
    }
}
