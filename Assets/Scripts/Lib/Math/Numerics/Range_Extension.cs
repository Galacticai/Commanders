using System;

namespace Commanders.Assets.Scripts.Lib.Math.Numerics {
    public static class Range_Extension {
        public static double AtOrBetween(this double value, Range range)
            => value.AtOrBetween(range.Min, range.Max);
        public static double AtOrBetween(this double input, double min, double max) {
            if (input > max) return max;
            if (input < min) return min;
            return input;
        }
        public static double AtOrAbove(this double input, double min)
            => input < min ? min : input;

        public static double AtOrBelow(this double input, double max)
            => input > max ? max : input;

        public static double Positive(this double input)
            => AtOrAbove(input, 0);

        public static double Negative(this double input)
            => AtOrBelow(input, 0);

        public static bool IsBetween(this double input, double min, double max)
            => input >= min && input <= max;


        public static float AtOrBetween(this float value, Range range)
            => value.AtOrBetween(Convert.ToSingle(range.Min), Convert.ToSingle(range.Max));
        public static float AtOrBetween(this float input, float min, float max) {
            if (input > max) return max;
            if (input < min) return min;
            return input;
        }
        public static float AtOrAbove(this float input, float min)
            => input < min ? min : input;

        public static float AtOrBelow(this float input, float max)
            => input > max ? max : input;

        public static float Positive(this float input)
            => AtOrAbove(input, 0);

        public static float Negative(this float input)
            => AtOrBelow(input, 0);

        public static bool IsBetween(this float input, float min, float max)
            => input >= min && input <= max;


        public static int AtOrBetween(this int value, Range range)
            => value.AtOrBetween(Convert.ToInt32(range.Min), Convert.ToInt32(range.Max));
        public static int AtOrBetween(this int input, int min, int max) {
            if (input > max) return max;
            if (input < min) return min;
            return input;
        }
        public static int AtOrAbove(this int input, int min)
            => input < min ? min : input;

        public static int AtOrBelow(this int input, int max)
            => input > max ? max : input;

        public static int Positive(this int input)
            => AtOrAbove(input, 0);

        public static int Negative(this int input)
            => AtOrBelow(input, 0);

        public static bool IsBetween(this int input, int min, int max)
            => input >= min && input <= max;
    }
}
