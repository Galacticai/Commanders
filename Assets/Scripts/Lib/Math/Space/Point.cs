using sMath = System.Math;

namespace Assets.Scripts.Lib.Math.Space {
    public class Point {
        private static Point _ORIGIN = new(0, 0, 0);
        public static Point ORIGIN => Point._ORIGIN;


        public double distance(Point point)
            => sMath.Sqrt(
                sMath.Pow(this.x - point.x, 2)
                + sMath.Pow(this.y - point.y, 2)
                + sMath.Pow(this.z - point.z, 2));

        public double distanceToOrigin
            => this.distance(Point.ORIGIN);

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Point(double x, double y, double z) {
            this.x = x; this.y = y; this.z = z;
        }
    }
}
