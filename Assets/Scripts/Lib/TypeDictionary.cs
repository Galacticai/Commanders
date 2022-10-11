/// —————————————————————————————————————————————
//? 
//!? 📜 TypeDictionary.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;

namespace Commanders.Assets.Scripts.Lib {
    /// <summary> Dictionary of <typeparamref name="TValue"/> with the <see cref=" Type"/> of <typeparamref name="TValue"/> as the key 
    /// <br/> ⚠️ Warning: If you repeat the same <typeparamref name="TValue"/>, the first one will be applied. </summary>
    public class TypeDictionary<TValue> {
        #region Shortcuts

        public int Count => Dictionary.Count;
        public Dictionary<Type, TValue>.KeyCollection Keys => Dictionary.Keys;
        public Dictionary<Type, TValue>.ValueCollection Values => Dictionary.Values;
        public TValue this[Type type] => Dictionary[type];

        #endregion
        #region Methods

        public void TrimExcess() => Dictionary.TrimExcess();
        public virtual void Clear() => Dictionary.Clear();
        public virtual bool Remove<ITValue>() where ITValue : TValue
            => Dictionary.Remove(typeof(ITValue));
        public virtual ITValue Get<ITValue>() where ITValue : TValue {
            bool contains = Dictionary.TryGetValue(typeof(ITValue), out TValue value);
            if (!contains) return default;
            return (ITValue)value;
        }
        public virtual bool Set<ITValue>(ITValue value) where ITValue : TValue
            => Set(value, false);
        public virtual bool Set<ITValue>(ITValue value, bool force) where ITValue : TValue {
            if (value is null) return false;
            if (Contains<ITValue>() && !force) return false;
            Dictionary[value.GetType()] = value;
            return true;
        }
        public bool Contains<ITValue>() where ITValue : TValue
            => Dictionary.ContainsKey(typeof(ITValue));
        public bool ContainsValue<ITValue>(ITValue value) where ITValue : TValue {
            //? No need to loop through all values
            //? X Dictionary.ContainsValue(value)
            //? > Directly:
            //?     + Check if type exists
            //?     + Compare value of that key to the provided value
            ITValue value_FromDictionary = Get<ITValue>();
            if (value_FromDictionary == null) return false;
            return Comparer<ITValue>.Default.Compare(value, value_FromDictionary) >= 0;
        }

        #endregion

        private Dictionary<Type, TValue> Dictionary { get; set; }
        /// <summary> ℹ️ Note: If you repeat the same type more than once, the last one will be applied. </summary>
        public TypeDictionary(params TValue[] values) {
            Dictionary = new();
            foreach (var value in values) Set(value);
        }
        public TypeDictionary(Dictionary<Type, TValue> dictionary) {
            Dictionary = new();
            foreach (var value in dictionary.Values) Set(value);
        }
        public TypeDictionary(List<TValue> list) {
            Dictionary = new();
            foreach (var value in list) Set(value);
        }
        public TypeDictionary() {
            Dictionary = new();
        }

        #region Conversion
        public List<TValue> ToList() => Values.ToList();
        public Dictionary<Type, TValue> ToDictionary() => new(Dictionary);

        public static implicit operator List<TValue>(TypeDictionary<TValue> typeDictionary)
            => typeDictionary.ToList();
        public static implicit operator Dictionary<Type, TValue>(TypeDictionary<TValue> typeDictionary)
            => typeDictionary.ToDictionary();
        public static implicit operator TypeDictionary<TValue>(Dictionary<Type, TValue> dictionary)
            => new(dictionary.Values.ToArray());
        public static implicit operator TypeDictionary<TValue>(List<TValue> list)
            => new(list);
        #endregion
    }
}
