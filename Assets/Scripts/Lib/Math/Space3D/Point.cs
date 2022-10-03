/// —————————————————————————————————————————————
//? 
//!? 📜 Point.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space3D {
    public class Point {
        public static readonly Point ORIGIN = new(0, 0, 0);

        public double Distance(Point point)
            => sMath.Sqrt(
                sMath.Pow(X - point.X, 2)
                + sMath.Pow(Y - point.Y, 2)
                + sMath.Pow(Z - point.Z, 2));

        public double DistanceToOrigin
            => Distance(Point.ORIGIN);

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point(double x, double y, double z) {
            X = x; Y = y; Z = z;
        }
    }
}
