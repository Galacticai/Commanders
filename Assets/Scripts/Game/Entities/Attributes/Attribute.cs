namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    internal abstract class Attribute {
        protected internal Entity Parent_Entity { get; protected set; }
        private protected Attribute(Entity parent_Entity) {
            Parent_Entity = parent_Entity;
        }
    }
}
