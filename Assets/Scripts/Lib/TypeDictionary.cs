/// —————————————————————————————————————————————
//? 
//!? 📜 TypeDictionary.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

﻿using System.Collections.Generic;

namespace Commanders.Assets.Scripts.Lib {
    /// <summary> Dictionary of <typeparamref name="TargetType"/> with the <see cref="System.Type"/> of <typeparamref name="TargetType"/> as the key </summary>
    internal class TypeDictionary<TargetType> : Dictionary<System.Type, TargetType> {

        //!? ==== HIDDEN ==========
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        internal void Add(System.Type type, TargetType value)
            => base.Add(type, value);
        internal bool TryAdd(System.Type type, TargetType value)
            => base.TryAdd(type, value);
        internal void Add(TargetType value)
            => this.Add(value.GetType(), value);
        internal bool TryAdd(TargetType value)
            => this.TryAdd(value.GetType(), value);
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        //!? ======================

        internal TypeDictionary(params TargetType[] values) {
            foreach (var value in values) this.Add(value);
        }
        internal TypeDictionary() { }
    }
}
