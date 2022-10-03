/// —————————————————————————————————————————————
//? 
//!? 📜 Line.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + (Galacticai) Math/Space2D/Point.cs
//? 
/// —————————————————————————————————————————————

namespace Commanders.Assets.Scripts.Lib.Math.Space2D {
    /// <summary> A 2D line defined by 2 <see cref="Point"/>s </summary>
    public class Line {
        public record AXIS {
            public static readonly Line X = new(Point.ORIGIN, new(1, 0));
            public static readonly Line Y = new(Point.ORIGIN, new(0, 1));
        }

        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Line(Point point1, Point point2) {
            Point1 = point1;
            Point2 = point2;
        }
    }
}
