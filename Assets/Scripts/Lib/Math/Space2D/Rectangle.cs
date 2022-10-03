/// —————————————————————————————————————————————
//? 
//!? 📜 Rectangle.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: 
//      + (Galacticai) Math/Space2D/Point.cs
//      + (Galacticai) Math/Space2D/RectanglePoints.cs
//? 
/// —————————————————————————————————————————————


using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space2D {
    //TODO: TEST Rectangle.{xyz}Length calculation 
    public class Rectangle {
        public double X { get; set; }
        public double Y { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }

        public double Area
            => XLength * YLength;
        public RectanglePoints Points
            => new(this);

        public Rectangle(double x, double y, double xLength, double yLength) {
            X = x;
            Y = y;
            XLength = sMath.Abs(xLength);
            YLength = sMath.Abs(yLength);
        }
        public Rectangle(Point point, double xLength, double yLength)
                    : this(point.X, point.Y, xLength, yLength) { }
        public Rectangle(Point point1, Point point2)
                    : this(point1.X, point1.Y,
                          sMath.Max(point1.X, point2.X) - sMath.Min(point1.X, point2.X),
                          sMath.Max(point1.Y, point2.Y) - sMath.Min(point1.Y, point2.Y)) { }
    }
}
