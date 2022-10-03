using System.Collections.Generic;

namespace Commanders.Assets.Scripts.Game.Entities.Stats {
    /// <summary> Place(s) where an <see cref="Entity"/> can stand </summary>
    internal class Territory : Stat {
        internal enum TerritoryType {
            Land, Water, Air
        }

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


        /// <summary> Available <see cref="TerritoryType"/>s that can be used by an <see cref="Entity"/> </summary>
        internal List<TerritoryType> Allowed { get; }
        internal TerritoryType Current => Allowed[0];
        internal Territory(List<TerritoryType> allowed) {
            if (allowed.Count == 0)
                allowed.Add(TerritoryType.Land);
            Allowed = allowed;
        }
        internal Territory(params TerritoryType[] allowed) {
            Allowed = new();
            if (allowed.Length > 0)
                Allowed.AddRange(allowed);
            else Allowed.Add(TerritoryType.Land);
        }

        public static implicit operator Territory(List<TerritoryType> allowed)
            => new(allowed);
        public static implicit operator TerritoryType(Territory territory)
            => territory.Current;
    }
}
