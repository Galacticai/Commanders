/// —————————————————————————————————————————————
//? 
//!? 📜 Point.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————


using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space2D {
    public class Point {
        public static readonly Point ORIGIN = new(0, 0);

        public double Distance(Point point)
            => sMath.Sqrt(
                sMath.Pow(x - point.x, 2)
                + sMath.Pow(y - point.y, 2));

        public double DistanceToOrigin
            => Distance(ORIGIN);

        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y) {
            X = x; Y = y;
        }
    }
}
