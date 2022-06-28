using sMath = System.Math;

namespace Assets.Scripts.Lib.Math.Space2D {
    public class Point {
        public readonly static Point ORIGIN = new(0, 0);

        public double distance(Point point)
            => sMath.Sqrt(
                sMath.Pow(this.x - point.x, 2)
                + sMath.Pow(this.y - point.y, 2));

        public double distanceToOrigin
            => this.distance(Point.ORIGIN);

        public double x { get; set; }
        public double y { get; set; }
        public Point(double x, double y) {
            this.x = x; this.y = y;
        }
    }
}