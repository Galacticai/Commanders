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


using Commanders.Assets.Scripts.Lib.Math.Numerics;
using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space2D {
    //TODO: TEST Rectangle.{xyz}Length calculation 
    public class Rectangle {
        #region Helper Methods 
        /// <summary> Map a <see cref="Point"/> from current <see cref="Rectangle"/> to another </summary>
        /// <param name="rectangle"> Target <see cref="Rectangle"/> </param>
        public Point MapPointIntoBox(Point point, Rectangle rectangle)
            => MapPointIntoBox(point, rectangle, false);
        /// <summary> Map a <see cref="Point"/> from current <see cref="Rectangle"/> to another </summary>
        /// <param name="point"> Source <see cref="Point"/> </param>
        /// <param name="rectangle"> Target <see cref="Rectangle"/> </param>
        /// <param name="forceInRectangle"> Force the output to be inside the target <paramref name="rectangle"/> </param>
        public Point MapPointIntoBox(Point point, Rectangle rectangle, bool forceInRectangle) {
            Point newPoint = new(
                rectangle.X + (rectangle.XLength * (point.X - X) / XLength),
                rectangle.Y + (rectangle.YLength * (point.Y + Y) / YLength)
            );
            if (forceInRectangle) {
                newPoint.X = newPoint.X.AtOrBetween(rectangle.X, rectangle.X + rectangle.XLength);
                newPoint.Y = newPoint.Y.AtOrBetween(rectangle.Y, rectangle.Y + rectangle.YLength);
            }
            return newPoint;
        }
        #endregion

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
