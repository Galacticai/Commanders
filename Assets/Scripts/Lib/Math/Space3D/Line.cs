/// —————————————————————————————————————————————
//? 
//!? 📜 Line.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + (Galacticai) Math/Space3D/Point.cs
//? 
/// —————————————————————————————————————————————

namespace Commanders.Assets.Scripts.Lib.Math.Space3D {
    /// <summary> A 3D line defined by 2 <see cref="Point"/>s </summary>
    public class Line {
        public record AXIS {
            public static readonly Line X = new(Point.ORIGIN, new(1, 0, 0));
            public static readonly Line Y = new(Point.ORIGIN, new(0, 1, 0));
            public static readonly Line Z = new(Point.ORIGIN, new(0, 0, 1));
        }

        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Line(Point point1, Point point2) {
            Point1 = point1;
            Point2 = point2;
        }
    }
}
