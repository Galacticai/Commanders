namespace Assets.Scripts.Objects.Entities {

    internal abstract partial class Entity {

        internal bool canLand
            => this.territoryAllowed.Contains(Territory.Land);
        internal bool canWater
            => this.territoryAllowed.Contains(Territory.Water);
        internal bool canAir
            => this.territoryAllowed.Contains(Territory.Air);

        internal bool isOnLand
            => this.territory == Territory.Land;
        internal bool isOnWater
            => this.territory == Territory.Water;
        internal bool isOnAir
            => this.territory == Territory.Air;

    }
}
