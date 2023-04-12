namespace Problems.Algorithms.ReverseInteger;

/// <summary>
/// Problem:
/// Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
/// Assume the environment does not allow you to store 64-bit integers(signed or unsigned).
/// </summary>
public static class ReverseInteger
{
    /// <summary>
    /// Algorithm:
    /// Check if the input is 0. If so you we are done.
    /// If input is negative and is equal to int.MIN_Value return 0 as we will overflow during conversion.
    /// Take the absolute value of the input if negative. Pop the least signifigant digit of the input with % 10.
    /// Push it onto the value we will return. Divide the input by 10 to trim the least signifigant digit.
    /// Return the inversed integer depending on if it is positive or negative.
    /// 
    /// Analysis:
    /// t(n) = O(log_10(n)) : log_10 because we are dividing the input by 10 thefore reducing the possible result set
    /// by an order of magnitude each itheration.
    /// 
    /// s(n)  = O(1) : All variables are of consant size regardless of input.
    /// </summary>
    public static int Run(int x)
    {
        if (x is 0)
            return x;

        if (x == int.MinValue)
            return 0;

        var inputIsPositive = IsPositive(x);
        x = Math.Abs(x);

        long reversedInt = 0;
        while (x != 0)
        {
            reversedInt *= 10;
            reversedInt += x % 10;
            x /= 10;

            if (reversedInt > int.MaxValue || reversedInt * -1 < int.MinValue)
                return 0;
        }

        var tmp = inputIsPositive ? (int)reversedInt * -1 : (int)reversedInt;
        return tmp;
    }

    private static bool IsPositive(int n) => n > 0;
}
