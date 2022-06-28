namespace Assets.Scripts.Lib.Math.Space2D {
    internal class Square : Rectangle {
        private new readonly double xLength, yLength;

        public double length {
            get => base.xLength;
            set {
                base.xLength = value;
                base.yLength = value;
            }
        }

        public Point center
            => new(base.x + (this.length / 2), base.y + (this.length / 2));

        public Square(double x, double y, double length)
                    : base(x, y, length, length) { }
        public Square(Point point, double length)
                    : base(point, length, length) { }
    }
}