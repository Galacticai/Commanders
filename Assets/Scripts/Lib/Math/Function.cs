using sMath = System.Math;

namespace Assets.Scripts.Lib.Math {
    /// <summary> Predefined functions </summary>
    public static class Function {


        // s    .-
        // |   /
        // | _-
        // 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>‏‏‎s‏‏‎ ‎‏‏‎ ‎‏‏‎‏‏‎ ‎ ‏‏‎ ‎‎‏‏‎ ‎.-  </item>
        /// <item>‏‏‎:‏‏‎ ‎‏‏‎ ‎‏‏‎‏‏‎ ‎ ‎/    </item>
        /// <item>‏‏‎: ‎_-     </item>
        /// <item>‏‏‎‎0 . . . . s </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = scale • ( ( -𝒄𝒐𝒔(π𝑥) / (2•scale) ) + 1/2 ) </c> </returns> 
        public static double cosSmoothStartEnd(double x, double scale) {
            Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return scale * ((-sMath.Cos(x * sMath.PI) / (2 * scale)) + (1 / 2));
        }


        // s -.
        // |   \
        // |    -_
        // 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>‏‏‎‎s‏‏‎ ‎‎-.      </item>
        /// <item>‏‏‎:‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎\    </item>
        /// <item>‏‏‎:‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎-_</item>
        /// <item>‏‏‎0 . . . . s </item>
        /// </c>
        /// </list>
        /// </summary> 
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = scale • ( (𝒔𝒊𝒏( π𝑥 + π/2 ) / 2) + 1/2 ) </c> </returns> 
        /// 
        public static double sinSmoothEnd_01(double x, double scale) {
            Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return scale * ((sMath.Sin((x * sMath.PI) + (sMath.PI / 2)) / 2) + (1 / 2));
        }


        // s \
        // |  \
        // |   *._
        // 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>‏‏‎‎s‏‏‎ ‎\</item>
        /// <item>‏‏‎:‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎\</item>
        /// <item>‏‏‎:‏‏‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎*._</item>
        /// <item>‏‏‎0 . . . . s </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = scale • ( -𝒔𝒊𝒏( (π/2)𝑥 / scale) + 1 ) </c> </returns>
        public static double sinSmoothEnd(double x, double scale) {
            Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return scale * (-sMath.Sin(x * (sMath.PI / 2) / scale) + 1);
        }


        // s --.
        // |    \
        // |     \
        // 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>‏‏‎‎s‏‏‎‏‏‎ ‎--.</item>
        /// <item>‏‏‎:‏‏‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎\</item>
        /// <item>‏‏‎:‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎\</item>
        /// <item>‏‏‎0 . . . . s </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = scale • 𝒔𝒊𝒏( ( (π/(2•scale))𝑥 ) + π/2 ) </c> </returns>
        public static double sinSmoothStart(double x, double scale) {
            Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return scale * sMath.Sin((x * (sMath.PI / (2 * scale))) + (sMath.PI / 2));
        }
    }
}
