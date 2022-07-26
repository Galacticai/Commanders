namespace Assets.Scripts.Lib.Math.Space3D {
    public class Cube : Box {

        private new readonly double xLength, yLength, zLength;
        public double length {
            get => base.xLength;
            set {
                base.xLength = value;
                base.yLength = value;
                base.zLength = value;
            }
        }

        public Point center
            => new(base.x + (this.length / 2), base.y + (this.length / 2), base.z + (this.length / 2));

        public Cube(double x, double y, double z, double length)
                    : base(x, y, z, length, length, length) { }
        public Cube(Point point, double length)
                    : base(point, length, length, length) { }
    }
}
