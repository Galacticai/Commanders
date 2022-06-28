using sMath = System.Math;

namespace Assets.Scripts.Lib.Math.Space3D {
    //TODO: TEST Box.{xyz}Length calculation
    public class Box {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double xLength { get; set; }
        public double yLength { get; set; }
        public double zLength { get; set; }

        public double volume
            => this.xLength * this.yLength * this.zLength;
        public BoxPoints points
            => new(this);

        public Box(double x, double y, double z, double xLength, double yLength, double zLength) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.xLength = sMath.Abs(xLength);
            this.yLength = sMath.Abs(yLength);
            this.zLength = sMath.Abs(zLength);
        }
        public Box(Point point, double xLength, double yLength, double zLength)
                    : this(point.x, point.y, point.z,
                          xLength, yLength, zLength) { }
        public Box(Point point1, Point point2)
                    : this(point1.x, point1.y, point1.z,
                          sMath.Max(point1.x, point2.x) - sMath.Min(point1.x, point2.x),
                          sMath.Max(point1.y, point2.y) - sMath.Min(point1.y, point2.y),
                          sMath.Max(point1.z, point2.z) - sMath.Min(point1.z, point2.z)) { }
    }
}