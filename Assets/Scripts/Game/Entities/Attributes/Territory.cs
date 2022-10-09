using System.Collections.Generic;

namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    /// <summary> Place(s) where an <see cref="Entity"/> can stand </summary>
    internal class Territory : Attribute {
        internal enum TerritoryType {
            Land, Water, Air
        }
        #region Shortcuts
        internal TerritoryType Current => Allowed[0];

        internal bool CanLand
            => Allowed.Contains(TerritoryType.Land);
        internal bool CanWater
            => Allowed.Contains(TerritoryType.Water);
        internal bool CanAir
            => Allowed.Contains(TerritoryType.Air);

        internal bool IsOnLand
            => this == TerritoryType.Land;
        internal bool IsOnWater
            => this == TerritoryType.Water;
        internal bool IsOnAir
            => this == TerritoryType.Air;

        #endregion

        /// <summary> Available <see cref="TerritoryType"/>s that can be used by an <see cref="Entity"/> </summary>
        internal List<TerritoryType> Allowed { get; }
        internal Territory(Entity parent_Entity, List<TerritoryType> allowed)
                    : base(parent_Entity) {
            if (allowed.Count == 0)
                allowed.Add(TerritoryType.Land);
            Allowed = allowed;
        }
        internal Territory(Entity parent_Entity, params TerritoryType[] allowed)
                    : base(parent_Entity) {
            Allowed = new();
            if (allowed.Length > 0)
                Allowed.AddRange(allowed);
            else Allowed.Add(TerritoryType.Land);
        }

        public static implicit operator TerritoryType(Territory territory)
            => territory.Current;
    }
}
