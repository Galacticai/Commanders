/// —————————————————————————————————————————————
//? 
//!? 📜 Square.cs
//!? 🖋️ XEROling 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: 
//      + (XEROling) Math/Space2D/Point.cs
//      + (XEROling) Math/Space2D/Rectangle.cs
//? 
/// —————————————————————————————————————————————


namespace Commanders.Assets.Scripts.Lib.Math.Space2D {
    internal class Square : Rectangle {
        private new readonly double XLength, YLength;

        public double Length {
            get => base.XLength;
            set {
                base.XLength = value;
                base.YLength = value;
            }
        }

        public Point Center
            => new(X + (Length / 2), Y + (Length / 2));

        public Square(double x, double y, double length)
                    : base(x, y, length, length) { }
        public Square(Point point, double length)
                    : base(point, length, length) { }
    }
}
