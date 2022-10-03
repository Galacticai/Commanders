/// —————————————————————————————————————————————
//? 
//!? 📜 Arrays.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

using System.Linq;

namespace Commanders.Assets.Scripts.Lib {
    public static class Arrays {

        /// <summary> Add an <paramref name="element"/> item to the end of <paramref name="array"/></summary>
        /// <typeparam name="T">Type of the array to be used</typeparam>
        /// <param name="array">Array to manipulate</param>
        /// <param name="element">Element to add to <paramref name="array"/></param>
        /// <returns>Array {<paramref name="array"/>, <paramref name="element"/>} as <typeparamref name="type"/>[]</returns>
        public static T[] AddArrays<T>(this T[] array, T element)
            => AddArrays(array, new T[] { element });
        /// <summary> Add an <paramref name="expansion"/> array to the end of <paramref name="array"/></summary>
        /// <typeparam name="T">Type of the array to be used</typeparam>
        /// <param name="array">Array to manipulate</param>
        /// <param name="expansion">Element to add to <paramref name="array"/></param>
        /// <returns>Array {<paramref name="array"/>, <paramref name="expansion"/>} as <typeparamref name="type"/>[]</returns>
        public static T[] AddArrays<T>(this T[] array, T[] expansion)
            => array.Concat(expansion).ToArray();

        public static bool ContainsSubType<T, TTarget>(this T[] values) where TTarget : T {
            foreach (var value in values)
                if (value.GetType() is TTarget)
                    return true;
            return false;
        }
    }
}
