namespace Assets.Scripts.Lib.Math {
    public class Range {

        public static Range ZERO_ONE = new(0, 1);
        public static Range ZERO_HUNDRED = new(0, 100);


        #region Helper 

        public static double toRange(double value, Range range)
            => range.toRange(value);

        /// <returns> <paramref name="value"/> but forced inside this range. </returns>
        public double toRange(double value) {
            if (value < this.min) return this.min;
            if (value > this.max) return this.max;
            return value;
        }

        //TODO: Test this bruh
        public double atRatio(double ratio) {
            ratio = Range.ZERO_ONE.toRange(ratio);
            double offset = this.max - this.min;
            double atRatio_Absolute = (this.max - this.min) * ratio;
            return offset + atRatio_Absolute;
        }
        public double atPercent(double percent) {
            return this.atRatio(Range.ZERO_HUNDRED.toRange(percent) / 100);
        }
        public double min => System.Math.Min(this.start, this.end);
        public double max => System.Math.Max(this.start, this.end);

        #endregion


        public double start { get; set; }
        public double end { get; set; }
        public bool fromEnd { get; set; }
        public Range(double start, double end, bool fromEnd = false) {
            this.start = start;
            this.end = end;
            this.fromEnd = fromEnd;
        }
    }
}
