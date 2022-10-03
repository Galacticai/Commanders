/// —————————————————————————————————————————————
//? 
//!? 📜 Random.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

namespace Commanders.Assets.Scripts.Lib.Math {
    public static class Random {
        /// <returns> Random <see cref="int"/> such as:
        /// <br/> <paramref name="max"/> &lt;= <see cref="int"/> &lt;= <paramref name="max"/></returns>
        public static int GetRandom(int min, int max, System.Random random)
            => random.Next(min, max);
        /// <returns> Random <see cref="int"/> such as:
        /// <br/> <paramref name="max"/> &lt;= <see cref="int"/> &lt;= <paramref name="max"/></returns>
        public static int GetRandom(int min, int max)
            => new System.Random().Next(min, max + 1); //? +1 to match the max

        /// <summary> Chooses a random object from input array </summary> 
        /// <returns>Random object from input array</returns>
        public static T FromArray<T>(T[] array)
            => array[GetRandom(0, array.Length - 1)]; //? -1 because it starts from 0
    }
}
