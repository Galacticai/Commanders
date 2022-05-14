using System.Linq;
using UnityEngine;

namespace Assets.Objects.Entity {

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

        /// <summary> Places where the <see cref="Entity"/> can stay alive </summary>
        internal enum Territory {
            Land, Water, Air
        }


        /// <summary> Available <see cref="Territory"/>'s that can be used by this <see cref="Entity"/> </summary>
        internal protected Territory[] territoryAllowed { get; private set; }
        /// <summary> Maximum health </summary>
        internal protected float healthTotal { get; private set; }

        /// <summary> Unity's <see cref="GameObject"/> of this <see cref="Entity"/> </summary>
        internal protected GameObject gameObject { get; private set; }

        /// <summary> Current <see cref="Territory"/> used by this <see cref="Entity"/> </summary>
        internal protected Territory territory { get; protected set; }
        /// <summary> Simple <see cref="string"/> alias derived from <see cref="gameObject"/>.name </summary>
        internal protected string name { get; protected set; }
        /// <summary> Current health </summary>
        internal protected float health { get; protected set; }

        /// <summary> Radius of vision area around the <see cref="Entity"/> </summary>
        internal protected float vision { get; protected set; }

        /// <summary> <see cref="GameObject"/> with extra sauce </summary>
        internal Entity(
                GameObject gameObject,
                float healthTotal,
                Territory territory,
                params Territory[] territoryAllowed) {
            this.gameObject = gameObject;
            this.name = this.gameObject.name;
            this.healthTotal = healthTotal;
            this.health = this.healthTotal;

            this.territory = territory;
            this.territoryAllowed = territoryAllowed ?? new Territory[] { this.territory };
            if (!this.territoryAllowed.Contains(this.territory))
                this.territoryAllowed.Concat(new Territory[] { this.territory });

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
