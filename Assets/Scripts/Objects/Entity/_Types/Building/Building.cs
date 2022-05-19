using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Entity._Types.Building {
    internal abstract class Building : Entity {

        protected internal float constructionRadius { get; protected set; }

        internal Building(
                ref GameObject gameObject,
                float healthTotal,
                float constructionRadius,
                Territory territory,
                List<Stat.Stat> stats)
                    : base(ref gameObject, healthTotal, new() { territory }, stats) {
            if (territory == Territory.Air)
                throw new ArgumentOutOfRangeException("Building.territory cannot be Territory.Air");

            this.constructionRadius = constructionRadius;

        }
    }
}
