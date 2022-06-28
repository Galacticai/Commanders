using System.Collections.Generic;

namespace Assets.Scripts.Objects.Entities.Stats {
    internal sealed class Defence : Stat {

        internal float amount(Weapon weapon) {
            this.Weapon_multiplier.TryGetValue(
                weapon.GetType(),
                out float multiplier_ofEntity);
            return this.multiplier * multiplier_ofEntity;
        }

        internal override StatName statName { get; }
        internal float multiplier { get; private set; }
        internal Dictionary<System.Type, float> Weapon_multiplier { get; private set; }

        internal Defence(float multiplier, Dictionary<System.Type, float> Weapon_multiplier = default) {
            this.statName = StatName.Defence;
            this.multiplier = multiplier;
            this.Weapon_multiplier = Weapon_multiplier;
        }
    }
}
