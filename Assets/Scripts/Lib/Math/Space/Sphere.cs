using sMath = System.Math;

namespace Assets.Scripts.Lib.Math.Space {
    public class Sphere {
        private static Sphere _UNIT_SPHERE = new(Point.ORIGIN, 1);
        public static Sphere UNIT_SPHERE => _UNIT_SPHERE;

        public bool includesPoint(Point point)
            => this.center.distance(point) <= this.radius;
        public bool onPoint(Point point)
            => this.center.distance(point) == this.radius;

        public double distance_Center(Sphere sphere)
            => this.center.distance(sphere.center);

        /// <returns>
        ///     <list type="bullet">
        ///     <item> &gt;0 • No intersection • The distance between the spheres </item>
        ///     <item> =0 • Touching edges </item>
        ///     <item> &lt;0 • Intersecting </item>
        ///     </list>
        /// </returns>
        public double distance_Edge(Sphere sphere)
            => this.distance_Center(sphere) - (this.radius + sphere.radius);

        public bool intersectsSphere(Sphere sphere)
           => this.distance_Edge(sphere) <= 0;

        //TODO: Make it actually logical and useful: (How much this sphere encapsulates another sphere)
        /// <returns> Percentage of how close <paramref name="point"/> is to <see cref="center"/>
        /// relative to <see cref="radius"/> </returns>
        public double nearRadius_Percent(Point point)
            => (this.center.distance(point) / this.radius) * 100;


        public Point center { get; set; }
        public double radius { get; set; }
        public double volume
            => 4 * sMath.PI * sMath.Pow(this.radius, 2);

        public Sphere(double x, double y, double z, double radius) {
            this.center = new Point(x, y, z);
            this.radius = radius;
        }
        public Sphere(Point center, double radius) {
            this.center = center;
            this.radius = radius;
        }
    }
}