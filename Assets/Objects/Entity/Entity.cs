using UnityEngine;

namespace Assets.Objects.Entity {

    /// <summary> Tanks, airplanes, troops,
    /// or any game object that acts similarly </summary>
    internal partial class Entity {
        internal struct Default {
            internal const float vision = 5.0f;
            internal record TerritoryExtra {
                internal record Land {
                    internal const float vision = 0.0f;
                }
                internal record Air {
                    internal const float vision = 1.5f;
                }
                internal record Water {
                    internal const float vision = -1.0f;
                }
            }
        }

        internal enum Territory {
            Land, Water, Air
        }


        internal protected GameObject gameObject { get; private set; }
        internal protected string name { get; protected set; }
        internal protected float health { get; protected set; }
        internal protected float healthTotal { get; protected set; }
        internal protected Territory territory { get; protected set; }
        internal protected Territory[] territoryAllowed { get; private set; }
        internal protected float vision { get; protected set; }

        internal Entity(
                GameObject gameObject,
                float health_total,
                Territory territory,
                params Territory[] territoryAllowed) {
            this.gameObject = gameObject;
            this.name = this.gameObject.name;
            this.healthTotal = health_total;
            this.health = this.healthTotal;
            this.territory = territory;
            this.territoryAllowed = territoryAllowed;
            this.vision
                = Default.vision
                + this.territory switch {
                    Territory.Land => Default.TerritoryExtra.Land.vision,
                    Territory.Water => Default.TerritoryExtra.Water.vision,
                    Territory.Air => Default.TerritoryExtra.Air.vision,
                    _ => 0 //? Impossible but I dont wanna see the warning
                };
        }
    }
}
