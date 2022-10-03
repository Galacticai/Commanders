/// —————————————————————————————————————————————
//? 
//!? 📜 Sphere.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + (Galacticai) Math/Space3D/Point.cs
//? 
/// —————————————————————————————————————————————

using Commanders.Assets.Scripts.Lib.Math.Numerics;
using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Space3D {
    public class Sphere {
        public static readonly Sphere UNIT_SPHERE = new(Point.ORIGIN, 1);

        public bool IncludesPoint(Point point)
            => Center.Distance(point) <= Radius;
        public bool OnPoint(Point point)
            => Center.Distance(point) == Radius;

        public double Distance_Center(Sphere sphere)
            => Center.Distance(sphere.Center);

        /// <returns>
        ///     <list type="bullet">
        ///     <item> &gt;0 • No intersection • The distance between the spheres </item>
        ///     <item> =0 • Touching edges </item>
        ///     <item> &lt;0 • Intersecting </item>
        ///     </list>
        /// </returns>
        public double Distance_Edge(Sphere sphere)
            => Distance_Center(sphere) - (Radius + sphere.Radius);

        public bool IntersectsSphere(Sphere sphere)
           => Distance_Edge(sphere) <= 0;

        //TODO: TEST Sphere.howClose(Point)
        /// <returns> Ratio of how close <paramref name="point"/> is to <see cref="Center"/>
        /// relative to <see cref="Radius"/> </returns>
        public double howClose(Point point) {
            double distance = Center.Distance(point);
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

        public Sphere(double x, double y, double z, double radius) {
            Center = new Point(x, y, z);
            Radius = radius;
        }
        public Sphere(Point center, double radius) {
            Center = center;
            Radius = radius;
        }
    }
}
