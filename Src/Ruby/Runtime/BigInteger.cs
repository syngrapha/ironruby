// Decompiled with JetBrains decompiler
// Type: Microsoft.Scripting.Math.BigInteger
// Assembly: Microsoft.Dynamic, Version=1.2.0.0, Culture=neutral, PublicKeyToken=7f709c5b713576e1
// MVID: CB62E182-10C4-4227-B1C0-1FCF6FA87778
// Assembly location: C:\Dev\ironruby-netcore\Util\References\DynamicLanguageRuntime.1.2.0-alpha1\lib\net45\Microsoft.Dynamic.dll

using Microsoft.Scripting.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.Scripting.Math
{
  /// <summary>arbitrary precision integers</summary>
  [Serializable]
  public sealed class BigInteger : IFormattable, IComparable, IEquatable<BigInteger>
  {
    public static readonly BigInteger Zero = new BigInteger((System.Numerics.BigInteger)0);
    public static readonly BigInteger One = new BigInteger((System.Numerics.BigInteger)1);
    internal readonly System.Numerics.BigInteger Value;

    public BigInteger(System.Numerics.BigInteger value)
    {
      this.Value = value;
    }

    [CLSCompliant(false)]
    public static BigInteger Create(ulong v)
    {
      return new BigInteger(new System.Numerics.BigInteger(v));
    }

    [CLSCompliant(false)]
    public static BigInteger Create(uint v)
    {
      return new BigInteger(new System.Numerics.BigInteger(v));
    }

    public static BigInteger Create(long v)
    {
      return new BigInteger(new System.Numerics.BigInteger(v));
    }

    public static BigInteger Create(int v)
    {
      return new BigInteger(new System.Numerics.BigInteger(v));
    }

    public static BigInteger Create(Decimal v)
    {
      return new BigInteger(new System.Numerics.BigInteger(v));
    }

    public static BigInteger Create(byte[] v)
    {
      return new BigInteger(v);
    }

    public static BigInteger Create(double v)
    {
      return new BigInteger(new System.Numerics.BigInteger(v));
    }

    public static implicit operator BigInteger(byte i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    [CLSCompliant(false)]
    public static implicit operator BigInteger(sbyte i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    public static implicit operator BigInteger(short i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    [CLSCompliant(false)]
    public static implicit operator BigInteger(ushort i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    [CLSCompliant(false)]
    public static implicit operator BigInteger(uint i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    public static implicit operator BigInteger(int i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    [CLSCompliant(false)]
    public static implicit operator BigInteger(ulong i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    public static implicit operator BigInteger(long i)
    {
      return new BigInteger((System.Numerics.BigInteger)i);
    }

    public static implicit operator BigInteger(Decimal self)
    {
      return new BigInteger((System.Numerics.BigInteger)self);
    }

    public static explicit operator BigInteger(double self)
    {
      return new BigInteger((System.Numerics.BigInteger)self);
    }

    public static explicit operator BigInteger(float self)
    {
      return new BigInteger((System.Numerics.BigInteger)self);
    }

    public static explicit operator double(BigInteger self)
    {
      return (double)self.Value;
    }

    public static explicit operator float(BigInteger self)
    {
      return (float)self.Value;
    }

    public static explicit operator Decimal(BigInteger self)
    {
      return (Decimal)self.Value;
    }

    public static explicit operator byte(BigInteger self)
    {
      return (byte)self.Value;
    }

    [CLSCompliant(false)]
    public static explicit operator sbyte(BigInteger self)
    {
      return (sbyte)self.Value;
    }

    [CLSCompliant(false)]
    public static explicit operator ushort(BigInteger self)
    {
      return (ushort)self.Value;
    }

    public static explicit operator short(BigInteger self)
    {
      return (short)self.Value;
    }

    [CLSCompliant(false)]
    public static explicit operator uint(BigInteger self)
    {
      return (uint)self.Value;
    }

    public static explicit operator int(BigInteger self)
    {
      return (int)self.Value;
    }

    public static explicit operator long(BigInteger self)
    {
      return (long)self.Value;
    }

    [CLSCompliant(false)]
    public static explicit operator ulong(BigInteger self)
    {
      return (ulong)self.Value;
    }

    public static implicit operator BigInteger(System.Numerics.BigInteger value)
    {
      return new BigInteger(value);
    }

    public static implicit operator System.Numerics.BigInteger(BigInteger value)
    {
      return value.Value;
    }

    public BigInteger(BigInteger copy)
    {
      if (object.ReferenceEquals((object)copy, (object)null))
        throw new ArgumentNullException(nameof(copy));
      this.Value = copy.Value;
    }

    public BigInteger(byte[] data)
    {
      ContractUtils.RequiresNotNull((object)data, nameof(data));
      this.Value = new System.Numerics.BigInteger(data);
    }

    public BigInteger(int sign, byte[] data)
    {
      ContractUtils.RequiresNotNull((object)data, nameof(data));
      ContractUtils.Requires(sign >= -1 && sign <= 1, nameof(sign));
      this.Value = new System.Numerics.BigInteger(data);
      if (sign >= 0)
        return;
      this.Value = -this.Value;
    }

    [CLSCompliant(false)]
    public BigInteger(int sign, uint[] data)
    {
      ContractUtils.RequiresNotNull((object)data, nameof(data));
      ContractUtils.Requires(sign >= -1 && sign <= 1, nameof(sign));
      int length = BigInteger.GetLength(data);
      ContractUtils.Requires(length == 0 || sign != 0, nameof(sign));
      if (length == 0)
      {
        this.Value = (System.Numerics.BigInteger)0;
      }
      else
      {
        bool flag = ((int)data[length - 1] & int.MinValue) != 0;
        byte[] numArray1 = new byte[length * 4 + (flag ? 1 : 0)];
        int num1 = 0;
        for (int index1 = 0; index1 < length; ++index1)
        {
          ulong num2 = (ulong)data[index1];
          byte[] numArray2 = numArray1;
          int index2 = num1;
          int num3 = index2 + 1;
          int num4 = (int)(byte)(num2 & (ulong)byte.MaxValue);
          numArray2[index2] = (byte)num4;
          byte[] numArray3 = numArray1;
          int index3 = num3;
          int num5 = index3 + 1;
          int num6 = (int)(byte)(num2 >> 8 & (ulong)byte.MaxValue);
          numArray3[index3] = (byte)num6;
          byte[] numArray4 = numArray1;
          int index4 = num5;
          int num7 = index4 + 1;
          int num8 = (int)(byte)(num2 >> 16 & (ulong)byte.MaxValue);
          numArray4[index4] = (byte)num8;
          byte[] numArray5 = numArray1;
          int index5 = num7;
          num1 = index5 + 1;
          int num9 = (int)(byte)(num2 >> 24 & (ulong)byte.MaxValue);
          numArray5[index5] = (byte)num9;
        }
        this.Value = new System.Numerics.BigInteger(numArray1);
        if (sign >= 0)
          return;
        this.Value = -this.Value;
      }
    }

    [CLSCompliant(false)]
    public uint[] GetWords()
    {
      return this.Value.GetWords();
    }

    public int GetBitCount()
    {
      return this.Value.GetBitCount();
    }

    public int GetWordCount()
    {
      return this.Value.GetWordCount();
    }

    public int GetByteCount()
    {
      return this.Value.GetByteCount();
    }

    /// <summary>Return the sign of this BigInteger: -1, 0, or 1.</summary>
    public int Sign
    {
      get
      {
        return this.Value.Sign;
      }
    }

    public bool AsInt64(out long ret)
    {
      if (this.Value >= long.MinValue && this.Value <= long.MaxValue)
      {
        ret = (long)this.Value;
        return true;
      }
      ret = 0L;
      return false;
    }

    [CLSCompliant(false)]
    public bool AsUInt32(out uint ret)
    {
      if (this.Value >= 0L && this.Value <= (long)uint.MaxValue)
      {
        ret = (uint)this.Value;
        return true;
      }
      ret = 0U;
      return false;
    }

    [CLSCompliant(false)]
    public bool AsUInt64(out ulong ret)
    {
      if (this.Value >= 0UL && this.Value <= ulong.MaxValue)
      {
        ret = (ulong)this.Value;
        return true;
      }
      ret = 0UL;
      return false;
    }

    public bool AsInt32(out int ret)
    {
      if (this.Value >= (long)int.MinValue && this.Value <= (long)int.MaxValue)
      {
        ret = (int)this.Value;
        return true;
      }
      ret = 0;
      return false;
    }

    [CLSCompliant(false)]
    public uint ToUInt32()
    {
      return (uint)this.Value;
    }

    public int ToInt32()
    {
      return (int)this.Value;
    }

    public Decimal ToDecimal()
    {
      return (Decimal)this.Value;
    }

    [CLSCompliant(false)]
    public ulong ToUInt64()
    {
      return (ulong)this.Value;
    }

    public long ToInt64()
    {
      return (long)this.Value;
    }

    private static int GetLength(uint[] data)
    {
      int index = data.Length - 1;
      while (index >= 0 && (int)data[index] == 0)
        --index;
      return index + 1;
    }

    public static int Compare(BigInteger x, BigInteger y)
    {
      return System.Numerics.BigInteger.Compare(x.Value, y.Value);
    }

    public static bool operator ==(BigInteger x, int y)
    {
      return x.Value == (long)y;
    }

    public static bool operator !=(BigInteger x, int y)
    {
      return x.Value != (long)y;
    }

    public static bool operator ==(BigInteger x, double y)
    {
      if (object.ReferenceEquals((object)x, (object)null))
        throw new ArgumentNullException(nameof(x));
      if (y % 1.0 != 0.0)
        return false;
      return x.Value == (System.Numerics.BigInteger)y;
    }

    public static bool operator ==(double x, BigInteger y)
    {
      return y == x;
    }

    public static bool operator !=(BigInteger x, double y)
    {
      return !(x == y);
    }

    public static bool operator !=(double x, BigInteger y)
    {
      return !(x == y);
    }

    public static bool operator ==(BigInteger x, BigInteger y)
    {
      return BigInteger.Compare(x, y) == 0;
    }

    public static bool operator !=(BigInteger x, BigInteger y)
    {
      return BigInteger.Compare(x, y) != 0;
    }

    public static bool operator <(BigInteger x, BigInteger y)
    {
      return BigInteger.Compare(x, y) < 0;
    }

    public static bool operator <=(BigInteger x, BigInteger y)
    {
      return BigInteger.Compare(x, y) <= 0;
    }

    public static bool operator >(BigInteger x, BigInteger y)
    {
      return BigInteger.Compare(x, y) > 0;
    }

    public static bool operator >=(BigInteger x, BigInteger y)
    {
      return BigInteger.Compare(x, y) >= 0;
    }

    public static BigInteger Add(BigInteger x, BigInteger y)
    {
      return x + y;
    }

    public static BigInteger operator +(BigInteger x, BigInteger y)
    {
      return new BigInteger(x.Value + y.Value);
    }

    public static BigInteger Subtract(BigInteger x, BigInteger y)
    {
      return x - y;
    }

    public static BigInteger operator -(BigInteger x, BigInteger y)
    {
      return new BigInteger(x.Value - y.Value);
    }

    public static BigInteger Multiply(BigInteger x, BigInteger y)
    {
      return x * y;
    }

    public static BigInteger operator *(BigInteger x, BigInteger y)
    {
      return new BigInteger(x.Value * y.Value);
    }

    public static BigInteger Divide(BigInteger x, BigInteger y)
    {
      return x / y;
    }

    public static BigInteger operator /(BigInteger x, BigInteger y)
    {
      BigInteger remainder;
      return BigInteger.DivRem(x, y, out remainder);
    }

    public static BigInteger Mod(BigInteger x, BigInteger y)
    {
      return x % y;
    }

    public static BigInteger operator %(BigInteger x, BigInteger y)
    {
      BigInteger remainder;
      BigInteger.DivRem(x, y, out remainder);
      return remainder;
    }

    public static BigInteger DivRem(BigInteger x, BigInteger y, out BigInteger remainder)
    {
      System.Numerics.BigInteger remainder1;
      System.Numerics.BigInteger bigInteger = System.Numerics.BigInteger.DivRem(x.Value, y.Value, out remainder1);
      remainder = new BigInteger(remainder1);
      return new BigInteger(bigInteger);
    }

    public static BigInteger BitwiseAnd(BigInteger x, BigInteger y)
    {
      return x & y;
    }

    public static BigInteger operator &(BigInteger x, BigInteger y)
    {
      return new BigInteger(x.Value & y.Value);
    }

    public static BigInteger BitwiseOr(BigInteger x, BigInteger y)
    {
      return x | y;
    }

    public static BigInteger operator |(BigInteger x, BigInteger y)
    {
      return new BigInteger(x.Value | y.Value);
    }

    public static BigInteger Xor(BigInteger x, BigInteger y)
    {
      return x ^ y;
    }

    public static BigInteger operator ^(BigInteger x, BigInteger y)
    {
      return new BigInteger(x.Value ^ y.Value);
    }

    public static BigInteger LeftShift(BigInteger x, int shift)
    {
      return x << shift;
    }

    public static BigInteger operator <<(BigInteger x, int shift)
    {
      return new BigInteger(x.Value << shift);
    }

    public static BigInteger RightShift(BigInteger x, int shift)
    {
      return x >> shift;
    }

    public static BigInteger operator >>(BigInteger x, int shift)
    {
      return new BigInteger(x.Value >> shift);
    }

    public static BigInteger Negate(BigInteger x)
    {
      return -x;
    }

    public static BigInteger operator -(BigInteger x)
    {
      return new BigInteger(-x.Value);
    }

    public BigInteger OnesComplement()
    {
      return ~this;
    }

    public static BigInteger operator ~(BigInteger x)
    {
      return new BigInteger(~x.Value);
    }

    public BigInteger Abs()
    {
      return new BigInteger(System.Numerics.BigInteger.Abs(this.Value));
    }

    public BigInteger Power(int exp)
    {
      return new BigInteger(System.Numerics.BigInteger.Pow(this.Value, exp));
    }

    public BigInteger ModPow(int power, BigInteger mod)
    {
      return new BigInteger(System.Numerics.BigInteger.ModPow(this.Value, (System.Numerics.BigInteger)power, mod.Value));
    }

    public BigInteger ModPow(BigInteger power, BigInteger mod)
    {
      return new BigInteger(System.Numerics.BigInteger.ModPow(this.Value, power.Value, mod.Value));
    }

    public BigInteger Square()
    {
      return this * this;
    }

    public static BigInteger Parse(string str)
    {
      return new BigInteger(System.Numerics.BigInteger.Parse(str));
    }

    public override string ToString()
    {
      return this.ToString(10);
    }

    public string ToString(int @base)
    {
      return BigIntegerToString(this.GetWords(), this.Sign, @base, false);
    }

    public string ToString(string format)
    {
      return this.Value.ToString(format);
    }

    public override int GetHashCode()
    {
      return this.Value.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      return this.Equals(obj as BigInteger);
    }

    public bool Equals(BigInteger other)
    {
      if (object.ReferenceEquals((object)other, (object)null))
        return false;
      return this == other;
    }

    public bool IsNegative()
    {
      return this.Value.Sign < 0;
    }

    public bool IsZero()
    {
      return this.Value.Sign == 0;
    }

    public bool IsPositive()
    {
      return this.Value.Sign > 0;
    }

    public bool IsEven
    {
      get
      {
        return this.Value.IsEven;
      }
    }

    public bool IsPowerOfTwo
    {
      get
      {
        return this.Value.IsPowerOfTwo;
      }
    }

    public double Log(double newBase)
    {
      return System.Numerics.BigInteger.Log(this.Value, newBase);
    }

    /// <summary>Calculates the natural logarithm of the BigInteger.</summary>
    public double Log()
    {
      return System.Numerics.BigInteger.Log(this.Value);
    }

    /// <summary>Calculates log base 10 of a BigInteger.</summary>
    public double Log10()
    {
      return System.Numerics.BigInteger.Log10(this.Value);
    }

    public int CompareTo(object obj)
    {
      if (obj == null)
        return 1;
      BigInteger y = obj as BigInteger;
      if (object.ReferenceEquals((object)y, (object)null))
        throw new ArgumentException("expected integer");
      return BigInteger.Compare(this, y);
    }

    /// <summary>
    /// Return the value of this BigInteger as a little-endian twos-complement
    /// byte array, using the fewest number of bytes possible. If the value is zero,
    /// return an array of one byte whose element is 0x00.
    /// </summary>
    public byte[] ToByteArray()
    {
      return this.Value.ToByteArray();
    }

    public string ToString(IFormatProvider provider)
    {
      return this.Value.ToString(provider);
    }

    string IFormattable.ToString(string format, IFormatProvider formatProvider)
    {
      return this.Value.ToString(format, formatProvider);
    }

    private static readonly uint[] groupRadixValues = new uint[37]
{
      0U,
      0U,
      2147483648U,
      3486784401U,
      1073741824U,
      1220703125U,
      2176782336U,
      1977326743U,
      1073741824U,
      3486784401U,
      1000000000U,
      2357947691U,
      429981696U,
      815730721U,
      1475789056U,
      2562890625U,
      268435456U,
      410338673U,
      612220032U,
      893871739U,
      1280000000U,
      1801088541U,
      2494357888U,
      3404825447U,
      191102976U,
      244140625U,
      308915776U,
      387420489U,
      481890304U,
      594823321U,
      729000000U,
      887503681U,
      1073741824U,
      1291467969U,
      1544804416U,
      1838265625U,
      2176782336U
};

    private static readonly uint[] maxCharsPerDigit = new uint[37]
{
      0U,
      0U,
      31U,
      20U,
      15U,
      13U,
      12U,
      11U,
      10U,
      10U,
      9U,
      9U,
      8U,
      8U,
      8U,
      8U,
      7U,
      7U,
      7U,
      7U,
      7U,
      7U,
      7U,
      7U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U,
      6U
};

    private static uint div(uint[] n, ref int nl, uint d)
    {
      ulong num1 = 0;
      int index = nl;
      bool flag = false;
      while (--index >= 0)
      {
        ulong num2 = num1 << 32 | (ulong)n[index];
        uint num3 = (uint)(num2 / (ulong)d);
        n[index] = num3;
        if ((int)num3 == 0)
        {
          if (!flag)
            --nl;
        }
        else
          flag = true;
        num1 = num2 % (ulong)d;
      }
      return (uint)num1;
    }

    private static void AppendRadix(uint rem, uint radix, char[] tmp, StringBuilder buf, bool leadingZeros, bool lowerCase)
    {
      string str = lowerCase ? "0123456789abcdefghijklmnopqrstuvwxyz" : "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      int length = tmp.Length;
      int startIndex;
      uint num;
      for (startIndex = length; startIndex > 0 && (leadingZeros || (int)rem != 0); tmp[--startIndex] = str[(int)num])
      {
        num = rem % radix;
        rem /= radix;
      }
      if (leadingZeros)
        buf.Append(tmp);
      else
        buf.Append(tmp, startIndex, length - startIndex);
    }

    internal static string BigIntegerToString(uint[] d, int sign, int radix, bool lowerCase)
    {
      if (radix < 2 || radix > 36)
        throw ExceptionUtils.MakeArgumentOutOfRangeException(nameof(radix), (object)radix, "radix must be between 2 and 36");
      int length = d.Length;
      if (length == 0)
        return "0";
      List<uint> uintList1 = new List<uint>();
      uint groupRadixValue = groupRadixValues[radix];
      while (length > 0)
      {
        uint num = div(d, ref length, groupRadixValue);
        uintList1.Add(num);
      }
      StringBuilder buf = new StringBuilder();
      if (sign == -1)
        buf.Append("-");
      int num1 = uintList1.Count - 1;
      char[] tmp = new char[(int)maxCharsPerDigit[radix]];
      List<uint> uintList2 = uintList1;
      int index = num1;
      int num2 = index - 1;
      AppendRadix(uintList2[index], (uint)radix, tmp, buf, false, lowerCase);
      while (num2 >= 0)
        AppendRadix(uintList1[num2--], (uint)radix, tmp, buf, true, lowerCase);
      if (buf.Length != 0)
        return buf.ToString();
      return "0";
    }

    public double ToFloat64()
    {
      return double.Parse(ToString(),
          System.Globalization.NumberStyles.Number,
          System.Globalization.CultureInfo.InvariantCulture.NumberFormat
      );
    }

    public bool TryToFloat64(out double result)
    {
      return StringUtils.TryParseDouble(ToString(), NumberStyles.Number, (IFormatProvider)CultureInfo.InvariantCulture.NumberFormat, out result);
    }

  }
}
