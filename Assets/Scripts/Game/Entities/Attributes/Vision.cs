namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    /// <summary> How an <see cref="Entity"/> sees... </summary>
    internal sealed class Vision : Attribute {
        internal double Radius { get; set; }
        internal bool CamoVisible { get; set; }
        internal Vision(Entity parent_Entity, double radius, bool camoVisible = false)
                    : base(parent_Entity) {
            Radius = radius;
            CamoVisible = camoVisible;
        }
    }
}
