using sMath = System.Math;

namespace Assets.Scripts.Lib.Math {
    /// <summary> Predefined functions </summary>
    public static class Function {
        public enum FunctionName {
            //? s     /
            //? |   /
            //? | /
            //? 0一一一s
            linear_0s,
            //? s    .-
            //? |   /
            //? | _-
            //? 0一一一s
            smooth_0s,
            //? s   ,.--
            //? |  /
            //? |/
            //? 0一一一s
            smoothEnd_0s,
            //? s     /
            //? |    /
            //? | _.'
            //? 0一一一s
            smoothStart_0s,

            //? s    .--.
            //? |   /    \
            //? | _'      '_
            //? 0一一一一一一s
            smooth_0s0,
            //? s   ,.--.,
            //? |  /      \
            //? |/         \
            //? 0一一一一一一s
            smoothMiddle_0s0
        }
        public static double fx(double x, double scale, FunctionName function)
            => function switch {
                FunctionName.smooth_0s => smooth_0s(x, scale),
                FunctionName.smoothEnd_0s => smoothEnd_0s(x, scale),
                FunctionName.smoothStart_0s => smoothStart_0s(x, scale),
                FunctionName.smooth_0s0 => smooth_0s0(x, scale),
                FunctionName.smoothMiddle_0s0 => smoothMiddle_0s0(x, scale),
                _ => linear_0s(x, scale)
            };


        #region Functions

        //? s     /
        //? |   /
        //? | /
        //? 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀s⠀⠀⠀⠀⠀/  </item>
        /// <item>⠀⠀⠀:⠀⠀⠀/     </item>
        /// <item>⠀⠀⠀:⠀/       </item>
        /// <item>⠀⠀⠀0 . . . s </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = 𝑥 </c> </returns> 
        private static double linear_0s(double x, double scale) {
            x = Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return x;
        }


        //? s    .-
        //? |   /
        //? | _'
        //? 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>‏‏‎s‏‏‎ ‎‏‏‎ ‎‏‏‎‏‏‎ ‎ ‏‏‎ ‎‎‏‏‎ ‎.-  </item>
        /// <item>‏‏‎:‏‏‎ ‎‏‏‎ ‎‏‏‎‏‏‎ ‎ ‎/    </item>
        /// <item>‏‏‎: ‎_'     </item>
        /// <item>‏‏‎‎0 . . . . s </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = ((-scale • 𝒄𝒐𝒔(π𝑥 / scale)) + scale) / 2 </c> </returns>
        public static double smooth_0s(double x, double scale) {
            x = Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return ((-scale * sMath.Cos(x * sMath.PI / scale)) + scale) / 2;
        }


        //? s   ,.--
        //? |  /
        //? |/
        //? 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀s⠀⠀,.--  </item>
        /// <item>⠀⠀⠀|⠀/      </item>
        /// <item>⠀⠀⠀|/        </item>
        /// <item>⠀⠀⠀0一一一s  </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = scale • 𝒔𝒊𝒏(π𝑥 / (2•scale)) </c> </returns> 
        public static double smoothEnd_0s(double x, double scale) {
            x = Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return scale * sMath.Sin(sMath.PI * x / (2 * scale));
        }


        //? s     /
        //? |    /
        //? | _.'
        //? 0一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀s⠀⠀⠀⠀⠀/     </item>
        /// <item>⠀⠀⠀|⠀⠀⠀⠀/      </item>
        /// <item>⠀⠀⠀|⠀_.'       </item>
        /// <item>⠀⠀⠀0一一一s       </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = (-scale • 𝒄𝒐𝒔(π𝑥 / (2•scale))) + scale </c> </returns> 
        public static double smoothStart_0s(double x, double scale) {
            x = Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return (-scale * sMath.Cos(sMath.PI * x / (2 * scale))) + scale;
        }


        //? s    .--.
        //? |   /    \
        //? | _'      '_
        //? 0一一一一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀ s⠀⠀⠀.--.    </item>
        /// <item>⠀⠀⠀ |⠀⠀/⠀⠀⠀⠀\    </item>
        /// <item>⠀⠀⠀ | _'⠀⠀⠀⠀⠀'_   </item>
        /// <item>⠀⠀⠀ 0一一一一一一s      </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = ((-scale • 𝒄𝒐𝒔(2π𝑥 / scale)) + scale) / 2 </c> </returns> 

        public static double smooth_0s0(double x, double scale) {
            x = Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return ((-scale * sMath.Cos(2 * sMath.PI * x / scale)) + scale) / 2;
        }

        //? s   ,.--.,
        //? |  /      \
        //? |/         \
        //? 0一一一一一一s

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀ s⠀⠀,.--., </item>
        /// <item>⠀⠀⠀ |⠀/⠀⠀⠀⠀⠀\ </item>
        /// <item>⠀⠀⠀ |/⠀⠀⠀⠀⠀⠀⠀\  </item>
        /// <item>⠀⠀⠀ 0一一一一一一s      </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <param name="scale">Size of the wave (Half wave)</param>
        /// <returns> <c> ƒ(𝑥) = scale • 𝒔𝒊𝒏(π𝑥/scale) </c> </returns> 
        public static double smoothMiddle_0s0(double x, double scale) {
            x = Common.ForcedInRange(x, 0, scale); // force x between 0一一一s
            return scale * sMath.Sin(sMath.PI * x / scale);
        }

        #endregion
    }
}
