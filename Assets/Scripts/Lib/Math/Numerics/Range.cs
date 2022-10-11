using System;
/// —————————————————————————————————————————————
//? 
//!? 📜 Range.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
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

        /// <summary> <paramref name="value"/> but forced inside this <see cref="Range"/> </summary>
        public double AtOrBetween(double value)
            => value.AtOrBetween(Min, Max);

        public double GetRatio(double value) {
            //? Try catch because double==double is never precise
            //? (can't detect division by zero beforehand)
            try {
                return (value - Min) / (Max - Min);
            } catch { //(System.DivideByZeroException divideByZeroExceptiion) {
                return value > End ? 1 : 0;
            }
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
        public Range(double start, double end, bool fromEnd) {
            Start = start;
            End = end;
            FromEnd = fromEnd;
        }
        public Range(double start, double end)
                    : this(start, end, false) { }


        public override string ToString()
            => $"{Min}_{Max}";
        public override int GetHashCode()
            => HashCode.Combine(Min, Max);
        public override bool Equals(object obj) {
            if (obj is not Range other) return false;
            return Min == other.Min && Max == other.Max;
        }
        public static bool operator ==(Range range1, Range range2)
            => range1.Equals(range2);
        public static bool operator !=(Range range1, Range range2)
            => !range1.Equals(range2);
        public static bool operator >(Range range1, Range range2)
            => range1.Max > range2.Max;
        public static bool operator <(Range range1, Range range2)
            => range1.Min < range2.Min;
    }
}