//using System;

namespace Commanders.Assets.Scripts.Lib.Math.Numerics
{
//namespace Assets.Scripts.Lib.Math.Numerics;
//public class Number<TNumber>
//                where TNumber : IComparable, IFormattable, IConvertible, IComparable<TNumber>, IEquatable<TNumber> {

//    #region Helper

//    public double ToDouble()
//        => Convert.ToDouble(Value);
//    public double ToInt32()
//        => Convert.ToInt32(Value);
//    public double ToLong()
//        => Convert.ToSingle(Value);

//    #endregion


//    public TNumber Value { get; set; }

//    public Number(TNumber value) {
//        Value = value;
//    }


//    #region Operators

//    public static Number<TNumber> operator +(Number<TNumber> number1, Number<TNumber> number2)
//        => new((dynamic)number1.Value + (dynamic)number2.Value);
//    public static Number<TNumber> operator -(Number<TNumber> number1, Number<TNumber> number2)
//        => new((dynamic)number1.Value - (dynamic)number2.Value);
//    public static Number<TNumber> operator /(Number<TNumber> number1, Number<TNumber> number2)
//        => new((dynamic)number1.Value / (dynamic)number2.Value);
//    public static Number<TNumber> operator *(Number<TNumber> number1, Number<TNumber> number2)
//        => new((dynamic)number1.Value * (dynamic)number2.Value);

//    public override bool Equals(object obj) {
//        if (obj == null) return false;
//        try {
//            var number = obj as Number<TNumber>;
//            if (number == null) return false;
//            return this == number;
//        } catch { return false; }
//    }
//    public override int GetHashCode() => HashCode.Combine(Value);
//    public static bool operator ==(Number<TNumber> number1, Number<TNumber> number2)
//        => (dynamic)number1.Value == (dynamic)number2.Value;
//    public static bool operator !=(Number<TNumber> number1, Number<TNumber> number2)
//        => (dynamic)number1.Value != (dynamic)number2.Value;
//    public static bool operator >(Number<TNumber> number1, Number<TNumber> number2)
//        => (dynamic)number1.Value > (dynamic)number2.Value;
//    public static bool operator <(Number<TNumber> number1, Number<TNumber> number2)
//        => (dynamic)number1.Value < (dynamic)number2.Value;

//    public static implicit operator TNumber(Number<TNumber> number)
//        => number.Value;
//    public static implicit operator Number<TNumber>(TNumber number)
//        => new(number);

//    #endregion
//}
}