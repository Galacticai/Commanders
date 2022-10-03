using Commanders.Assets.Scripts.Game.Entities.Stats;
using Commanders.Assets.Scripts.Lib.Math.Space2D;
using System;
using System.Threading.Tasks;

namespace Commanders.Assets.Scripts.Game.Entities.Buildings {
    internal class Building : Entity {
        #region Helper
        protected internal static bool BuildMode { get; protected set; }

        internal Task<bool> hoverBuild(Point center) {
            BuildMode = true;

            BuildMode = false;
            return null;
        }
        #endregion

        protected internal double ConstructionRadius { get; protected set; }
        private protected Building(Command command, float constructionRadius, StatDictionary stats)
                    : base(command, stats) {
            foreach (var territoryType in Territory.Allowed)
                if (territoryType == Territory.TerritoryType.Air)
                    throw new ArgumentOutOfRangeException("Building.Territory must not allow TerritoryType.Air");

            ConstructionRadius = constructionRadius;

        }
    }
}
