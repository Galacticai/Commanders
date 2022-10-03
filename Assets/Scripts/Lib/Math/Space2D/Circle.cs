using Commanders.Assets.Scripts.Lib.Math.Numerics;
using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space2D {
    internal class Circle {
        public static readonly Circle UNIT_SPHERE = new(Point.ORIGIN, 1);

        public bool includesPoint(Point point)
            => Center.distance(point) <= Radius;
        public bool onPoint(Point point)
            => Center.distance(point) == Radius;

        public double distance_Center(Circle sphere)
            => Center.distance(sphere.Center);

        /// <returns>
        ///     <list type="bullet">
        ///     <item> &gt;0 • No intersection • The distance between the spheres </item>
        ///     <item> =0 • Touching edges </item>
        ///     <item> &lt;0 • Intersecting </item>
        ///     </list>
        /// </returns>
        public double Distance_Edge(Circle sphere)
            => distance_Center(sphere) - (Radius + sphere.Radius);

        public bool IntersectsSphere(Circle sphere)
           => Distance_Edge(sphere) <= 0;

        //TODO: TEST Circle.howClose(Point)
        /// <returns> Ratio of how close <paramref name="point"/> is to <see cref="Center"/>
        /// relative to <see cref="Radius"/> </returns>
        public double howClose(Point point) {
            double distance = Center.distance(point);
            //? close 0 -- 1 far
            double ratio_inverse = distance / Radius;
            //? close 1 -- 0 far
            double ratio = sMath.Abs(ratio_inverse - 1);
            return ratio.AtOrBetween(0, 1);
        }


        public Point Center { get; set; }
        public double Radius { get; set; }
        public double Volume
            => 4 * sMath.PI * sMath.Pow(Radius, 2);

        public Circle(double x, double y, double radius) {
            Center = new Point(x, y);
            Radius = radius;
        }
        public Circle(Point center, double radius) {
            Center = center;
            Radius = radius;
        }
    }
}
