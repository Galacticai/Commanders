/// —————————————————————————————————————————————
//? 
//!? 📜 Function.cs
//!? 🖋️ XEROling 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Numerics {
    /// <summary> Predefined mapping functions </summary>
    public static class Function {
        public enum FunctionName {
            //? t     /
            //? |   /
            //? | /
            //? f一一一t
            Linear_FT,
            //? t    .-
            //? |   /
            //? | _-
            //? f一一一t
            Smooth_FT,
            //? t   ,.--
            //? |  /
            //? |/
            //? f一一一t
            SmoothEnd_FT,
            //? t     /
            //? |    /
            //? | _.'
            //? f一一一t
            SmoothStart_FT,

            //? t    .--.
            //? |   /    \
            //? | _'      '_
            //? f一一一一一一t
            Smooth_FTF,
            //? t   ,.--.,
            //? |  /      \
            //? |/         \
            //? f一一一一一一t
            SmoothMiddle_FTF

        }
        public static double Fx(FunctionName function, double x, double from, double to)
            => function switch {
                FunctionName.Smooth_FT => Smooth_FT(x, from, to),
                FunctionName.SmoothEnd_FT => SmoothEnd_FT(x, from, to),
                FunctionName.SmoothStart_FT => SmoothStart_FT(x, from, to),
                FunctionName.Smooth_FTF => Smooth_FTF(x, from, to),
                FunctionName.SmoothMiddle_FTF => SmoothMiddle_FTF(x, from, to),
                _ => Linear_FT(x, from, to)
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
        public static double Linear_FT(double x, double from, double to) {
            x = x.AtOrBetween(from, to); // force x between f一一一t
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
        public static double Smooth_FT(double x, double from, double to) {
            x = x.AtOrBetween(from, to); // force x between f一一一t
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
        public static double SmoothStart_FT(double x, double from, double to) {
            x = x.AtOrBetween(from, to); // force x between f一一一t
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
        public static double SmoothEnd_FT(double x, double from, double to) {
            x = x.AtOrBetween(from, to); // force x between f一一一t
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

        public static double Smooth_FTF(double x, double from, double to) {
            x = x.AtOrBetween(from, to); // force x between f一一一t
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
        public static double SmoothMiddle_FTF(double x, double from, double to) {
            x = x.AtOrBetween(from, to); // force x between f一一一t
            double delta = to - from;
            return -sMath.Abs(delta * sMath.Cos(sMath.PI * (x - from) / delta)) + to;
        }

        #endregion
    }
}
