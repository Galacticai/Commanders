/// —————————————————————————————————————————————
//? 
//!? 📜 Mask.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;

namespace Commanders.Assets.Scripts.Lib {
    /// <summary> Masks the original value with a different one,
    /// <br/> while keeping the original value safely as <see cref="OriginalValue"/> 
    /// <br/><br/>
    /// _______________
    /// <br/>
    /// To get the currently active value of this mask:
    /// <br/><list type="bullet">
    ///     <item> (Implicit) `<c> mask </c>`  (Not all types work with this)</item> 
    ///     <item> (Explicit) `<c> (<typeparamref name="TValue"/>)mask </c>` </item> 
    ///     <item>   (Direct) `<c> <see cref="Value"/> </c>` </item>
    /// </list></summary> 
    /// <typeparam name="TMaskKey"> Type of the key of <see cref="MaskFunctions"/> </typeparam>
    /// <typeparam name="TValue"> Type of the <see cref="Value"/> </typeparam>
    public class Mask<TMaskKey, TValue> {

        public Mask<TMaskKey, TValue> ResetOriginal(TValue originalValue)
            => new(originalValue, MaskFunctions);
        public TValue Reset() {
            MaskFunctions.Clear();
            return OriginalValue;
        }
        public TValue OriginalValue { get; }

        public Dictionary<TMaskKey, Func<TValue, TValue>> MaskFunctions { get; set; }

        public TValue Value
            => MaskFunctions.Values.Aggregate(
                OriginalValue,
                (current, maskFunction) => maskFunction(current)
            );

        public Mask(TValue originalValue, Dictionary<TMaskKey, Func<TValue, TValue>> maskFunctions) {
            OriginalValue = originalValue;
            MaskFunctions = maskFunctions;
        }
        public Mask(TValue originalValue)
                    : this(originalValue, new()) { }

        //!? ! Data loss warning: Don't convert from TValue to Mask implicitly
        // public static implicit operator Mask<TMaskKey, TValue>(TValue value)
        //     => value;
        public static implicit operator TValue(Mask<TMaskKey, TValue> mask)
            => mask.Value;
    }
}
