/// —————————————————————————————————————————————
//? 
//!? 📜 Amount.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + (Galacticai) Math.Range.cs
//      + (Galacticai) Math.Range_Extension.cs
//? 
/// —————————————————————————————————————————————


namespace Commanders.Assets.Scripts.Lib.Math.Numerics {
    /// <summary> <see cref="double"/> value that exists in a <see cref="Numerics.Range"/> </summary>
    public class Amount {
        /// <summary> The ratio of <see cref="Value"/>,  relative to the <see cref="Range"/>'s min and max </summary>
        public double Ratio_InRange
            => Range.GetRatio(Value);

        private double _Value;
        public double Value {
            get => _Value;
            set => _Value = value.AtOrBetween(Range);
        }
        public Range Range { get; set; }

        public Amount(double value) {
            Value = value;
            Range = new(0, value);
        }
        public Amount(double value, Range range) {
            Value = value;
            Range = range;
        }

        public static implicit operator double(Amount amount)
            => amount.Value;
        //!? Replacing the instance causes the Range to be reset which means old range data gets lost unexpectedly!
        //!?    => Better create a new instance manually while knowing that a new range is made
        //public static implicit operator Amount(double value) => new(value); 
    }
}