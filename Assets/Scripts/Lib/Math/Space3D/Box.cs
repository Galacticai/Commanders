/// —————————————————————————————————————————————
//? 
//!? 📜 Box.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: 
//      + (Galacticai) Math/Common.cs
//? 
/// —————————————————————————————————————————————


using Commanders.Assets.Scripts.Lib.Math.Numerics;
using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space3D {
    //TODO: TEST Box.{XYZ}Length calculation
    public class Box {
        #region Helper Methods 
        /// <summary> Map a <see cref="Point"/> from current <see cref="Box"/> to another </summary>
        /// <param name="box"> Target <see cref="Box"/> </param>
        public Point MapPointIntoBox(Point point, Box box)
            => MapPointIntoBox(point, box, false);
        /// <summary> Map a <see cref="Point"/> from current <see cref="Box"/> to another </summary>
        /// <param name="point"> Source <see cref="Point"/> </param>
        /// <param name="box"> Target <see cref="Box"/> </param>
        /// <param name="forceInBox"> Force the output to be inside the target <paramref name="box"/> </param>
        public Point MapPointIntoBox(Point point, Box box, bool forceInBox) {
            Point newPoint = new(
                box.X + (box.XLength * (point.X - X) / XLength),
                box.Y + (box.YLength * (point.Y + Y) / YLength),
                box.Z + (box.ZLength * (point.Z + Z) / ZLength)
            );
            if (forceInBox) {
                newPoint.X = newPoint.X.AtOrBetween(box.X, box.X + box.XLength);
                newPoint.Y = newPoint.Y.AtOrBetween(box.Y, box.Y + box.YLength);
                newPoint.Z = newPoint.Z.AtOrBetween(box.Z, box.Z + box.ZLength);
            }
            return newPoint;
        }

        #endregion

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public virtual double XLength { get; set; }
        public virtual double YLength { get; set; }
        public virtual double ZLength { get; set; }

        public virtual double Volume
            => XLength * YLength * ZLength;
        public BoxPoints Points
            => new(this);

        public Box(double x, double y, double z, double xLength, double yLength, double zLength) {
            X = x;
            Y = y;
            Z = z;
            XLength = xLength.Positive();
            YLength = yLength.Positive();
            ZLength = zLength.Positive();
        }
        public Box(Point point, double xLength, double yLength, double zLength)
                    : this(point.X, point.Y, point.Z,
                          xLength, yLength, zLength) { }
        public Box(Point point1, Point point2)
                    : this(point1.X, point1.Y, point1.Z,
                          sMath.Max(point1.X, point2.X) - sMath.Min(point1.X, point2.X),
                          sMath.Max(point1.Y, point2.Y) - sMath.Min(point1.Y, point2.Y),
                          sMath.Max(point1.Z, point2.Z) - sMath.Min(point1.Z, point2.Z)) { }
    }
}
