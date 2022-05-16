namespace Assets.Scripts.Lib.Math {
    public class Common {
        public static double forcedInRange(double x, double min, double max) {
            if (x < min) return min;
            if (x > max) return max;
            return x;
        }
    }
}
