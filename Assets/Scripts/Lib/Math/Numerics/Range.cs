/// —————————————————————————————————————————————
//? 
//!? 📜 Range.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + (Galacticai) Math.Common.cs
//? 
/// —————————————————————————————————————————————

using sMath = System.Math;

namespace Commanders.Assets.Scripts.Lib.Math.Numerics {
    /// <summary> Numerical boundary (<see cref="double"/> type) </summary>
    public class Range {

        #region Shortcuts

        public static readonly Range ZERO_ONE = new(0, 1);
        public static readonly Range ZERO_TEN = new(0, 10);
        public static readonly Range ZERO_HUNDRED = new(0, 100);

        public double Min => sMath.Min(_Start, _End);
        public double Max => sMath.Max(_Start, _End);

        #endregion
        #region Methods

        /// <returns> <paramref name="value"/> but forced inside this <see cref="Range"/> </returns>
        public double AtOrBetween(double value)
            => value.AtOrBetween(Min, Max);

        public double GetRatio(double value) {
            //? No need to consider this.FromEnd
            if (_Start == _End)
                //? this.End with considering this.FromEnd
                return value > End ? 1 : 0;
            return (value - Min) / (Max - Min);
        }

        public double GetPercent(double percent)
            => GetRatio(percent) * 100;

        /// <summary> Union of this <see cref="Range"/> with another <paramref name="range"/> </summary>
        /// <returns> new <see cref="Range"/> spanning both ranges </returns>
        public Range Union(Range range)
            => new(sMath.Min(Min, range.Min), sMath.Max(Max, range.Max));

        #endregion

        private double _Start;
        private double _End;
        public double Start {
            get => FromEnd ? _End : _Start;
            set => _Start = value;
        }
        public double End {
            get => FromEnd ? _Start : _End;
            set => _End = value;
        }
        public bool FromEnd { get; set; }
        /// <param name="fromEnd"> Flips the start and end points </param>
        public Range(double start, double end, bool fromEnd = false) {
            Start = start;
            End = end;
            FromEnd = fromEnd;
        }
    }
}