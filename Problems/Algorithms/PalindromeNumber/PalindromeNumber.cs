namespace Problems.Algorithms.PalindromeNumber;

/// <summary>
/// Given an integer x, return true if x is a palindrome and false otherwise.
/// A negative number cannot be a palindrome
/// Constraints:
/// -231 <= x <= 231 - 1
/// </summary>
public static class PalindromeNumber
{

    /// <summary>
    /// Algorithm:
    /// A negative number cannot be a palindrome so check for condition and return if n < 0.
    /// Pop the least signifigant digit off n and store it on x.
    /// While x > n keep poping and store the reversed integer. We do this so we don't overflow our int.
    /// Once n >= x compare them. If true then n is a palindrome. This will be true when the length of digits in n is even.
    /// Pop one off x and then do another comparison for the edge case when the length of digits is odd.
    /// This gets rid of the center digit so you can just compare 'edges'.
    /// 
    /// If neither of these cases gives equality return false otherwise true.
    /// 
    /// Analysis:
    /// t(n) = O(log_10(n) / 2)
    /// s(n) == O(1)
    /// </summary>
    public static bool Run(int n)
    {
        if (n < 0)
            return false;

        var x = 0;
        while (x < n)
        {
            x *= 10;
            var pop = n % 10;
            n /= 10;
            x += pop;
        }

        return x == n || x / 10 == n;
    }
}
