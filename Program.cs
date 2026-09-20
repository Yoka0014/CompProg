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

static class IOUtil
{
    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2)
        => (item1, item2) = enumerator.GetEnumerator();

    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3)
        => (item1, item2, item3) = enumerator.GetEnumerator();

    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4)
        => (item1, item2, item3, item4) = enumerator.GetEnumerator();

    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5)
        => (item1, item2, item3, item4, item5) = enumerator.GetEnumerator();

    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6)
        => (item1, item2, item3, item4, item5, item6) = enumerator.GetEnumerator();

    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7)
        => (item1, item2, item3, item4, item5, item6, item7) = enumerator.GetEnumerator();

    public static void Deconstruct<T>(this IEnumerable<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7, out T item8)
        => (item1, item2, item3, item4, item5, item6, item7, item8) = enumerator.GetEnumerator();

    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2)
    {
        if (!enumerator.MoveNext())
            throw new ArgumentException("Empty.");

        item1 = enumerator.Current;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item2 = enumerator.Current;
    }

    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3)
    {
        (item1, item2) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack");

        item3 = enumerator.Current;
    }

    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4)
    {
        (item1, item2, item3) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item4 = enumerator.Current;
    }

    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5)
    {
        (item1, item2, item3, item4) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item5 = enumerator.Current;
    }

    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6)
    {
        (item1, item2, item3, item4, item5) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item6 = enumerator.Current;
    }

    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7)
    {
        (item1, item2, item3, item4, item5, item6) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item7 = enumerator.Current;
    }

    public static void Deconstruct<T>(this IEnumerator<T> enumerator, out T item1, out T item2, out T item3, out T item4, out T item5, out T item6, out T item7, out T item8)
    {
        (item1, item2, item3, item4, item5, item6, item7) = enumerator;

        if (!enumerator.MoveNext())
            throw new ArgumentException("Too many values to unpack.");

        item8 = enumerator.Current;
    }

    public static void Print(object obj)
    {
        Console.WriteLine(obj);
        Debug.WriteLine(obj);
    }

    public static bool PrintYesOrNo(bool cond)
    {
        Console.WriteLine(cond ? "Yes" : "No");
        Debug.WriteLine(cond ? "Yes" : "No");
        return cond;
    }

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

static class Exceptions
{
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

interface IFlag { }
struct True : IFlag { }
struct False : IFlag { }

struct FastHashInt64
{
    public long Value { get; set; }

    public FastHashInt64(long value) => Value = value;

    public override readonly int GetHashCode() => (int)Sse42.X64.Crc32(0UL, (ulong)Value);

    public static implicit operator FastHashInt64(long value) => new(value);
}

struct ModInt998244353
{
    const long _mod = 998244353;

    public static long Mod => _mod;
    public long Value { get; set; }

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

    public readonly ModInt998244353 Inv() => new(MathEx.ModInv(Value, _mod));
    public readonly ModInt998244353 Pow(long exp) => BigInteger.ModPow(Value, exp, _mod);
}

struct FastHashUInt64
{
    public ulong Value { get; set; }

    public FastHashUInt64(ulong value)
    {
        Value = value;
    }

    public override readonly int GetHashCode() => (int)Sse42.X64.Crc32(0UL, Value);

    public static implicit operator FastHashUInt64(ulong value) => new(value);
}

static class RollingHash
{
    public static ulong Base { get; } = 100000007;

    /// <summary>
    /// h = str[0] * b^(n - 1) + ... + str[^1] * b^0
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static ulong GetRollingHashCode(this string str)
    {
        var hashCode = 0UL;
        foreach (var c in str)
            hashCode = Base * hashCode + c;
        return hashCode;
    }

    public static IEnumerable<ulong> EnumeratePrefixHashCodes(this string str)
    {
        var hashCode = 0UL;
        foreach (var c in str)
            yield return hashCode = Base * hashCode + c;
    }
}

static class MathEx
{
    public static long CeilSqrt(long x) => BinarySearch.LowerBound(n => n * n, x, 0, 3037000500);

    public static long FloorSqrt(long x)
    {
        var sq = CeilSqrt(x);
        return (x == sq * sq) ? sq : sq - 1;
    }

    public static int FloorLog2(long x)
    {
        var bits = (x << 1) >> 1;
        var y = FloorLog2((ulong)bits);
        return (bits != x) ? -y : y;
    }

    public static int CeilLog2(long x)
    {
        var l = FloorLog2(x);
        return (1L << l < x) ? l + 1 : l;
    }

    public static int FloorLog2(ulong x) => 63 - BitOperations.LeadingZeroCount(x);

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
    /// <typeparam name="T"></typeparam>
    /// <param name="a">xの係数</param>
    /// <param name="b">yの係数</param>
    /// <returns>(x, y, gcd(a, b))</returns>
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
    /// <typeparam name="T"></typeparam>
    /// <param name="n"></param>
    /// <param name="mod"></param>
    /// <returns>table[i] == i! % mod を満たす，長さn + 1のテーブル．</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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
    /// <typeparam name="T"></typeparam>
    /// <param name="n"></param>
    /// <param name="mod"></param>
    /// <returns>table[i] == i! % 998244353 を満たす，長さn + 1のテーブル．</returns>
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
    /// <typeparam name="T"></typeparam>
    /// <param name="n"></param>
    /// <param name="mod"></param>
    /// <returns>table[i] == (1 / i!) % 998244353 を満たす，長さn + 1のテーブル．</returns>
    public static ModInt998244353[] CreateModFactorialInvTable(int n)
    {
        var table = new ModInt998244353[n + 1];
        table[n] = Factorial(n, ModInt998244353.Mod);
        table[n] = table[n].Inv();

        for (var i = n - 1; i >= 0; i--)
            table[i] = table[i + 1] * (i + 1);

        return table;
    }

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

    public static long Gcd(long a, long b) => (b == 0) ? a : Gcd(b, a % b);

    public static (long A, long B) MakeCoprime(long a, long b) => (a / Gcd(a, b), b / Gcd(a, b));
}

static class BitManipulations
{
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

    public static int FindFirstSet(ulong bits) => BitOperations.TrailingZeroCount(bits);
    public static int FindNextSet(ref ulong bits) => FindFirstSet(bits &= (bits - 1));

    public static IEnumerable<int> EnumerateSets(ulong bits) 
    {
        for (var i = FindFirstSet(bits); bits != 0; i = FindNextSet(ref bits))
            yield return i;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong DeltaSwap(ulong x, ulong mask, int delta)
    {
        var t = (x ^ (x >> delta)) & mask;
        return x ^ t ^ (t << delta);
    }
}

namespace IterTools
{
    public static class Permutation
    {
        public static bool Next<T>(Span<T> seq) where T : IComparable<T>
        {
            int i;
            for (i = seq.Length - 2; i >= 0 && seq[i].CompareTo(seq[i + 1]) >= 0; i--) ;

            if (i == -1)
                return false;

            int j;
            for (j = seq.Length - 1; j >= 0 && seq[j].CompareTo(seq[i]) <= 0; j--) ;

            (seq[i], seq[j]) = (seq[j], seq[i]);

            var subSeq = seq[(i + 1)..];
            for (var k = 0; k < subSeq.Length / 2; k++)
                (subSeq[k], subSeq[^(k + 1)]) = (subSeq[^(k + 1)], subSeq[k]);

            return true;
        }

        public static IEnumerable<T[]> Enumerate<T>(T[] seq) where T : IComparable<T>
        {
            if (seq.Length == 0)
            {
                yield return Array.Empty<T>();
                yield break;
            }

            var p = new T[seq.Length];
            seq.CopyTo(p, 0);
            var count = 0;
            var numPermutaions = MathEx.Factorial((long)seq.Length);
            do
            {
                yield return p;
                count++;
            }
            while (Next<T>(p));

            if (count == numPermutaions)
                yield break;

            seq.CopyTo(p, 0);
            Array.Sort(p);
            while (count < numPermutaions)
            {
                yield return p;
                count++;
                Next<T>(p);
            }
        }
    }
}

namespace Algorithms
{
    public static class BinarySearch
    {
        /// <summary>
        /// 半開区間[left, right)で単調増加である関数funcについて, func(x) = keyを満たすxの範囲の下限を返す.
        /// funx(x) = keyを満たすxが存在しない場合は, func(x) > keyとなるxのうち最小のxを返す.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="func"></param>
        /// <param name="key"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static long LowerBound<TKey>(Func<long, TKey> func, TKey key, long left, long right) where TKey : IComparable<TKey>
            => LowerBound(func, key, left, right, (x, y) => x.CompareTo(y));

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

        public static long LowerBound<T>(T[] arr, T key) where T : IComparable<T>
            => LowerBound(arr, key, (x, y) => x.CompareTo(y));

        public static long LowerBound<T>(T[] arr, T key, Comparison<T> comparison)
            => LowerBound(i => arr[i], key, 0, arr.Length, comparison);

        /// <summary>
        /// 半開区間[left, right)で単調増加である関数funcについて, func(x) = keyを満たすxの範囲の上限を返す.
        /// funx(x) = keyを満たすxが存在しない場合は, func(x) > keyとなるxのうち最小のxを返す.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="func"></param>
        /// <param name="key"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static long UpperBound<TKey>(Func<long, TKey> func, TKey key, long left, long right) where TKey : IComparable<TKey>
            => UpperBound(func, key, left, right, (x, y) => x.CompareTo(y));

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

        public static long UpperBound<T>(T[] arr, T key) where T : IComparable<T>
            => UpperBound(arr, key, (x, y) => x.CompareTo(y));

        public static long UpperBound<T>(T[] arr, T key, Comparison<T> comparison)
            => UpperBound(i => arr[i], key, 0, arr.Length, comparison);
    }

    public static class CoordinatesCompression
    {
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

    public static class Manacher
    {
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

    public static class Graph
    {
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
    public class UnionFindTrees
    {
        readonly int[] _parentOf;
        readonly int[] _sizes;

        public UnionFindTrees(int size)
        {
            _parentOf = Enumerable.Repeat(-1, size).ToArray();
            _sizes = Enumerable.Repeat(1, size).ToArray();
        }

        public int GetRootOf(int n) => (_parentOf[n] < 0) ? n : CompressPath(_parentOf[n]);

        public bool AreSame(int m, int n) => GetRootOf(m) == GetRootOf(n);

        public int Size(int v) => _sizes[GetRootOf(v)];

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

    public class BinaryTree<T>
    {
        Node? _root;
        Comparison<T> _comparison;

        public T? Min => _root is null ? default : GetMin(_root).Value;
        public T? Max => _root is null ? default : GetMax(_root).Value;
        public int Count { get; private set; }

        public BinaryTree() : this(Comparer<T>.Default.Compare) { }
        public BinaryTree(Comparison<T> comparison) => this._comparison = comparison;
        public BinaryTree(IEnumerable<T> data) : this(data, Comparer<T>.Default.Compare) { }

        public BinaryTree(IEnumerable<T> data, Comparison<T> comparison)
        {
            _comparison = comparison;
            foreach (var d in data)
                Add(d);
        }

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

        public void Add(T value)
        {
            _root = Insert(_root, value, out _);
            Count++;
        }

        public bool Remove(T value)
        {
            _root = Remove(_root, value, out _, out var found);
            if (found)
                Count--;
            return found;
        }

        public bool TryGetNext(T value, [MaybeNullWhen(false)] out T result)
            => TryGetUpperBound(value, out result);

        public T GetNext(T value)
            => GetUpperBound(value);

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

        public T GetPrev(T value)
        {
            if (TryGetPrev(value, out var result))
            {
                return result;
            }
            throw new InvalidOperationException("Sequence contains no matching element.");
        }

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

        public T GetLowerBound(T min)
        {
            if (TryGetLowerBound(min, out var result))
            {
                return result;
            }
            throw new InvalidOperationException("Sequence contains no matching element.");
        }

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
            var comp = _comparison(value, node!.Value);

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

    public class MultiSet<T> where T : notnull
    {
        readonly BinaryTree<T> _tree;
        readonly Dictionary<T, int> _counts;

        public int Count { get; private set; }
        public int UniqueCount => _counts.Count;

        public T? Min => _tree.Min;
        public T? Max => _tree.Max;

        public MultiSet() : this(Comparer<T>.Default.Compare) { }

        public MultiSet(Comparison<T> comparison)
        {
            _tree = new BinaryTree<T>(comparison);
            _counts = new Dictionary<T, int>();
        }

        public MultiSet(IEnumerable<T> data) : this(data, Comparer<T>.Default.Compare) { }

        public MultiSet(IEnumerable<T> data, Comparison<T> comparison) : this(comparison)
        {
            foreach (var d in data)
                Add(d);
        }

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

        public int RemoveAll(T value)
        {
            if (!_counts.TryGetValue(value, out var count))
                return 0;

            _counts.Remove(value);
            _tree.Remove(value);
            Count -= count;
            return count;
        }

        public bool Contains(T value) => _counts.ContainsKey(value);

        public int GetCount(T value) => _counts.TryGetValue(value, out var count) ? count : 0;

        public bool TryGetNext(T value, [MaybeNullWhen(false)] out T result) => _tree.TryGetNext(value, out result);
        public T GetNext(T value) => _tree.GetNext(value);

        public bool TryGetPrev(T value, [MaybeNullWhen(false)] out T result) => _tree.TryGetPrev(value, out result);
        public T GetPrev(T value) => _tree.GetPrev(value);

        public bool TryGetLowerBound(T min, [MaybeNullWhen(false)] out T result) => _tree.TryGetLowerBound(min, out result);
        public T GetLowerBound(T min) => _tree.GetLowerBound(min);

        public bool TryGetUpperBound(T min, [MaybeNullWhen(false)] out T result) => _tree.TryGetUpperBound(min, out result);
        public T GetUpperBound(T min) => _tree.GetUpperBound(min);
    }

    public class SegmentTree<T>
    {
        readonly int _numLeaves;
        readonly T[] _nodes;
        readonly Func<T, T, T> _op;
        readonly T _identity;

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

        public T GetValue(int idx) => _nodes[idx + _numLeaves - 1];

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
        /// <param name="a"></param>
        /// <param name="b"></param>
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
    /// 遅延セグメント木
    /// </summary>
    /// <typeparam name="T">セグメント木が保持する値の型</typeparam>
    /// <typeparam name="U">値の更新時に作用させる値の型</typeparam>
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

        public void Update(int idx, U update) => Update(idx, idx + 1, update, 0, 0, _numLeaves);

        /// <summary>
        /// 区間[a, b)の値に指定した値を作用させて更新する.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="update"></param>
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
        /// <param name="a"></param>
        /// <param name="b"></param>
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