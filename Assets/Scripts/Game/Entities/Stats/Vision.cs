using static Assets.Scripts.Game.Entities.Entity;

namespace Assets.Scripts.Game.Entities.Stats {
    internal sealed class Vision : Stat {
        internal struct Default {
            internal record TerritoryExtra {
                internal const float Land = 0.0f;
                internal const float Air = 1.5f;
                internal const float Water = -1.0f;
            }
        }


        #region Helper

        internal float radius_byTerritory(Territory territory)
            => this.radius_base
            + territory switch {
                Territory.Water => Default.TerritoryExtra.Water,
                Territory.Air => Default.TerritoryExtra.Air,
                //? Entity.Territory.Land
                _ => Default.TerritoryExtra.Land
            };

        #endregion

        internal override StatName statName { get; }
        internal float radius_base { get; set; }
        internal Vision(float radius) {
            this.statName = StatName.Vision;
            this.radius_base = radius;
        }
    }
}
