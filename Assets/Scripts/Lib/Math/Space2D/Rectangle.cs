using sMath = System.Math;

namespace Assets.Scripts.Lib.Math.Space2D {
    //TODO: TEST Rectangle.{xyz}Length calculation 
    public class Rectangle {
        public double x { get; set; }
        public double y { get; set; }
        public double xLength { get; set; }
        public double yLength { get; set; }

        public double area
            => this.xLength * this.yLength;
        public RectanglePoints points
            => new(this);

        public Rectangle(double x, double y, double xLength, double yLength) {
            this.x = x;
            this.y = y;
            this.xLength = sMath.Abs(xLength);
            this.yLength = sMath.Abs(yLength);
        }
        public Rectangle(Point point, double xLength, double yLength)
                    : this(point.x, point.y, xLength, yLength) { }
        public Rectangle(Point point1, Point point2)
                    : this(point1.x, point1.y,
                          sMath.Max(point1.x, point2.x) - sMath.Min(point1.x, point2.x),
                          sMath.Max(point1.y, point2.y) - sMath.Min(point1.y, point2.y)) { }
    }
}
