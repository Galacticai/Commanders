/// —————————————————————————————————————————————
//? 
//!? 📜 Box.cs
//!? 🖋️ XEROling 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: 
//      + (XEROling) Math/Common.cs
//? 
/// —————————————————————————————————————————————


using Commanders.Assets.Scripts.Lib.Math.Numerics;
using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space3D {
    //TODO: TEST Box.{XYZ}Length calculation
    public class Box {
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
