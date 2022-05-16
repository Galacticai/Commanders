namespace Assets.Scripts.Lib.Math.Space {
    public class Line {
        public record AXIS {
            public Line X = new(Point.ORIGIN, new(1, 0, 0));
            public Line Y = new(Point.ORIGIN, new(0, 1, 0));
            public Line Z = new(Point.ORIGIN, new(0, 0, 1));
        }

        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public Line(Point point1, Point point2) {
            this.point1 = point1;
            this.point2 = point2;
        }
    }
}
