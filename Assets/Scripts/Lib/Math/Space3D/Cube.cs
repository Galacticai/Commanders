/// —————————————————————————————————————————————
//? 
//!? 📜 Cube.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: 
//      + (Galacticai) Math/Space3D/Box.cs
//? 
/// —————————————————————————————————————————————


namespace Commanders.Assets.Scripts.Lib.Math.Space3D {
    public class Cube : Box {
        private new double XLength { get; set; }
        private new double YLength { get; set; }
        private new double ZLength { get; set; }
        public double Length {
            get => base.XLength;
            set {
                base.XLength = value;
                base.YLength = value;
                base.ZLength = value;
            }
        }

        public Point Center
            => new(
                base.X + (Length / 2),
                base.Y + (Length / 2),
                base.Z + (Length / 2)
            );

        public Cube(double x, double y, double z, double length)
                    : base(x, y, z, length, length, length) { }
        public Cube(Point point, double length)
                    : base(point, length, length, length) { }
    }
}
