using sMath = System.Math;

namespace Assets.Scripts.Lib.Math {
    /// <summary> Predefined mapping functions </summary>
    public static class Function {
        public enum FunctionName {
            //? t     /
            //? |   /
            //? | /
            //? f一一一t
            linear_FT,
            //? t    .-
            //? |   /
            //? | _-
            //? f一一一t
            smooth_FT,
            //? t   ,.--
            //? |  /
            //? |/
            //? f一一一t
            smoothEnd_FT,
            //? t     /
            //? |    /
            //? | _.'
            //? f一一一t
            smoothStart_FT,

            //? t    .--.
            //? |   /    \
            //? | _'      '_
            //? f一一一一一一t
            smooth_FTF,
            //? t   ,.--.,
            //? |  /      \
            //? |/         \
            //? f一一一一一一t
            smoothMiddle_FTF
        }
        public static double fx(FunctionName function, double x, double from, double to)
            => function switch {
                FunctionName.smooth_FT => smooth_FT(x, from, to),
                FunctionName.smoothEnd_FT => smoothEnd_FT(x, from, to),
                FunctionName.smoothStart_FT => smoothStart_FT(x, from, to),
                FunctionName.smooth_FTF => smooth_FTF(x, from, to),
                FunctionName.smoothMiddle_FTF => smoothMiddle_FTF(x, from, to),
                _ => linear_0s(x, from, to)
            };


        #region Functions

        //? t     /
        //? |   /
        //? | /
        //? f一一一t

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀t⠀⠀⠀⠀⠀/  </item>
        /// <item>⠀⠀⠀:⠀⠀⠀/     </item>
        /// <item>⠀⠀⠀:⠀/       </item>
        /// <item>⠀⠀⠀f 一一一 t </item>
        /// </c>
        /// </list>
        /// </summary>
        /// <param name="x">input</param>
        /// <returns> <c> ƒ(𝑥) = 𝑥 </c> </returns> 
        public static double linear_0s(double x, double from, double to) {
            x = Common.ForcedInRange(x, from, to); // force x between f一一一t
            return x;
        }


        //? t    .-
        //? |   /
        //? | _'
        //? f一一一t

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀t⠀⠀⠀⠀.-         </item>
        /// <item>⠀⠀:⠀⠀⠀/           </item>
        /// <item>⠀⠀: _'            </item>
        /// <item>⠀⠀f 一一一 t     </item>
        /// </c>
        /// </list>
        /// <br/> Note: <c> d = t - f </c>
        /// </summary>
        /// <param name="x">input</param>
        /// <returns> <c> ƒ(𝑥) = ((-d•𝒄𝒐𝒔(π(𝑥 - f)/d)) + t + f) / 2 </c> </returns> 
        public static double smooth_FT(double x, double from, double to) {
            x = Common.ForcedInRange(x, from, to); // force x between f一一一t
            double delta = to - from;
            return ((-delta * sMath.Cos(sMath.PI * (x - from) / delta)) + to + from) / 2;
        }


        //? t     /
        //? |    /
        //? | _.'
        //? f一一一t

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀t⠀⠀⠀⠀⠀/     </item>
        /// <item>⠀⠀⠀|⠀⠀⠀⠀/      </item>
        /// <item>⠀⠀⠀|⠀_.'       </item>
        /// <item>⠀⠀⠀f 一一一 t       </item>
        /// </c>
        /// </list>
        /// <br/> Note: <c> d = t - f </c>
        /// </summary>
        /// <param name="x">input</param>
        /// <returns> <c> ƒ(𝑥) = -d•𝒄𝒐𝒔(π(x - f) / 2d) + t </c> </returns>
        public static double smoothStart_FT(double x, double from, double to) {
            x = Common.ForcedInRange(x, from, to); // force x between f一一一t
            double delta = to - from;
            return (-delta * sMath.Cos(sMath.PI * (x - from) / (2 * delta))) + to;
        }


        //? t   ,.--
        //? |  /
        //? |/
        //? f一一一t

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀t⠀⠀,.--  </item>
        /// <item>⠀⠀⠀|⠀/      </item>
        /// <item>⠀⠀⠀|/        </item>
        /// <item>⠀⠀⠀f一一一t  </item>
        /// </c>
        /// </list>
        /// <br/> Note: <c> d = t - f </c>
        /// </summary>
        /// <param name="x">input</param>
        /// <returns> <c> ƒ(𝑥) = d•𝒔𝒊𝒏(π(𝑥 - f)/2d) + f </c> </returns>
        public static double smoothEnd_FT(double x, double from, double to) {
            x = Common.ForcedInRange(x, from, to); // force x between f一一一t
            double delta = to - from;
            return (delta * sMath.Sin(sMath.PI * (x - from) / (2 * delta))) + from;
        }


        //? t    .--.
        //? |   /    \
        //? | _'      '_
        //? f一一一一一一t

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀ t⠀⠀⠀  .--.    </item>
        /// <item>⠀⠀⠀ |⠀⠀ /⠀⠀⠀⠀\    </item>
        /// <item>⠀⠀⠀ | _'⠀⠀⠀⠀ ⠀'_   </item>
        /// <item>⠀⠀⠀ f 一一一一一一 t      </item>
        /// </c>
        /// </list>
        /// <br/> Note: <c> d = t - f </c>
        /// </summary>
        /// <param name="x">input</param>
        /// <returns> <c> ƒ(𝑥) = ( -d•𝒄𝒐𝒔(2π(𝑥 - f)/d) + t + f )/2 </c></returns> 

        public static double smooth_FTF(double x, double from, double to) {
            x = Common.ForcedInRange(x, from, to); // force x between f一一一t
            double delta = to - from;
            return ((-delta * sMath.Cos(2 * sMath.PI * (x - from) / delta)) + to + from) / 2;
        }


        //? t   ,.--.,
        //? |  /      \
        //? |/         \
        //? f一一一一一一t

        /// <summary>
        /// <list>
        /// <c>
        /// <item>⠀⠀⠀ t⠀⠀,.--., </item>
        /// <item>⠀⠀⠀ |⠀/⠀⠀⠀⠀⠀\ </item>
        /// <item>⠀⠀⠀ |/⠀⠀⠀⠀⠀⠀⠀\  </item>
        /// <item>⠀⠀⠀ f一一一一一一t      </item>
        /// </c>
        /// </list>
        /// <br/> Note: <c> d = t - f </c>
        /// </summary>
        /// <param name="x">input</param>
        /// <returns> <c> ƒ(𝑥) = ( -d•𝒄𝒐𝒔(2π(𝑥 - f)/d) + t + f )/2 </c></returns> 
        public static double smoothMiddle_FTF(double x, double from, double to) {
            x = Common.ForcedInRange(x, from, to); // force x between f一一一t
            double delta = to - from;
            return -sMath.Abs(delta * sMath.Cos(sMath.PI * (x - from) / delta)) + to;
        }

        #endregion
    }
}
