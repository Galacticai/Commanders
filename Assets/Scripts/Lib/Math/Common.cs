/// —————————————————————————————————————————————
//? 
//!? 📜 Common.cs
//!? 🖋️ XEROling 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

namespace Assets.Scripts.Lib.Math {
    public class Common {

namespace Commanders.Assets.Scripts.Lib.Math {
        public struct Space {
            public enum Dimension {
                x, y, z, w, time
            }
            public enum Plane {
                xy, yz, xz
            }
        }

        /// <summary> Random manipulation </summary>
        public struct Random {
            /// <summary> Generate a random integer between <c>min</c> and <c>max</c> paremeters </summary>
            /// <param name="min">Minimum range for output</param>
            /// <param name="max">Maximum range for output</param>
            /// <returns><paramref name="max"/> &lt; (Integer) &lt; <paramref name="max"/></returns>
            public static int Int(int min, int max)
                    => new System.Random().Next(min, max);

            /// <summary> Chooses a random object from input array </summary>
            /// <param name="arr">Input Object array</param>
            /// <returns>Random object from input array</returns>
            public static type FromArray<type>(type[] arr)
                    => arr[Random.Int(0, arr.Length - 1)]; // -1 because it starts from 0
        }
    }
}
