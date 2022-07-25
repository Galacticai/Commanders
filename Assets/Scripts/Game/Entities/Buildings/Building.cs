using Assets.Scripts.Lib.Math.Space3D;
using Assets.Scripts.Objects.Entities.Stats;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Objects.Entities.Buildings {
    internal abstract class Building : Entity {


        #region Helper

        private static bool _buildMode = false;
        public static bool buildMode { get => _buildMode; private set => _buildMode = value; }

        internal Task<bool> hoverBuild(Point center) {
            buildMode = true;
            buildMode = false;
            return null;
        }

        #endregion

        internal protected double constructionRadius { get; protected set; }
        internal Building(
                string commanderID,
                string gameObject_name,
                float constructionRadius,
                List<Territory> territoryAllowed,
                StatDictionary stats)
                    : base(commanderID, gameObject_name, territoryAllowed, stats) {
            if (this.territory == Territory.Air)
                throw new ArgumentOutOfRangeException("Building.territory cannot be Territory.Air");

            this.constructionRadius = constructionRadius;

        }
    }
}
