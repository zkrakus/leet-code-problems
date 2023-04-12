using System.Text;

namespace Problems.Algorithms.Strings.IntegerToRoman;
public static class IntegerToRoman
{
    private const char ROMAN_I = 'I';
    private const string ROMAN_IV = "IV";
    private const char ROMAN_V = 'V';
    private const string ROMAN_IX = "IX";
    private const char ROMAN_X = 'X';
    private const string ROMAN_XL = "XL";
    private const char ROMAN_L = 'L';
    private const string ROMAN_XC = "XC";
    private const char ROMAN_C = 'C';
    private const string ROMAN_CD = "CD";
    private const char ROMAN_D = 'D';
    private const string ROMAN_CM = "CM";
    private const char ROMAN_M = 'M';

    public static string Run(int n)
    {
        var romanStringBuilder = new StringBuilder();
        while (n > 0)
        {
            (romanStringBuilder, n) = ToRoman(romanStringBuilder, n);
        }

        return romanStringBuilder.ToString();
    }

    private static (StringBuilder, int) ToRoman(StringBuilder stringBuilder, int n) => (stringBuilder, n) switch
    {
        { n: var x } when n > 999 => AppendM(stringBuilder, x),
        { n: var x } when n is > 899 and < 1000 => AppendCM(stringBuilder, x),
        { n: var x } when n is > 499 and < 900 => AppendD(stringBuilder, x),
        { n: var x } when n is > 399 and < 500 => AppendCD(stringBuilder, x),
        { n: var x } when n is > 99 and < 400 => AppendC(stringBuilder, x),
        { n: var x } when n is > 89 and < 100 => AppendXC(stringBuilder, x),
        { n: var x } when n is > 49 and < 90 => AppendL(stringBuilder, x),
        { n: var x } when n is > 39 and < 50 => AppendXL(stringBuilder, x),
        { n: var x } when n is > 9 and < 40 => AppendX(stringBuilder, x),
        { n: var x } when n is > 8 and < 10 => AppendIX(stringBuilder, x),
        { n: var x } when n is > 4 and < 9 => AppendV(stringBuilder, x),
        { n: var x } when n is 4 => AppendIV(stringBuilder, x),
        { n: var x } when n > 0 => AppendI(stringBuilder, x),
        { n: _ } when n > 0 => (new StringBuilder(), 0),
        _ => throw new NotImplementedException(),
    };

    private static (StringBuilder, int) AppendI(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_I);
        n--;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendIV(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_IV);
        n -= 4;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendV(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_V);
        n -= 5;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendIX(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_IX);
        n -= 9;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendX(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_X);
        n -= 10;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendXL(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_XL);
        n -= 40;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendL(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_L);
        n -= 50;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendXC(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_XC);
        n -= 90;

        return (stringBuilder, n);
    }
    private static (StringBuilder, int) AppendC(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_C);
        n -= 100;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendCD(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_CD);
        n -= 400;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendD(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_D);
        n -= 500;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendCM(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_CM);
        n -= 900;

        return (stringBuilder, n);
    }

    private static (StringBuilder, int) AppendM(StringBuilder stringBuilder, int n)
    {
        _ = stringBuilder.Append(ROMAN_M);
        n -= 1000;

        return (stringBuilder, n);
    }
}
