using Commanders.Assets.Scripts.Game.Commanders.Computers;
using Commanders.Assets.Scripts.Lib;
using System;
using System.Linq;

namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    /// <summary> Special type of <see cref="TypeDictionary{TValue}"/> that's specialized for <see cref="Attribute"/>s </summary>
    internal class AttributeDictionary : TypeDictionary<Attribute> {

        internal record Default {
            internal static readonly Type[] Required
                = { typeof(Territory), typeof(Health) };
            internal static Command Command(string gameObject_name)
                => new(gameObject_name, Computer.MASTER);
            internal static Territory Territory
                => new(allowed: Territory.TerritoryType.Land);
            internal static Health Health
                => Health.Immortal();
        }

        #region Methods
        internal static bool AttributeIsRequired(Type statType)
            => Default.Required.Contains(statType);
        public override void Clear() {
            base.Clear();
            _SetDefaults(force: true);
        }
        public override bool Remove<IStat>() {
            if (AttributeIsRequired(typeof(IStat)))
                return false;
            return base.Remove<IStat>();
        }
        #endregion

        private void _SetDefaults(bool force = false) {
            Set(Default.Territory, force);
            Set(Default.Health, force);
        }

        public AttributeDictionary(params Attribute[] values)
                    : base(values) {
            _SetDefaults();
        }
        public AttributeDictionary() {
            _SetDefaults();
        }

        /// <summary> <see cref="AttributeDictionary"/> with <see cref="Default"/> stats </summary>
        internal static AttributeDictionary CreateDefault()
            => new();
    }
}
