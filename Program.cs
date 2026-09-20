using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Algorithms;
using DataStructures;
using IterTools;

#region Init
var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
Console.SetOut(sw);

StreamReader? sr = null;
if (args.Length > 0)
{
    sr = new StreamReader(args[0]);
    Console.SetIn(sr);

    if (args.Length > 1)
    {
        sw = new StreamWriter(args[1]) { AutoFlush = false };
        Console.SetOut(sw);
    }
}
#endregion

#region Entry
Solve();
Console.Out.Flush();
sw.Dispose();
sr?.Dispose();
#endregion

#region Answer


[MethodImpl(MethodImplOptions.AggressiveOptimization)]
static void Solve()
{

}

#endregion

#region Library 

/// <summary>
/// 入出力に関する補助機能を提供する．
/// </summary>
static class IOUtil
{
    /// <summary>
    /// IEnumerableの先頭2要素をタプル分解構文で受け取れるようにする．
    /// 内部的にはIEnumeratorへのDeconstructに委譲する．
    /// </summary>
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2)
        => (item1, item2) = enumerator.GetEnumerator();

    /// <summary>
    /// IEnumerableの先頭3要素をタプル分解構文で受け取れるようにする．
    /// 内部的にはIEnumeratorへのDeconstructに委譲する．
    /// </summary>
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3)
        => (item1, item2, item3) = enumerator.GetEnumerator();

    /// <summary>
    /// IEnumerableの先頭4要素をタプル分解構文で受け取れるようにする．
    /// 内部的にはIEnumeratorへのDeconstructに委譲する．
    /// </summary>
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4)
        => (item1, item2, item3, item4) = enumerator.GetEnumerator();

    /// <summary>
    /// IEnumerableの先頭5要素をタプル分解構文で受け取れるようにする．
    /// 内部的にはIEnumeratorへのDeconstructに委譲する．
    /// </summary>
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5)
        => (item1, item2, item3, item4, item5) = enumerator.GetEnumerator();

    /// <summary>
    /// IEnumerableの先頭6要素をタプル分解構文で受け取れるようにする．
    /// 内部的にはIEnumeratorへのDeconstructに委譲する．
    /// </summary>
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6)
        => (item1, item2, item3, item4, item5, item6) = enumerator.GetEnumerator();

    /// <summary>
    /// IEnumerableの先頭7要素をタプル分解構文で受け取れるようにする．
    /// 内部的にはIEnumeratorへのDeconstructに委譲する．
    /// </summary>
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7)
        => (item1, item2, item3, item4, item5, item6, item7) = enumerator.GetEnumerator();

    /// <summary>
    /// IEnumerableの先頭8要素をタプル分解構文で受け取れるようにする．
    /// 内部的にはIEnumeratorへのDeconstructに委譲する．
    /// </summary>
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7, out T item8)
        => (item1, item2, item3, item4, item5, item6, item7, item8) = enumerator.GetEnumerator();

    /// <summary>
    /// IEnumeratorから2要素を取り出し，タプル分解構文で受け取れるようにする．
    /// </summary>
    /// <exception cref="ArgumentException">要素数が2個に満たない，または2個を超える場合．</exception>
    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2)
    {
        if (!enumerator.MoveNext())
            throw new ArgumentException("Empty.");

        item1 = enumerator.Current;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item2 = enumerator.Current;
    }

    /// <summary>
    /// IEnumeratorから3要素を取り出し，タプル分解構文で受け取れるようにする．
    /// </summary>
    /// <exception cref="ArgumentException">要素数が3個に満たない，または3個を超える場合．</exception>
    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3)
    {
        (item1, item2) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack");

        item3 = enumerator.Current;
    }

    /// <summary>
    /// IEnumeratorから4要素を取り出し，タプル分解構文で受け取れるようにする．
    /// </summary>
    /// <exception cref="ArgumentException">要素数が4個に満たない，または4個を超える場合．</exception>
    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4)
    {
        (item1, item2, item3) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item4 = enumerator.Current;
    }

    /// <summary>
    /// IEnumeratorから5要素を取り出し，タプル分解構文で受け取れるようにする．
    /// </summary>
    /// <exception cref="ArgumentException">要素数が5個に満たない，または5個を超える場合．</exception>
    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5)
    {
        (item1, item2, item3, item4) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item5 = enumerator.Current;
    }

    /// <summary>
    /// IEnumeratorから6要素を取り出し，タプル分解構文で受け取れるようにする．
    /// </summary>
    /// <exception cref="ArgumentException">要素数が6個に満たない，または6個を超える場合．</exception>
    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6)
    {
        (item1, item2, item3, item4, item5) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item6 = enumerator.Current;
    }

    /// <summary>
    /// IEnumeratorから7要素を取り出し，タプル分解構文で受け取れるようにする．
    /// </summary>
    /// <exception cref="ArgumentException">要素数が7個に満たない，または7個を超える場合．</exception>
    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7)
    {
        (item1, item2, item3, item4, item5, item6) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item7 = enumerator.Current;
    }

    /// <summary>
    /// IEnumeratorから8要素を取り出し，タプル分解構文で受け取れるようにする．
    /// </summary>
    /// <exception cref="ArgumentException">要素数が8個に満たない，または8個を超える場合．</exception>
    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7, out T item8)
    {
        (item1, item2, item3, item4, item5, item6, item7) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item8 = enumerator.Current;
    }

    /// <summary>
    /// 標準出力とデバッグ出力の両方にobjを1行で出力する．
    /// </summary>
    /// <param name="obj">出力する値．</param>
    public static void Print(object obj)
    {
        Console.WriteLine(obj);
        Debug.WriteLine(obj);
    }

    /// <summary>
    /// condがtrueなら"Yes"，falseなら"No"を標準出力とデバッグ出力の両方に出力する．
    /// </summary>
    /// <param name="cond">出力する真偽値．</param>
    /// <returns>condをそのまま返す．</returns>
    public static bool PrintYesOrNo(bool cond)
    {
        Console.WriteLine(cond ? "Yes" : "No");
        Debug.WriteLine(cond ? "Yes" : "No");
        return cond;
    }

    /// <summary>
    /// コレクションの各要素を"[e0, e1, ...]"の形式で標準出力とデバッグ出力の両方に出力する．
    /// </summary>
    /// <typeparam name="T">要素の型．</typeparam>
    /// <param name="e">出力するコレクション．空でないこと．</param>
    public static void PrintCollection<T>(IEnumerable<T> e)
    {
        var sb = new StringBuilder();
        sb.Append('[');
        foreach (var n in e)
            sb.Append(n).Append(", ");
        sb.Remove(sb.Length - 2, 2);
        sb.Append(']');
        Console.WriteLine(sb.ToString());
        Debug.WriteLine(sb.ToString());
    }
}

/// <summary>
/// 汎用的な型引数に対する事前条件検査をまとめたクラス．
/// </summary>
static class Exceptions
{
    /// <summary>
    /// TSが整数型（sbyte, byte, short, ushort, int, uint, long, ulong, BigIntegerのいずれか）でなければ例外を投げる．
    /// </summary>
    /// <typeparam name="T">検査対象の型．</typeparam>
    /// <exception cref="ArgumentException">Tが整数型でない場合．</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNotInteger<T>()
    {
        if (typeof(T) != typeof(sbyte) && typeof(T) != typeof(byte)
        && typeof(T) != typeof(short) && typeof(T) != typeof(ushort)
        && typeof(T) != typeof(int) && typeof(T) != typeof(uint)
        && typeof(T) != typeof(long) && typeof(T) != typeof(ulong)
        && typeof(T) != typeof(BigInteger))
            throw new ArgumentException("T must be an integer type.");
    }
}

/// <summary>
/// 型引数によって処理を分岐させるためのマーカーインターフェース．
/// </summary>
interface IFlag { }

/// <summary>IFlagがtrueであることを表すマーカー型．</summary>
struct True : IFlag { }

/// <summary>IFlagがfalseであることを表すマーカー型．</summary>
struct False : IFlag { }

/// <summary>
/// long値をCRC32によってハッシュ化し，Dictionary/HashSetのキーとして用いた際の検索を高速化するためのラッパー型．
/// </summary>
struct FastHashInt64(long value)
{
    public long Value { get; set; } = value;

    public override readonly int GetHashCode() => (int)Sse42.X64.Crc32(0UL, (ulong)Value);

    public static implicit operator FastHashInt64(long value) => new(value);
}

/// <summary>
/// ulong値をCRC32によってハッシュ化し，Dictionary/HashSetのキーとして用いた際の検索を高速化するためのラッパー型．
/// </summary>
struct FastHashUInt64(ulong value)
{
    public ulong Value { get; set; } = value;

    public override readonly int GetHashCode() => (int)Sse42.X64.Crc32(0UL, Value);

    public static implicit operator FastHashUInt64(ulong value) => new(value);
}

/// <summary>
/// 法998244353の下でのモジュラー演算を行う値型．
/// long，BigIntegerとの暗黙変換をサポートする．
/// </summary>
struct ModInt998244353
{
    const long _mod = 998244353;

    public static long Mod => _mod;
    public long Value { get; set; }

    /// <summary>
    /// valueをmodで正規化して初期化する．
    /// </summary>
    /// <param name="value">初期値．負数も可．</param>
    public ModInt998244353(long value)
    {
        Value = value % _mod;
        if (Value < 0)
            Value += _mod;
    }

    public static implicit operator ModInt998244353(long value) => new(value);
    public static implicit operator long(ModInt998244353 value) => value.Value;
    public static implicit operator ModInt998244353(BigInteger value) => new((long)(value % _mod));
    public static implicit operator BigInteger(ModInt998244353 value) => value.Value;

    public static ModInt998244353 operator +(ModInt998244353 a, ModInt998244353 b) => new(a.Value + b.Value);
    public static ModInt998244353 operator -(ModInt998244353 a, ModInt998244353 b) => new(a.Value - b.Value);
    public static ModInt998244353 operator *(ModInt998244353 a, ModInt998244353 b) => new(a.Value * b.Value);
    public static ModInt998244353 operator /(ModInt998244353 a, ModInt998244353 b) => new(a.Value * MathEx.ModInv(b.Value, _mod));
    public static ModInt998244353 operator %(ModInt998244353 a, ModInt998244353 b) => new(a.Value % b.Value);
    public static ModInt998244353 operator ++(ModInt998244353 a) => new(a.Value + 1);
    public static ModInt998244353 operator --(ModInt998244353 a) => new(a.Value - 1);
    public static ModInt998244353 operator -(ModInt998244353 a) => new(-a.Value);
    public static bool operator ==(ModInt998244353 a, ModInt998244353 b) => a.Value == b.Value;
    public static bool operator !=(ModInt998244353 a, ModInt998244353 b) => a.Value != b.Value;
    public static bool operator <(ModInt998244353 a, ModInt998244353 b) => a.Value < b.Value;
    public static bool operator >(ModInt998244353 a, ModInt998244353 b) => a.Value > b.Value;
    public static bool operator <=(ModInt998244353 a, ModInt998244353 b) => a.Value <= b.Value;
    public static bool operator >=(ModInt998244353 a, ModInt998244353 b) => a.Value >= b.Value;

    public override readonly string ToString() => Value.ToString();

    public override readonly bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null)
            return false;

        if (obj is ModInt998244353 modInt)
            return Value == modInt.Value;

        if (obj is long longValue)
            return Value == longValue;

        return false;
    }

    public override readonly int GetHashCode() => (int)Sse42.X64.Crc32(0UL, (ulong)Value);

    /// <summary>このインスタンスのmodにおける逆元を返す．</summary>
    /// <returns>Value * Inv() ≡ 1 (mod _mod) を満たす値．</returns>
    /// <remarks>計算量: O(log _mod)．</remarks>
    public readonly ModInt998244353 Inv() => new(MathEx.ModInv(Value, _mod));

    /// <summary>このインスタンスのexp乗をmod下で計算する．</summary>
    /// <param name="exp">指数．</param>
    /// <returns>Value^exp mod _mod．</returns>
    /// <remarks>計算量: O(log exp)．繰り返し二乗法（BigInteger.ModPow）を用いる．</remarks>
    public readonly ModInt998244353 Pow(long exp) => BigInteger.ModPow(Value, exp, _mod);
}

/// <summary>
/// 文字列のローリングハッシュを計算する機能を提供する．
/// </summary>
static class RollingHash
{
    /// <summary>ハッシュ計算に用いる基数．</summary>
    public static ulong Base { get; } = 100000007;

    /// <summary>
    /// 文字列全体のローリングハッシュ値を計算する．
    /// h = str[0] * b^(n - 1) + ... + str[^1] * b^0
    /// </summary>
    /// <param name="str">ハッシュ値を計算する文字列．</param>
    /// <returns>strのローリングハッシュ値．</returns>
    /// <remarks>計算量: O(|str|)．</remarks>
    public static ulong GetRollingHashCode(this string str)
    {
        var hashCode = 0UL;
        foreach (var c in str)
            hashCode = Base * hashCode + c;
        return hashCode;
    }

    /// <summary>
    /// strの各prefix（str[0..1], str[0..2], ...str[0..^0]）のローリングハッシュ値を先頭から順に列挙する．
    /// </summary>
    /// <param name="str">ハッシュ値を計算する文字列．</param>
    /// <returns>各prefixのローリングハッシュ値を先頭から順に返す列挙子．</returns>
    /// <remarks>計算量: 全体でO(|str|)．</remarks>
    public static IEnumerable<ulong> EnumeratePrefixHashCodes(this string str)
    {
        var hashCode = 0UL;
        foreach (var c in str)
            yield return hashCode = Base * hashCode + c;
    }
}

/// <summary>
/// 数論・数学に関する補助機能を提供する．
/// </summary>
static class MathEx
{
    /// <summary>xの平方根以上となる最小の整数を返す．</summary>
    /// <param name="x">対象の値．0以上であること．</param>
    /// <returns>n * n &gt;= x を満たす最小の整数n．</returns>
    /// <remarks>計算量: O(log x)．内部で二分探索を行う．</remarks>
    public static long CeilSqrt(long x) => BinarySearch.LowerBound(n => n * n, x, 0, 3037000500);

    /// <summary>xの平方根以下となる最大の整数を返す．</summary>
    /// <param name="x">対象の値．0以上であること．</param>
    /// <returns>n * n &lt;= x を満たす最大の整数n．</returns>
    /// <remarks>計算量: O(log x)．</remarks>
    public static long FloorSqrt(long x)
    {
        var sq = CeilSqrt(x);
        return (x == sq * sq) ? sq : sq - 1;
    }

    /// <summary>xの絶対値を2の累乗で表したときの指数の切り捨てを返す．xが負数の場合は結果に負号をつける．</summary>
    /// <param name="x">対象の値．</param>
    /// <returns>|x|が0でなければ floor(log2(|x|)) を，xが負数ならその符号を反転した値を返す．</returns>
    /// <remarks>計算量: O(1)．</remarks>
    public static int FloorLog2(long x)
    {
        var bits = (x << 1) >> 1;
        var y = FloorLog2((ulong)bits);
        return (bits != x) ? -y : y;
    }

    /// <summary>xを2の累乗で表したときの指数の切り上げを返す．</summary>
    /// <param name="x">対象の値．正数であること．</param>
    /// <returns>ceil(log2(x))．</returns>
    /// <remarks>計算量: O(1)．</remarks>
    public static int CeilLog2(long x)
    {
        var l = FloorLog2(x);
        return (1L << l < x) ? l + 1 : l;
    }

    /// <summary>xを2の累乗で表したときの指数の切り捨てを返す．</summary>
    /// <param name="x">対象の値．0でないこと．</param>
    /// <returns>floor(log2(x))．</returns>
    /// <remarks>計算量: O(1)．</remarks>
    public static int FloorLog2(ulong x) => 63 - BitOperations.LeadingZeroCount(x);

    /// <summary>
    /// xのy乗を整数演算で計算する（浮動小数点誤差なし）．
    /// </summary>
    /// <typeparam name="T">整数型．</typeparam>
    /// <param name="x">底．</param>
    /// <param name="y">指数．0以上であること．</param>
    /// <returns>x^y．</returns>
    /// <exception cref="ArgumentException">Tが整数型でない場合．</exception>
    /// <exception cref="ArgumentOutOfRangeException">yが負数の場合．</exception>
    /// <remarks>計算量: O(y)．繰り返し二乗法ではなく単純な累乗算であることに注意．</remarks>
    public static T PowInt<T>(T x, int y) where T : struct, INumber<T>
    {
        Exceptions.ThrowIfNotInteger<T>();

        if (y < 0)
            throw new ArgumentOutOfRangeException(nameof(y), "The exponent must be positive or zero.");

        var res = T.One;
        for (var i = 0; i < y; i++)
            res *= x;
        return res;
    }

    /// <summary>
    /// modを法としたnの逆元を，拡張ユークリッドの互除法を用いて計算する．
    /// </summary>
    /// <typeparam name="T">整数型．</typeparam>
    /// <param name="n">逆元を求める値．0でないこと．</param>
    /// <param name="mod">法．</param>
    /// <returns>n * result ≡ 1 (mod mod) を満たすresult．</returns>
    /// <exception cref="ArgumentException">Tが整数型でない場合，またはnとmodが互いに素でない場合．</exception>
    /// <exception cref="DivideByZeroException">nが0の場合．</exception>
    /// <remarks>計算量: O(log(min(n, mod)))．</remarks>
    public static T ModInv<T>(T n, T mod) where T : struct, INumber<T>
    {
        Exceptions.ThrowIfNotInteger<T>();

        if (n == T.Zero)
            throw new DivideByZeroException();

        var (nInv, _, gcd) = ComputeBezoutCoeff(n, mod);

        if (gcd != T.One)
            throw new ArgumentException("The argument is not coprime to the modulus.");

        return (nInv > T.Zero) ? nInv : nInv + mod;
    }

    /// <summary>
    /// 与えられた整数a，bを用いて，1次不定方程式ax + by = gcd(a, b)を解く．
    /// </summary>
    /// <typeparam name="T">整数型．</typeparam>
    /// <param name="a">xの係数</param>
    /// <param name="b">yの係数</param>
    /// <returns>(x, y, gcd(a, b))</returns>
    /// <remarks>計算量: O(log(min(a, b)))．</remarks>
    public static (T x, T y, T gcd) ComputeBezoutCoeff<T>(T a, T b) where T : struct, INumber<T>
    {
        Exceptions.ThrowIfNotInteger<T>();

        if (a == T.Zero)
            return (T.Zero, T.One, b);

        if (b == T.Zero)
            return (T.One, T.Zero, a);

        var q = a / b;
        var (x, y, gcd) = ComputeBezoutCoeff(b, a % b);
        return (y, x - q * y, gcd);
    }

    /// <summary>
    /// nの階乗を計算する．
    /// </summary>
    /// <typeparam name="T">整数型．</typeparam>
    /// <param name="n">対象の値．0以上であること．</param>
    /// <returns>n!．</returns>
    /// <exception cref="ArgumentException">Tが整数型でない場合．</exception>
    /// <exception cref="ArgumentOutOfRangeException">nが負数の場合．</exception>
    /// <remarks>計算量: O(n)．</remarks>
    public static T Factorial<T>(T n) where T : INumber<T>
    {
        Exceptions.ThrowIfNotInteger<T>();

        if (n < T.Zero)
            throw new ArgumentOutOfRangeException(nameof(n), "The argument must be positive or zero.");

        var f = T.One;
        for (var i = T.One; i <= n; i++)
            f *= i;
        return f;
    }

    /// <summary>
    /// modを法としたnの階乗を計算する．
    /// </summary>
    /// <typeparam name="T">整数型．</typeparam>
    /// <param name="n">対象の値．0以上であること．</param>
    /// <param name="mod">法．</param>
    /// <returns>n! % mod．</returns>
    /// <exception cref="ArgumentException">Tが整数型でない場合．</exception>
    /// <exception cref="ArgumentOutOfRangeException">nが負数の場合．</exception>
    /// <remarks>計算量: O(n)．</remarks>
    public static T Factorial<T>(T n, T mod) where T : INumber<T>
    {
        Exceptions.ThrowIfNotInteger<T>();

        if (n < T.Zero)
            throw new ArgumentOutOfRangeException(nameof(n), "The argument must be positive or zero.");

        var f = T.One;
        for (var i = T.One; i <= n; i++)
            f = f * i % mod;
        return f;
    }

    /// <summary>
    /// modを法とした場合の0 ~ nまでの階乗のテーブルを作る．
    /// </summary>
    /// <typeparam name="T">整数型．</typeparam>
    /// <param name="n">テーブルの最大添字．0以上であること．</param>
    /// <param name="mod">法．</param>
    /// <returns>table[i] == i! % mod を満たす，長さn + 1のテーブル．</returns>
    /// <exception cref="ArgumentException">Tが整数型でない場合．</exception>
    /// <exception cref="ArgumentOutOfRangeException">nが負数の場合．</exception>
    /// <remarks>計算量: O(n)．</remarks>
    public static T[] CreateFactorialTable<T>(T n, T mod) where T : struct, INumber<T>
    {
        Exceptions.ThrowIfNotInteger<T>();

        if (n < T.Zero)
            throw new ArgumentOutOfRangeException(nameof(n), "The argument must be positive or zero.");

        var table = new T[long.CreateChecked(n) + 1];
        table[0] = T.One;

        for (var i = T.One; i <= n; i++)
        {
            var idx = long.CreateChecked(i);
            table[idx] = table[idx - 1] * i % mod;
        }

        return table;
    }

    /// <summary>
    /// 998244353を法とした場合の0 ~ nまでの階乗のテーブルを作る．
    /// </summary>
    /// <param name="n">テーブルの最大添字．0以上であること．</param>
    /// <returns>table[i] == i! % 998244353 を満たす，長さn + 1のテーブル．</returns>
    /// <remarks>計算量: O(n)．</remarks>
    public static ModInt998244353[] CreateModFactorialTable(int n)
    {
        var table = new ModInt998244353[n + 1];
        table[0] = 1;

        for (var i = 1; i <= n; i++)
            table[i] = table[i - 1] * i;

        return table;
    }

    /// <summary>
    /// 998244353を法とした場合の0 ~ nまでの階乗の逆元のテーブルを作る．
    /// </summary>
    /// <param name="n">テーブルの最大添字．0以上であること．</param>
    /// <returns>table[i] == (1 / i!) % 998244353 を満たす，長さn + 1のテーブル．</returns>
    /// <remarks>計算量: O(n)．末尾の逆元計算にO(log 998244353)を要するが，それ以降は各要素O(1)で計算する．</remarks>
    public static ModInt998244353[] CreateModFactorialInvTable(int n)
    {
        var table = new ModInt998244353[n + 1];
        table[n] = Factorial(n, ModInt998244353.Mod);
        table[n] = table[n].Inv();

        for (var i = n - 1; i >= 0; i--)
            table[i] = table[i + 1] * (i + 1);

        return table;
    }

    /// <summary>
    /// Nの正の約数を全て昇順に列挙する．
    /// </summary>
    /// <param name="N">対象の値．正数であること．</param>
    /// <returns>Nの正の約数を昇順に並べたリスト．</returns>
    /// <remarks>計算量: O(√N + d log d)．dはNの約数の個数（試し割りにO(√N)，ソートにO(d log d)）．</remarks>
    public static List<long> CalcDivisors(long N)
    {
        List<long> divisors = [];

        for(var i = 1L; i * i <= N; i++) 
        {
            if (N % i != 0)
                continue;

            divisors.Add(i);

            if (N / i != i)
                divisors.Add(N / i);
        }

        divisors.Sort();

        return divisors;
    }

    /// <summary>
    /// 1 ~ nまでの各整数の正の約数のテーブルを作る．
    /// </summary>
    /// <param name="n">整数の最大値</param>
    /// <returns>table[i] := {iの全ての正の約数}を満たす長さn + 1のテーブル．</returns>
    /// <remarks>計算量: O(n log n)（調和級数の和）．</remarks>
    public static List<int>[] CreateDivisorTable(int n)
    {
        var table = new List<int>[n + 1];
        for (var i = 0; i < table.Length; i++)
            table[i] = [];

        for (var i = 1; i <= n; i++)
            for (var j = i; j <= n; j += i)
                table[j].Add(i);

        return table;
    }

    /// <summary>
    /// エラトステネスの篩を用いて，0 ~ maxまでの各整数が素数かどうかを判定するテーブルを作る．
    /// </summary>
    /// <param name="max">テーブルの最大添字．</param>
    /// <returns>isPrime[i] == (iが素数か) を満たす，長さmax + 1のテーブル．</returns>
    /// <remarks>計算量: O(max log log max)．</remarks>
    public static bool[] CreateIsPrimeTable(int max)
    {
        var isPrime = Enumerable.Repeat(true, max + 1).ToArray();
        isPrime[0] = isPrime[1] = false;

        for (var p = 2; p < isPrime.Length; p++)
        {
            if (!isPrime[p])
                continue;

            for (var q = p * 2; q < isPrime.Length; q += p)
                isPrime[q] = false;
        }

        return isPrime;
    }

    /// <summary>
    /// 試し割り法によりnを素因数分解する．
    /// </summary>
    /// <param name="n">素因数分解する値．正数であること．</param>
    /// <returns>(素因数, 指数)の組のリスト．素因数の昇順に並ぶ．</returns>
    /// <remarks>計算量: O(√n)．</remarks>
    public static List<(long Base, long Exp)> PrimeFactorize(long n)
    {
        var factors = new List<(long, long)>();
        for (var p = 2L; p * p <= n; p++)
        {
            if (n % p != 0)
                continue;

            var exp = 0;
            do
            {
                n /= p;
                exp++;
            } while (n % p == 0);

            factors.Add((p, exp));
        }

        if (n != 1)
            factors.Add((n, 1));

        return factors;
    }

    /// <summary>ユークリッドの互除法によりaとbの最大公約数を求める．</summary>
    /// <param name="a">対象の値．</param>
    /// <param name="b">対象の値．</param>
    /// <returns>gcd(a, b)．</returns>
    /// <remarks>計算量: O(log(min(a, b)))．</remarks>
    public static long Gcd(long a, long b) => (b == 0) ? a : Gcd(b, a % b);

    /// <summary>aとbをそれぞれの最大公約数で割り，互いに素な組にする．</summary>
    /// <param name="a">対象の値．</param>
    /// <param name="b">対象の値．</param>
    /// <returns>(a / gcd(a, b), b / gcd(a, b))．</returns>
    /// <remarks>計算量: O(log(min(a, b)))．</remarks>
    public static (long A, long B) MakeCoprime(long a, long b) => (a / Gcd(a, b), b / Gcd(a, b));
}

/// <summary>
/// ビット単位の操作をまとめたクラス．
/// </summary>
static class BitManipulations
{
    /// <summary>bitsの8バイトのバイト順を反転する（エンディアン変換）．</summary>
    /// <param name="bits">対象の値．</param>
    /// <returns>バイト順を反転した値．</returns>
    /// <remarks>計算量: O(1)．</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong ByteSwap(ulong bits)
    {
        var ret = bits << 56;
        ret |= (bits & 0x000000000000ff00) << 40;
        ret |= (bits & 0x0000000000ff0000) << 24;
        ret |= (bits & 0x00000000ff000000) << 8;
        ret |= (bits & 0x000000ff00000000) >> 8;
        ret |= (bits & 0x0000ff0000000000) >> 24;
        ret |= (bits & 0x00ff000000000000) >> 40;
        return ret | (bits >> 56);
    }

    /// <summary>bitsの中で最下位の立っているビットの位置を返す．</summary>
    /// <param name="bits">対象の値．</param>
    /// <returns>最下位の立っているビットの位置（0-indexed）．bitsが0の場合は64．</returns>
    /// <remarks>計算量: O(1)．</remarks>
    public static int FindFirstSet(ulong bits) => BitOperations.TrailingZeroCount(bits);

    /// <summary>
    /// bitsの中で最下位の立っているビットを0にクリアした上で，そのクリア後に最下位となる立っているビットの位置を返す．
    /// EnumerateSetsのように，立っているビットを下位から順に走査する際に用いる．
    /// </summary>
    /// <param name="bits">対象の値．呼び出し後，最下位の立っているビットがクリアされた値に書き換わる．</param>
    /// <returns>クリア後のbitsにおける最下位の立っているビットの位置（0-indexed）．立っているビットがなければ64．</returns>
    /// <remarks>計算量: O(1)．</remarks>
    public static int FindNextSet(ref ulong bits) => FindFirstSet(bits &= (bits - 1));

    /// <summary>
    /// bitsの中で立っているビットの位置を，下位から順に全て列挙する．
    /// </summary>
    /// <param name="bits">対象の値．</param>
    /// <returns>立っているビットの位置（0-indexed）を下位から順に返す列挙子．</returns>
    /// <remarks>計算量: O(k)．kはbitsの中で立っているビットの個数．</remarks>
    public static IEnumerable<int> EnumerateSets(ulong bits)
    {
        for (var i = FindFirstSet(bits); bits != 0; i = FindNextSet(ref bits))
            yield return i;
    }

    /// <summary>
    /// maskで指定した各ビット位置iと，そこからdelta離れた位置i + deltaのビットを入れ替える（ビットの転置に利用する）．
    /// </summary>
    /// <param name="x">対象の値．</param>
    /// <param name="mask">入れ替え元となるビット位置の集合．i + deltaの位置に0を立てておくこと．</param>
    /// <param name="delta">入れ替え先までのビット位置の差．</param>
    /// <returns>ビットを入れ替えた後の値．</returns>
    /// <remarks>計算量: O(1)．</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong DeltaSwap(ulong x, ulong mask, int delta)
    {
        var t = (x ^ (x >> delta)) & mask;
        return x ^ t ^ (t << delta);
    }
}

namespace IterTools
{
    /// <summary>
    /// 順列に関する機能を提供する．
    /// </summary>
    public static class Permutation
    {
        /// <summary>
        /// seqを辞書順で次の順列に書き換える（std::next_permutation相当）．
        /// </summary>
        /// <typeparam name="T">要素の型．</typeparam>
        /// <param name="seq">書き換え対象の列．</param>
        /// <returns>次の順列が存在すればtrue．seqが既に降順（辞書順で最大）であればfalseを返し，seqは昇順に並べ替えられる．</returns>
        /// <remarks>計算量: O(n)．nはseqの長さ．</remarks>
        public static bool Next<T>(Span<T> seq) where T : IComparable<T>
        {
            int i;
            for (i = seq.Length - 2; i >= 0 && seq[i].CompareTo(seq[i + 1]) >= 0; i--) ;

            if (i < 0)
                return false;

            int j;
            for (j = seq.Length - 1; j >= 0 && seq[j].CompareTo(seq[i]) <= 0; j--) ;

            (seq[i], seq[j]) = (seq[j], seq[i]);

            var subSeq = seq[(i + 1)..];
            for (var k = 0; k < subSeq.Length / 2; k++)
                (subSeq[k], subSeq[^(k + 1)]) = (subSeq[^(k + 1)], subSeq[k]);

            return true;
        }

        /// <summary>
        /// seqの要素から成る順列を，辞書順で最小のものから昇順に全て列挙する．
        /// seqがソート済みである必要はない．
        /// seqに重複する要素が含まれる場合は，相異なる順列のみを列挙する．
        /// </summary>
        /// <remarks>
        /// 返す配列は列挙のたびに新しく確保するので，そのまま保持してよい．
        /// アロケーションを避けたい場合はNextを直接使う．
        /// 計算量: 順列の総数をPとして，全体でO(P * n)．
        /// </remarks>
        public static IEnumerable<T[]> Enumerate<T>(T[] seq) where T : IComparable<T>
        {
            var p = new T[seq.Length];
            seq.CopyTo(p, 0);
            Array.Sort(p);

            do
            {
                yield return (T[])p.Clone();
            }
            while (Next<T>(p));
        }
    }
}

namespace Algorithms
{
    /// <summary>
    /// 単調な関数や配列に対する二分探索を提供する．
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// 半開区間[left, right)で単調増加である関数funcについて, func(x) = keyを満たすxの範囲の下限を返す.
        /// func(x) = keyを満たすxが存在しない場合は, func(x) > keyとなるxのうち最小のxを返す.
        /// </summary>
        /// <typeparam name="TKey">funcの返り値およびkeyの型．</typeparam>
        /// <param name="func">[left, right)で単調増加な関数．</param>
        /// <param name="key">探索するキー．</param>
        /// <param name="left">探索区間の下端（この値を含む）．</param>
        /// <param name="right">探索区間の上端（この値を含まない）．</param>
        /// <returns>func(x) &gt;= key を満たす最小のx．</returns>
        /// <remarks>計算量: O(log(right - left))．</remarks>
        public static long LowerBound<TKey>(Func<long, TKey> func, TKey key, long left, long right) where TKey : IComparable<TKey>
            => LowerBound(func, key, left, right, (x, y) => x.CompareTo(y));

        /// <summary>
        /// 半開区間[left, right)で単調増加である関数funcについて, func(x) = keyを満たすxの範囲の下限を，指定した比較方法を用いて返す.
        /// </summary>
        /// <typeparam name="TKey">funcの返り値およびkeyの型．</typeparam>
        /// <param name="func">[left, right)で単調増加な関数．</param>
        /// <param name="key">探索するキー．</param>
        /// <param name="left">探索区間の下端（この値を含む）．</param>
        /// <param name="right">探索区間の上端（この値を含まない）．</param>
        /// <param name="comparison">key及びfunc(x)の大小比較方法．</param>
        /// <returns>comparison(key, func(x)) &lt;= 0 を満たす最小のx．</returns>
        /// <remarks>計算量: O(log(right - left))．</remarks>
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static long LowerBound<TKey>(Func<long, TKey> func, TKey key, long left, long right, Comparison<TKey> comparison)
        {
            while (left < right)
            {
                var mid = left + ((right - left) >> 1);
                var y = func(mid);
                var comp = comparison(key, y);

                if (comp > 0)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }

        /// <summary>
        /// ソート済み配列arrについて, arr[x] = keyを満たすxの範囲の下限を返す.
        /// arr[x] = keyを満たすxが存在しない場合は, arr[x] > keyとなるxのうち最小のxを返す.
        /// </summary>
        /// <typeparam name="T">配列の要素の型．</typeparam>
        /// <param name="arr">昇順にソート済みの配列．</param>
        /// <param name="key">探索するキー．</param>
        /// <returns>arr[x] &gt;= key を満たす最小のx．</returns>
        /// <remarks>計算量: O(log n)．nはarrの長さ．</remarks>
        public static long LowerBound<T>(T[] arr, T key) where T : IComparable<T>
            => LowerBound(arr, key, (x, y) => x.CompareTo(y));

        /// <summary>
        /// ソート済み配列arrについて, arr[x] = keyを満たすxの範囲の下限を，指定した比較方法を用いて返す.
        /// </summary>
        /// <typeparam name="T">配列の要素の型．</typeparam>
        /// <param name="arr">comparisonの順序でソート済みの配列．</param>
        /// <param name="key">探索するキー．</param>
        /// <param name="comparison">key及びarrの要素の大小比較方法．</param>
        /// <returns>comparison(key, arr[x]) &lt;= 0 を満たす最小のx．</returns>
        /// <remarks>計算量: O(log n)．nはarrの長さ．</remarks>
        public static long LowerBound<T>(T[] arr, T key, Comparison<T> comparison)
            => LowerBound(i => arr[i], key, 0, arr.Length, comparison);

        /// <summary>
        /// 半開区間[left, right)で単調増加である関数funcについて, func(x) = keyを満たすxの範囲の上限を返す.
        /// func(x) = keyを満たすxが存在しない場合は, func(x) > keyとなるxのうち最小のxを返す.
        /// </summary>
        /// <typeparam name="TKey">funcの返り値およびkeyの型．</typeparam>
        /// <param name="func">[left, right)で単調増加な関数．</param>
        /// <param name="key">探索するキー．</param>
        /// <param name="left">探索区間の下端（この値を含む）．</param>
        /// <param name="right">探索区間の上端（この値を含まない）．</param>
        /// <returns>func(x) &gt; key を満たす最小のx．</returns>
        /// <remarks>計算量: O(log(right - left))．</remarks>
        public static long UpperBound<TKey>(Func<long, TKey> func, TKey key, long left, long right) where TKey : IComparable<TKey>
            => UpperBound(func, key, left, right, (x, y) => x.CompareTo(y));

        /// <summary>
        /// 半開区間[left, right)で単調増加である関数funcについて, func(x) = keyを満たすxの範囲の上限を，指定した比較方法を用いて返す.
        /// </summary>
        /// <typeparam name="TKey">funcの返り値およびkeyの型．</typeparam>
        /// <param name="func">[left, right)で単調増加な関数．</param>
        /// <param name="key">探索するキー．</param>
        /// <param name="left">探索区間の下端（この値を含む）．</param>
        /// <param name="right">探索区間の上端（この値を含まない）．</param>
        /// <param name="comparison">key及びfunc(x)の大小比較方法．</param>
        /// <returns>comparison(key, func(x)) &lt; 0 を満たす最小のx．</returns>
        /// <remarks>計算量: O(log(right - left))．</remarks>
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static long UpperBound<TKey>(Func<long, TKey> func, TKey key, long left, long right, Comparison<TKey> comparison)
        {
            while (left < right)
            {
                var mid = left + ((right - left) >> 1);
                var y = func(mid);
                var comp = comparison(key, y);

                if (comp >= 0)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }

        /// <summary>
        /// ソート済み配列arrについて, arr[x] = keyを満たすxの範囲の上限を返す.
        /// arr[x] = keyを満たすxが存在しない場合は, arr[x] > keyとなるxのうち最小のxを返す.
        /// </summary>
        /// <typeparam name="T">配列の要素の型．</typeparam>
        /// <param name="arr">昇順にソート済みの配列．</param>
        /// <param name="key">探索するキー．</param>
        /// <returns>arr[x] &gt; key を満たす最小のx．</returns>
        /// <remarks>計算量: O(log n)．nはarrの長さ．</remarks>
        public static long UpperBound<T>(T[] arr, T key) where T : IComparable<T>
            => UpperBound(arr, key, (x, y) => x.CompareTo(y));

        /// <summary>
        /// ソート済み配列arrについて, arr[x] = keyを満たすxの範囲の上限を，指定した比較方法comparisonを用いて返す.
        /// </summary>
        /// <typeparam name="T">配列の要素の型．</typeparam>
        /// <param name="arr">comparisonの順序でソート済みの配列．</param>
        /// <param name="key">探索するキー．</param>
        /// <param name="comparison">key及びarrの要素の大小比較方法．</param>
        /// <returns>comparison(key, arr[x]) &lt; 0 を満たす最小のx．</returns>
        /// <remarks>計算量: O(log n)．nはarrの長さ．</remarks>
        public static long UpperBound<T>(T[] arr, T key, Comparison<T> comparison)
            => UpperBound(i => arr[i], key, 0, arr.Length, comparison);
    }

    /// <summary>
    /// 座標圧縮を提供する．
    /// </summary>
    public static class CoordinatesCompression
    {
        /// <summary>
        /// coordsの各要素を，重複を除いた値の昇順順位（0-indexed）に置き換える．
        /// </summary>
        /// <typeparam name="T">座標の型．</typeparam>
        /// <param name="coords">圧縮対象の座標列．</param>
        /// <returns>coordsの各要素を，ソートして重複を除いた配列における出現位置に置き換えた配列．</returns>
        /// <remarks>計算量: O(n log n)．nはcoordsの長さ．</remarks>
        public static T[] Compress<T>(T[] coords) where T : INumber<T>
        {
            var sorted = coords.Distinct().ToArray();
            Array.Sort(sorted);

            var res = new T[coords.Length];
            for (var i = 0; i < res.Length; i++)
                res[i] = T.CreateChecked(Array.BinarySearch(sorted, coords[i]));

            return res;
        }
    }

    /// <summary>
    /// Manacherのアルゴリズムによる文字列の回文半径の計算を提供する．
    /// </summary>
    public static class Manacher
    {
        /// <summary>
        /// 各中心位置における最大の回文半径をManacherのアルゴリズムで計算する．
        /// 偶数長の回文も扱えるように，文字間に番兵文字を挿入した奇数長の文字列を渡すこと．
        /// </summary>
        /// <param name="s">対象の文字列．長さが奇数であること．</param>
        /// <returns>radius[i] := sのi文字目を中心とする最大の回文の半径（自身を含む片側の長さ）を満たすテーブル．</returns>
        /// <remarks>計算量: O(|s|)．</remarks>
        public static int[] CalcPalindromeRadius(string s)
        {
            Debug.Assert(s.Length % 2 != 0);

            var radius = new int[s.Length];
            int i = 0, j = 0;
            while (i < s.Length)
            {
                while (i - j >= 0 && i + j < s.Length && s[i - j] == s[i + j])
                    j++;
                radius[i] = j;
                var k = 1;
                while (i - k >= 0 && i + k < s.Length && k + radius[i - k] < j)
                {
                    radius[i + k] = radius[i - k];
                    k++;
                }
                i += k;
                j -= k;
            }

            return radius;
        }
    }

    /// <summary>
    /// グラフに関するアルゴリズムを提供する．
    /// </summary>
    public static class Graph
    {
        /// <summary>
        /// グラフをトポロジカルソートする（Kahnのアルゴリズム）．
        /// </summary>
        /// <param name="graph">graph[i]がノードiから辺が張られている先のノード番号の列である，隣接リスト形式のグラフ．</param>
        /// <returns>トポロジカル順に並べたノード番号のリスト．graphに閉路が含まれる場合は空のリストを返す．</returns>
        /// <remarks>計算量: O(V + E)．Vはノード数，Eは辺数．</remarks>
        public static List<int> TopologicalSort(List<int>[] graph)
        {
            var inDegrees = new int[graph.Length];

            foreach (var node in graph)
            {
                foreach (var to in node)
                    inDegrees[to]++;
            }

            var q = new Queue<int>();

            for (var i = 0; i < inDegrees.Length; i++)
            {
                if (inDegrees[i] == 0)
                    q.Enqueue(i);
            }

            var result = new List<int>();

            while (q.TryDequeue(out var from))
            {
                result.Add(from);

                foreach (var to in graph[from])
                {
                    if (--inDegrees[to] == 0)
                        q.Enqueue(to);
                }
            }

            if (result.Count < graph.Length)
            {
                result.Clear();
                return result;
            }

            return result;
        }

        /// <summary>
        /// Kosarajuのアルゴリズムにより，有向グラフの強連結成分（SCC）を分解する．
        /// </summary>
        /// <param name="graph">graph[i]がノードiから辺が張られている先のノード番号の列である，隣接リスト形式のグラフ．</param>
        /// <returns>各強連結成分に属するノード番号の集合の配列．</returns>
        /// <remarks>計算量: O(V + E)．Vはノード数，Eは辺数．</remarks>
        public static HashSet<int>[] GetSCCs(List<int>[] graph)
        {
            var visited = (graph.Length <= 1024) ? stackalloc bool[graph.Length] : new bool[graph.Length];
            var postorder = new int[graph.Length];
            var nextID = 0;
            for (var root = 0; root < graph.Length; root++)
            {
                if (visited[root])
                    continue;
                Dfs<True>(graph, root, null, visited, postorder, ref nextID);
            }

            var graphRev = Enumerable.Range(0, graph.Length).Select(_ => new List<int>()).ToArray();
            for (var i = 0; i < graph.Length; i++)
            {
                foreach (var next in graph[i])
                    graphRev[next].Add(i);
            }

            var sccs = new List<HashSet<int>>();
            visited.Clear();
            for (var i = postorder.Length - 1; i >= 0; i--)
            {
                var root = postorder[i];
                if (visited[root])
                    continue;
                sccs.Add(new HashSet<int>());
                Dfs<False>(graphRev, root, sccs[^1], visited, null, ref nextID);
            }

            return sccs.ToArray();

            // AssignIDsがTrueの場合は帰りがけ順（postorder）を記録し，Falseの場合はconnectedに到達可能なノードを集める．
            static void Dfs<AssignIDs>(List<int>[] graph, int node, HashSet<int>? connected, Span<bool> visited, int[]? postorder, ref int nodeCount) where AssignIDs : struct, IFlag
            {
                visited[node] = true;

                if (typeof(AssignIDs) == typeof(False))
                    connected!.Add(node);

                foreach (var next in graph[node])
                {
                    if (visited[next])
                        continue;
                    Dfs<AssignIDs>(graph, next, connected, visited, postorder, ref nodeCount);
                }

                if (typeof(AssignIDs) == typeof(True))
                    postorder![nodeCount++] = node;
            }
        }

        /// <summary>
        /// ダイクストラ法により，startから各ノードまでの最短距離を計算する．辺の重みは非負であること．
        /// </summary>
        /// <typeparam name="T">辺の重みの型．</typeparam>
        /// <param name="graph">graph[i]がノードiから張られている(行き先ノード番号, 辺の重み)の組の列である，隣接リスト形式のグラフ．</param>
        /// <param name="weightMax">到達不能であることを表す値として用いる，重みの最大値．</param>
        /// <param name="start">始点のノード番号．</param>
        /// <param name="pqSize">内部で使用する優先度付きキューの初期容量．</param>
        /// <returns>dists[i] := startからノードiまでの最短距離を満たすテーブル．到達不能な場合はweightMax．</returns>
        /// <remarks>計算量: O((V + E) log V)．Vはノード数，Eは辺数．</remarks>
        public static T[] DijkstraSearch<T>(List<(int, T)>[] graph, T weightMax, int start, int pqSize = 1000000) where T : struct, INumber<T>
        {
            var dists = new T[graph.Length];
            Array.Fill(dists, weightMax);
            dists[start] = T.Zero;
            var queue = new PriorityQueue<int, T>(pqSize);
            queue.Enqueue(start, dists[start]);

            while (queue.TryDequeue(out int node, out T dist))
            {
                if (dist > dists[node])
                    continue;

                foreach ((var to, var cost) in graph[node])
                {
                    var newDist = dist + cost;
                    if (newDist < dists[to])
                        queue.Enqueue(to, dists[to] = newDist);
                }
            }

            return dists;
        }
    }
}

namespace DataStructures
{
    /// <summary>
    /// Union-Find木（素集合データ構造）．ノードのグループ分けと，グループの併合・判定をほぼ定数時間で行う．
    /// </summary>
    public class UnionFindTrees
    {
        readonly int[] _parentOf;
        readonly int[] _sizes;

        /// <summary>
        /// 0 ~ size - 1のノードが，それぞれ単独のグループを成す状態で初期化する．
        /// </summary>
        /// <param name="size">ノード数．</param>
        public UnionFindTrees(int size)
        {
            _parentOf = Enumerable.Repeat(-1, size).ToArray();
            _sizes = Enumerable.Repeat(1, size).ToArray();
        }

        /// <summary>ノードnが属するグループの代表（根）ノード番号を返す．経路圧縮を行う．</summary>
        /// <param name="n">対象のノード番号．</param>
        /// <returns>nが属するグループの根ノード番号．</returns>
        /// <remarks>計算量: 償却O(α(n))．α はアッカーマン関数の逆関数で，実用上は定数とみなせる．</remarks>
        public int GetRootOf(int n) => (_parentOf[n] < 0) ? n : CompressPath(_parentOf[n]);

        /// <summary>ノードmとnが同じグループに属するかどうかを判定する．</summary>
        /// <param name="m">対象のノード番号．</param>
        /// <param name="n">対象のノード番号．</param>
        /// <returns>mとnが同じグループに属していればtrue．</returns>
        /// <remarks>計算量: 償却O(α(n))．</remarks>
        public bool AreSame(int m, int n) => GetRootOf(m) == GetRootOf(n);

        /// <summary>ノードvが属するグループに含まれるノード数を返す．</summary>
        /// <param name="v">対象のノード番号．</param>
        /// <returns>vが属するグループのノード数．</returns>
        /// <remarks>計算量: 償却O(α(n))．</remarks>
        public int Size(int v) => _sizes[GetRootOf(v)];

        /// <summary>ノードmとnが属するグループを併合する（union by rank）．既に同じグループであれば何もしない．</summary>
        /// <param name="m">対象のノード番号．</param>
        /// <param name="n">対象のノード番号．</param>
        /// <remarks>計算量: 償却O(α(n))．</remarks>
        public void Unite(int m, int n)
        {
            var rootM = GetRootOf(m);
            var rootN = GetRootOf(n);

            if (rootM == rootN)
                return;

            var rankM = -_parentOf[rootM];
            var rankN = -_parentOf[rootN];

            if (rankM == rankN)
            {
                _parentOf[rootM] = rootN;
                _parentOf[rootN]--;
                _sizes[rootN] += _sizes[rootM];
                return;
            }

            (var r0, var r1) = (rankM > rankN) ? (rootM, rootN) : (rootN, rootM);
            _parentOf[r1] = r0;
            _sizes[r0] += _sizes[r1];
        }

        // ノードnから根までの経路上の全ノードを，根に直接つなぎ替える（経路圧縮）．
        int CompressPath(int n)
        {
            var parent = _parentOf[n];
            if (parent < 0)
            {
                _parentOf[n] = -2;
                return n;
            }
            return _parentOf[n] = CompressPath(parent);
        }
    }

    /// <summary>
    /// AVL木（平衡二分探索木）．重複を許容する要素の追加・削除・探索を対数時間で行う．
    /// MultiSet&lt;T&gt;の内部実装として用いられる．
    /// </summary>
    /// <typeparam name="T">要素の型．</typeparam>
    public class BinaryTree<T>
    {
        Node? _root;
        Comparison<T> _comparison;

        /// <summary>木に含まれる最小の要素．木が空の場合はdefault(T)．計算量: O(log n)．</summary>
        public T? Min => _root is null ? default : GetMin(_root).Value;

        /// <summary>木に含まれる最大の要素．木が空の場合はdefault(T)．計算量: O(log n)．</summary>
        public T? Max => _root is null ? default : GetMax(_root).Value;

        /// <summary>木に含まれる要素数（重複を含む）．</summary>
        public int Count { get; private set; }

        /// <summary>デフォルトの比較方法で空の木を初期化する．</summary>
        public BinaryTree() : this(Comparer<T>.Default.Compare) { }

        /// <summary>指定した比較方法で空の木を初期化する．</summary>
        /// <param name="comparison">要素の大小比較方法．</param>
        public BinaryTree(Comparison<T> comparison) => this._comparison = comparison;

        /// <summary>デフォルトの比較方法で，dataの各要素を追加した状態で初期化する．</summary>
        /// <param name="data">初期要素の列．</param>
        /// <remarks>計算量: O(n log n)．nはdataの要素数．</remarks>
        public BinaryTree(IEnumerable<T> data) : this(data, Comparer<T>.Default.Compare) { }

        /// <summary>指定した比較方法で，dataの各要素を追加した状態で初期化する．</summary>
        /// <param name="data">初期要素の列．</param>
        /// <param name="comparison">要素の大小比較方法．</param>
        /// <remarks>計算量: O(n log n)．nはdataの要素数．</remarks>
        public BinaryTree(IEnumerable<T> data, Comparison<T> comparison)
        {
            _comparison = comparison;
            foreach (var d in data)
                Add(d);
        }

        /// <summary>valueと等しい要素が木に含まれるかどうかを判定する．</summary>
        /// <param name="value">検索する値．</param>
        /// <returns>valueが含まれていればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool Contains(T value)
        {
            var node = _root;
            while (node is not null)
            {
                var comp = _comparison(value, node.Value);
                if (comp < 0)
                    node = node.Left;
                else if (comp > 0)
                    node = node.Right;
                else
                    return true;
            }
            return false;
        }

        /// <summary>valueを木に追加する．重複する値も追加できる．</summary>
        /// <param name="value">追加する値．</param>
        /// <remarks>計算量: O(log n)．</remarks>
        public void Add(T value)
        {
            _root = Insert(_root, value, out _);
            Count++;
        }

        /// <summary>valueと等しい要素を1つ木から削除する．</summary>
        /// <param name="value">削除する値．</param>
        /// <returns>削除できればtrue．valueが木に含まれていなければfalse．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool Remove(T value)
        {
            _root = Remove(_root, value, out _, out var found);
            if (found)
                Count--;
            return found;
        }

        /// <summary>valueより大きい要素のうち最小のものを取得する（GetUpperBoundと同義）．</summary>
        /// <param name="value">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>valueより大きい要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetNext(T value, [MaybeNullWhen(false)] out T result)
            => TryGetUpperBound(value, out result);

        /// <summary>valueより大きい要素のうち最小のものを取得する（GetUpperBoundと同義）．</summary>
        /// <param name="value">基準値．</param>
        /// <returns>valueより大きい要素のうち最小の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetNext(T value)
            => GetUpperBound(value);

        /// <summary>value未満の要素のうち最大のものを取得する．</summary>
        /// <param name="value">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>valueより小さい要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetPrev(T value, [MaybeNullWhen(false)] out T result)
        {
            Node? res = null;
            if (_root is not null)
                GetPrev(_root, value, ref res);

            if (res is not null)
            {
                result = res.Value;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        /// <summary>value未満の要素のうち最大のものを取得する．</summary>
        /// <param name="value">基準値．</param>
        /// <returns>valueより小さい要素のうち最大の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetPrev(T value)
        {
            if (TryGetPrev(value, out var result))
            {
                return result;
            }
            throw new InvalidOperationException("Sequence contains no matching element.");
        }

        /// <summary>min以上の要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>min以上の要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetLowerBound(T min, [MaybeNullWhen(false)] out T result)
        {
            var lb = GetLowerBound(_root, min);
            if (lb is null)
            {
                result = default;
                return false;
            }
            else
            {
                result = lb.Value;
                return true;
            }
        }

        /// <summary>min以上の要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <returns>min以上の要素のうち最小の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetLowerBound(T min)
        {
            if (TryGetLowerBound(min, out var result))
            {
                return result;
            }
            throw new InvalidOperationException("Sequence contains no matching element.");
        }

        /// <summary>minより大きい要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>minより大きい要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetUpperBound(T min, [MaybeNullWhen(false)] out T result)
        {
            var ub = GetUpperBound(_root, min);
            if (ub is null)
            {
                result = default;
                return false;
            }
            else
            {
                result = ub.Value;
                return true;
            }
        }

        /// <summary>minより大きい要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <returns>minより大きい要素のうち最小の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetUpperBound(T min)
        {
            if (TryGetUpperBound(min, out var result))
            {
                return result;
            }
            throw new InvalidOperationException("Sequence contains no matching element.");
        }

        static Node GetMin(Node node) => node.Left is null ? node : GetMin(node.Left);

        static Node GetMax(Node node) => node.Right is null ? node : GetMax(node.Right);

        void GetPrev(Node? node, T value, ref Node? res)
        {
            if (node is null)
                return;

            var comp = _comparison(value, node.Value);

            if (comp == 0)
            {
                if (node.Left is null)
                    return;

                var max = GetMax(node.Left);
                res = (res is not null && _comparison(res.Value, max.Value) > 0) ? res : max;
            }
            else if (comp < 0)    // value < node.Value 
                GetPrev(node.Left, value, ref res);
            else if (comp > 0)   // value > node.Value
            {
                res = node;
                GetPrev(node.Right, value, ref res);
            }
        }

        Node? GetLowerBound(Node? node, T x)
        {
            if (node is null)
                return null;

            var comp = _comparison(x, node.Value);

            if (comp == 0)
                return node;

            if (comp < 0)    // x <= node.Value
                return GetLowerBound(node.Left, x) ?? node;

            if (comp > 0)   // x > node.Value
                return GetLowerBound(node.Right, x);

            return node;
        }

        Node? GetUpperBound(Node? node, T x)
        {
            if (node is null)
                return null;

            var comp = _comparison(x, node.Value);
            if (comp < 0)    // x < node.Value
                return GetUpperBound(node.Left, x) ?? node;

            if (comp >= 0)   // x >= node.Value
                return GetUpperBound(node.Right, x);

            return node;
        }

        static int GetHeight(Node? node) => node is null ? 0 : node.Height;

        Node Insert(Node? node, T value, out bool grew)
        {
            if (node is null)
            {
                grew = true;
                return new Node(value);
            }

            var comp = _comparison(value, node.Value);
            if (comp < 0)
            {
                var height = node.Height;
                node.Left = Insert(node.Left, value, out grew);

                if (grew)
                {
                    if (node.Balance > 1)
                        node = BalanceLeft(node);
                    else
                        node.UpdateHeight();

                    grew = node.Height != height;
                }

                return node;
            }

            if (comp > 0)
            {
                var height = node.Height;
                node.Right = Insert(node.Right, value, out grew);

                if (grew)
                {
                    if (node.Balance < -1)
                        node = BalanceRight(node);
                    else
                        node.UpdateHeight();

                    grew = node.Height != height;
                }

                return node;
            }

            grew = false;
            return node;
        }

        Node? Remove(Node? node, T value, out bool shirinked, out bool found)
        {
            if (node is null)
            {
                shirinked = found = false;
                return null;
            }

            var height = node.Height;
            var comp = _comparison(value, node.Value);
            if (comp < 0)
            {
                node.Left = Remove(node.Left, value, out shirinked, out found);
                if (shirinked)
                {
                    if (node.Balance < -1)
                        node = BalanceRight(node);
                    else
                        node.UpdateHeight();

                    shirinked = node.Height != height;
                }

                return node;
            }

            if (comp > 0)
            {
                node.Right = Remove(node.Right, value, out shirinked, out found);
                if (shirinked)
                {
                    if (node.Balance > 1)
                        node = BalanceLeft(node);
                    else
                        node.UpdateHeight();

                    shirinked = node.Height != height;
                }

                return node;
            }

            found = true;
            if (node.Left is not null)
            {
                var left = node.Left;
                Node maxNode;
                (node.Left, maxNode) = RemoveMax(left, out shirinked);
                node.Value = maxNode.Value;

                if (shirinked)
                {
                    if (node.Balance < -1)
                        node = BalanceRight(node);
                    else
                        node.UpdateHeight();

                    shirinked = node.Height != height;
                }

                return node;
            }

            shirinked = true;
            return node.Right;
        }

        static (Node? altNode, Node maxNode) RemoveMax(Node node, out bool shrinked)
        {
            if (node.Right is null)
            {
                shrinked = true;
                return (node.Left, node);
            }

            var height = node.Height;
            var right = node.Right;
            Node maxNode;
            (node.Right, maxNode) = RemoveMax(right, out shrinked);
            if (shrinked)
            {
                if (node.Balance > 1)
                    node = BalanceLeft(node);
                else
                    node.UpdateHeight();

                shrinked = node.Height != height;
            }

            return (node, maxNode);
        }

        static Node BalanceLeft(Node node)
        {
            Debug.Assert(node.Left is not null);
            Debug.Assert(node.Balance > 1);

            if (node.Left.Balance >= 0)
                node = RotateRight(node);
            else
            {
                node.Left = RotateLeft(node.Left);
                node = RotateRight(node);
            }
            return node;
        }

        static Node BalanceRight(Node node)
        {
            Debug.Assert(node.Right is not null);
            Debug.Assert(node.Balance < -1);

            if (node.Right.Balance <= 0)
                node = RotateLeft(node);
            else
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
            }

            return node;
        }

        static Node RotateRight(Node node)
        {
            Debug.Assert(node.Left is not null);

            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            left.Right.UpdateHeight();
            left.UpdateHeight();

            return left;
        }

        static Node RotateLeft(Node node)
        {
            Debug.Assert(node.Right is not null);

            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            right.Left.UpdateHeight();
            right.UpdateHeight();

            return right;
        }

        class Node
        {
            public T Value;
            public Node? Left;
            public Node? Right;
            public int Height;

            public int Balance => GetHeight(Left) - GetHeight(Right);

            public Node(T value) => (Value, Height) = (value, 1);
            public void UpdateHeight() => Height = 1 + Math.Max(GetHeight(Left), GetHeight(Right));
        }
    }

    /// <summary>
    /// 重複を許容する集合（多重集合）．BinaryTree&lt;T&gt;とDictionary&lt;T, int&gt;を用いて，
    /// 追加・削除・近傍探索を対数時間で行う．
    /// </summary>
    /// <typeparam name="T">要素の型．</typeparam>
    public class MultiSet<T> where T : notnull
    {
        readonly BinaryTree<T> _tree;
        readonly Dictionary<T, int> _counts;

        /// <summary>集合に含まれる要素数（重複を含む）．</summary>
        public int Count { get; private set; }

        /// <summary>集合に含まれる相異なる値の種類数．</summary>
        public int UniqueCount => _counts.Count;

        /// <summary>集合に含まれる最小の要素．集合が空の場合はdefault(T)．計算量: O(log n)．</summary>
        public T? Min => _tree.Min;

        /// <summary>集合に含まれる最大の要素．集合が空の場合はdefault(T)．計算量: O(log n)．</summary>
        public T? Max => _tree.Max;

        /// <summary>デフォルトの比較方法で空の集合を初期化する．</summary>
        public MultiSet() : this(Comparer<T>.Default.Compare) { }

        /// <summary>指定した比較方法で空の集合を初期化する．</summary>
        /// <param name="comparison">要素の大小比較方法．</param>
        public MultiSet(Comparison<T> comparison)
        {
            _tree = new BinaryTree<T>(comparison);
            _counts = new Dictionary<T, int>();
        }

        /// <summary>デフォルトの比較方法で，dataの各要素を追加した状態で初期化する．</summary>
        /// <param name="data">初期要素の列．</param>
        /// <remarks>計算量: O(n log n)．nはdataの要素数．</remarks>
        public MultiSet(IEnumerable<T> data) : this(data, Comparer<T>.Default.Compare) { }

        /// <summary>指定した比較方法で，dataの各要素を追加した状態で初期化する．</summary>
        /// <param name="data">初期要素の列．</param>
        /// <param name="comparison">要素の大小比較方法．</param>
        /// <remarks>計算量: O(n log n)．nはdataの要素数．</remarks>
        public MultiSet(IEnumerable<T> data, Comparison<T> comparison) : this(comparison)
        {
            foreach (var d in data)
                Add(d);
        }

        /// <summary>valueを集合に追加する．重複する値も追加できる．</summary>
        /// <param name="value">追加する値．</param>
        /// <remarks>計算量: 償却O(log n)．</remarks>
        public void Add(T value)
        {
            if (_counts.TryGetValue(value, out var count))
            {
                _counts[value] = count + 1;
            }
            else
            {
                _counts[value] = 1;
                _tree.Add(value);
            }
            Count++;
        }

        /// <summary>valueと等しい要素を1つ集合から削除する．</summary>
        /// <param name="value">削除する値．</param>
        /// <returns>削除できればtrue．valueが集合に含まれていなければfalse．</returns>
        /// <remarks>計算量: 償却O(log n)．</remarks>
        public bool Remove(T value)
        {
            if (!_counts.TryGetValue(value, out var count))
                return false;

            if (count == 1)
            {
                _counts.Remove(value);
                _tree.Remove(value);
            }
            else
            {
                _counts[value] = count - 1;
            }
            Count--;
            return true;
        }

        /// <summary>valueと等しい要素を全て集合から削除する．</summary>
        /// <param name="value">削除する値．</param>
        /// <returns>削除した個数．</returns>
        /// <remarks>計算量: 償却O(log n)．</remarks>
        public int RemoveAll(T value)
        {
            if (!_counts.TryGetValue(value, out var count))
                return 0;

            _counts.Remove(value);
            _tree.Remove(value);
            Count -= count;
            return count;
        }

        /// <summary>valueと等しい要素が集合に含まれるかどうかを判定する．</summary>
        /// <param name="value">検索する値．</param>
        /// <returns>valueが1個以上含まれていればtrue．</returns>
        /// <remarks>計算量: O(1)．</remarks>
        public bool Contains(T value) => _counts.ContainsKey(value);

        /// <summary>valueと等しい要素の個数を返す．</summary>
        /// <param name="value">検索する値．</param>
        /// <returns>valueと等しい要素の個数．含まれていなければ0．</returns>
        /// <remarks>計算量: O(1)．</remarks>
        public int GetCount(T value) => _counts.TryGetValue(value, out var count) ? count : 0;

        /// <summary>valueより大きい要素のうち最小のものを取得する（GetUpperBoundと同義）．</summary>
        /// <param name="value">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>valueより大きい要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetNext(T value, [MaybeNullWhen(false)] out T result) => _tree.TryGetNext(value, out result);

        /// <summary>valueより大きい要素のうち最小のものを取得する（GetUpperBoundと同義）．</summary>
        /// <param name="value">基準値．</param>
        /// <returns>valueより大きい要素のうち最小の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetNext(T value) => _tree.GetNext(value);

        /// <summary>value未満の要素のうち最大のものを取得する．</summary>
        /// <param name="value">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>valueより小さい要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetPrev(T value, [MaybeNullWhen(false)] out T result) => _tree.TryGetPrev(value, out result);

        /// <summary>value未満の要素のうち最大のものを取得する．</summary>
        /// <param name="value">基準値．</param>
        /// <returns>valueより小さい要素のうち最大の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetPrev(T value) => _tree.GetPrev(value);

        /// <summary>min以上の要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>min以上の要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetLowerBound(T min, [MaybeNullWhen(false)] out T result) => _tree.TryGetLowerBound(min, out result);

        /// <summary>min以上の要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <returns>min以上の要素のうち最小の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetLowerBound(T min) => _tree.GetLowerBound(min);

        /// <summary>minより大きい要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <param name="result">見つかった値．見つからない場合はdefault(T)．</param>
        /// <returns>minより大きい要素が存在すればtrue．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public bool TryGetUpperBound(T min, [MaybeNullWhen(false)] out T result) => _tree.TryGetUpperBound(min, out result);

        /// <summary>minより大きい要素のうち最小のものを取得する．</summary>
        /// <param name="min">基準値．</param>
        /// <returns>minより大きい要素のうち最小の値．</returns>
        /// <exception cref="InvalidOperationException">条件を満たす要素が存在しない場合．</exception>
        /// <remarks>計算量: O(log n)．</remarks>
        public T GetUpperBound(T min) => _tree.GetUpperBound(min);
    }

    /// <summary>
    /// セグメント木．(T, op, identity)がモノイドをなす任意の演算に対して，
    /// 1点更新と区間へのop適用（区間クエリ）を対数時間で行う．
    /// </summary>
    /// <typeparam name="T">セグメント木が保持する値の型．</typeparam>
    public class SegmentTree<T>
    {
        readonly int _numLeaves;
        readonly T[] _nodes;
        readonly Func<T, T, T> _op;
        readonly T _identity;

        /// <summary>
        /// セグメント木を初期化する．
        /// </summary>
        /// <param name="values">この木が葉に保持する値の初期値．</param>
        /// <param name="op">写像(T, T) -> T．(T, op, identity)はモノイド．</param>
        /// <param name="identity">Tの単位元．</param>
        /// <remarks>計算量: O(n)．nはvaluesの要素数．</remarks>
        public SegmentTree(IEnumerable<T> values, Func<T, T, T> op, T identity)
        {
            _op = op;
            _identity = identity;
            var valuesArray = values.ToArray();
            _numLeaves = 1 << MathEx.CeilLog2(valuesArray.Length);
            _nodes = new T[(_numLeaves << 1) - 1];
            Array.Copy(valuesArray, 0, _nodes, _numLeaves - 1, valuesArray.Length);
            Array.Fill(_nodes, identity, _numLeaves + valuesArray.Length - 1, _numLeaves - valuesArray.Length);

            for (var i = _numLeaves - 2; i >= 0; i--)
                _nodes[i] = op(_nodes[GetLeftIdx(i)], _nodes[GetRightIdx(i)]);
        }

        /// <summary>
        /// 添字idxの葉の値を取得する．
        /// </summary>
        /// <param name="idx">葉の添字（0-indexed）．</param>
        /// <returns>idx番目の葉が保持する値．</returns>
        /// <remarks>計算量: O(1)．</remarks>
        public T GetValue(int idx) => _nodes[idx + _numLeaves - 1];

        /// <summary>
        /// 添字idxの葉の値をvalueに更新する．
        /// </summary>
        /// <param name="idx">葉の添字（0-indexed）．</param>
        /// <param name="value">新しい値．</param>
        /// <remarks>計算量: O(log n)．</remarks>
        public void Update(int idx, T value)
        {
            var i = idx + _numLeaves - 1;
            _nodes[i] = value;
            while (i > 0)
            {
                i = GetParentIdx(i);
                _nodes[i] = _op(_nodes[GetLeftIdx(i)], _nodes[GetRightIdx(i)]);
            }
        }

        /// <summary>
        /// 区間[a, b)で演算opを実行した結果を返す.
        /// </summary>
        /// <param name="a">区間の下端（この値を含む）．</param>
        /// <param name="b">区間の上端（この値を含まない）．</param>
        /// <returns>区間[a, b)の全要素にopを適用した結果．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public T Query(int a, int b) => SubQuery(a, b, 0, 0, _numLeaves);

        T SubQuery(int a, int b, int nodeIdx, int left, int right)
        {
            // クエリの範囲外
            if (right <= a || b <= left)
                return _identity;

            // クエリの範囲に完全に属している
            if (a <= left && right <= b)
                return _nodes[nodeIdx];

            // クエリの範囲を部分的に含む
            var mid = (left + right) >> 1;
            var vl = SubQuery(a, b, GetLeftIdx(nodeIdx), left, mid);
            var vr = SubQuery(a, b, GetRightIdx(nodeIdx), mid, right);
            return _op(vl, vr);
        }

        static int GetParentIdx(int i) => (i - 1) >> 1;
        static int GetLeftIdx(int i) => (i << 1) + 1;
        static int GetRightIdx(int i) => (i << 1) + 2;
    }

    /// <summary>
    /// 遅延セグメント木．(T, op, identity)がモノイドをなす任意の演算に対して，
    /// 区間更新と区間クエリの両方を対数時間で行う．
    /// </summary>
    /// <typeparam name="T">セグメント木が保持する値の型．</typeparam>
    /// <typeparam name="U">値の更新時に作用させる値の型．</typeparam>
    public class LazySegmentTree<T, U>
    {
        readonly int _numLeaves;
        readonly T[] _nodes;
        readonly U[] _updates;

        readonly Func<T, T, T> _op;
        readonly T _identity;

        readonly Func<T, U, T> _updator;
        readonly Func<U, U, U> _composer;
        readonly U _updateIdentity;

        /// <summary>
        /// 遅延セグメント木を初期化する
        /// </summary>
        /// <param name="values">この木が葉に保持する値の初期値.</param>
        /// <param name="op">写像(T, T) -> T. (T, op, identity)はモノイド.</param>
        /// <param name="identity">Tの単位元.</param>
        /// <param name="updator">T型の値をU型の値を用いて更新する関数.</param>
        /// <param name="composer">U型の値を合成する関数. updator(updator(t, u1), u2) == updator(t, composer(u1, u2))を満たす.</param>
        /// <param name="updateIdentity">Uの単位元.</param>
        /// <remarks>計算量: O(n)．nはvaluesの要素数．</remarks>
        public LazySegmentTree(IEnumerable<T> values, Func<T, T, T> op, T identity, Func<T, U, T> updator, Func<U, U, U> composer, U updateIdentity)
        {
            _op = op;
            _identity = identity;

            _updator = updator;
            _composer = composer;
            _updateIdentity = updateIdentity;

            var valuesArray = values.ToArray();
            _numLeaves = 1 << MathEx.FloorLog2(valuesArray.Length);
            if (_numLeaves < valuesArray.Length)
                _numLeaves <<= 1;

            _nodes = new T[(_numLeaves << 1) - 1];
            _updates = new U[_nodes.Length];
            Array.Copy(valuesArray, 0, _nodes, _numLeaves - 1, valuesArray.Length);
            Array.Fill(_nodes, identity, _numLeaves + valuesArray.Length - 1, _numLeaves - valuesArray.Length);
            Array.Fill(_updates, updateIdentity);

            for (var i = _numLeaves - 2; i >= 0; i--)
                _nodes[i] = op(_nodes[GetLeftIdx(i)], _nodes[GetRightIdx(i)]);
        }

        /// <summary>
        /// 添字idxの値に指定した値を作用させて更新する.
        /// </summary>
        /// <param name="idx">葉の添字（0-indexed）．</param>
        /// <param name="update">作用させる値．</param>
        /// <remarks>計算量: O(log n)．</remarks>
        public void Update(int idx, U update) => Update(idx, idx + 1, update, 0, 0, _numLeaves);

        /// <summary>
        /// 区間[a, b)の値に指定した値を作用させて更新する.
        /// </summary>
        /// <param name="a">区間の下端（この値を含む）．</param>
        /// <param name="b">区間の上端（この値を含まない）．</param>
        /// <param name="update">作用させる値．</param>
        /// <remarks>計算量: O(log n)．</remarks>
        public void Update(int a, int b, U update) => Update(a, b, update, 0, 0, _numLeaves);

        void Update(int a, int b, U update, int nodeIdx, int left, int right)
        {
            Eval(nodeIdx);

            // 区間[a, b)に完全に含まれる.
            if (left >= a && b >= right)
            {
                _updates[nodeIdx] = update;
                Eval(nodeIdx);  // 親ノードに値を伝播するため,ここで評価が必要.
            }
            else if (right > a && left < b)  // 区間[a, b)に部分的に含まれる.
            {
                var mid = (left + right) >> 1;
                var leftIdx = GetLeftIdx(nodeIdx);
                var rightIdx = GetRightIdx(nodeIdx);
                Update(a, b, update, leftIdx, left, mid);
                Update(a, b, update, rightIdx, mid, right);
                _nodes[nodeIdx] = _op(_nodes[leftIdx], _nodes[rightIdx]);
            }
        }

        /// <summary>
        /// 区間[a, b)で演算opを実行した結果を返す.
        /// </summary>
        /// <param name="a">区間の下端（この値を含む）．</param>
        /// <param name="b">区間の上端（この値を含まない）．</param>
        /// <returns>区間[a, b)の全要素にopを適用した結果．</returns>
        /// <remarks>計算量: O(log n)．</remarks>
        public T Query(int a, int b) => SubQuery(a, b, 0, 0, _numLeaves);

        T SubQuery(int a, int b, int nodeIdx, int left, int right)
        {
            Eval(nodeIdx);

            // クエリの範囲外
            if (right <= a || b <= left)
                return _identity;

            // クエリの範囲に完全に属している
            if (a <= left && right <= b)
                return _nodes[nodeIdx];

            // クエリの範囲を部分的に含む
            var mid = (left + right) >> 1;
            var vl = SubQuery(a, b, GetLeftIdx(nodeIdx), left, mid);
            var vr = SubQuery(a, b, GetRightIdx(nodeIdx), mid, right);
            return _op(vl, vr);
        }

        /// <summary>
        /// 指定されたノードの値を評価する.
        /// この際, 保留中の値の更新を行う.
        /// </summary>
        /// <param name="nodeIdx"></param>
        void Eval(int nodeIdx)
        {
            if (EqualityComparer<U>.Default.Equals(_updates[nodeIdx], _updateIdentity))
                return;

            // 子ノードも更新対象なので更新値を伝播させる.
            if (nodeIdx < _numLeaves - 1)
            {
                var leftIdx = GetLeftIdx(nodeIdx);
                _updates[leftIdx] = _composer(_updates[leftIdx], _updates[nodeIdx]);

                var rightIdx = GetRightIdx(nodeIdx);
                _updates[rightIdx] = _composer(_updates[rightIdx], _updates[nodeIdx]);
            }

            _nodes[nodeIdx] = _updator(_nodes[nodeIdx], _updates[nodeIdx]);
            _updates[nodeIdx] = _updateIdentity;
        }

        static int GetLeftIdx(int i) => (i << 1) + 1;
        static int GetRightIdx(int i) => (i << 1) + 2;
    }
}

#endregion