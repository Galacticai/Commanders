namespace Assets.Scripts.Objects.Entity {

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

        internal protected virtual float update_vision() {
            this.vision = Default.vision;
            if (this.isOnWater) this.vision += Default.TerritoryExtra.Water.vision;
            else if (this.isOnAir) this.vision += Default.TerritoryExtra.Air.vision;
            return this.vision;
        }

        //TODO: Move health info to children that need it
        //internal bool isDamaged
        //    => this.health < this.healthTotal;
        //internal bool isHealed
        //    => this.health == this.healthTotal;

        //internal float health_percent
        //    => (this.health / this.healthTotal) * 100;


        //private float health_delta(float delta) {
        //    if (delta == 0) return this.health;

        //    float health_new = this.health + delta;

        //    //! Never let health be negative or above total
        //    // to avoid any unexpected behavior
        //    if (health_new > this.healthTotal)
        //        this.restore_health();
        //    else if (health_new <= 0)
        //        this.kill();

        //    this.health += delta;
        //    return this.health;
        //}

        //internal virtual float heal(float amount) {
        //    this.health_delta(Math.Abs(amount));
        //    return this.health;
        //}
        //internal virtual float hurt(float amount) {
        //    this.health_delta(-Math.Abs(amount));
        //    return this.health;
        //}
        //internal virtual float hurtByEntity(Entity entity) {
        //    this.hurt();
        //    return this.health;
        //}

        //internal virtual float restore_health() {
        //    this.health = this.healthTotal;
        //    return this.health;
        //}
        //internal virtual void kill() {
        //    this.health = 0;
        //    //TODO: Kill entity... each entity could have a kill script that's added to gameObject at runtime
        //}

    }
}
