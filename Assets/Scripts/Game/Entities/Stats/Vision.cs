namespace Commanders.Assets.Scripts.Game.Entities.Stats {
    /// <summary> How an <see cref="Entity"/> sees... </summary>
    internal sealed class Vision : Stat {
        internal float Radius { get; set; }
        internal bool CamoVisible { get; set; }
        internal Vision(float radius, bool camoVisible = false) {
            Radius = radius;
            CamoVisible = camoVisible;
        }
    }
}
