/// —————————————————————————————————————————————
﻿using sMath = System.Math;


using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space2D {
    public class Point {
        public readonly static Point ORIGIN = new(0, 0);

        public double Distance(Point point)
            => sMath.Sqrt(
                sMath.Pow(x - point.x, 2)
                + sMath.Pow(y - point.y, 2));

        public double DistanceToOrigin
            => Distance(ORIGIN);

        public double x { get; set; }
        public double y { get; set; }
        public Point(double x, double y) {
            this.x = x; this.y = y;
        }
    }
}
