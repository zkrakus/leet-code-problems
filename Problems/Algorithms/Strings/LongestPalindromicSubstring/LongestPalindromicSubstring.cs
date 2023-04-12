namespace Problems.Algorithms.Strings.LongestPalindromicSubstring;

/// <summary>
/// Problem:
/// Given a string s, return the longest palindromic substring in s.
/// </summary>
public class LongestPalindromicSubstring
{
    // ToDo https://leetcode.com/problems/longest-palindromic-substring/solutions/127837/longest-palindromic-substring/
    // ToDo Dynamic Programming solution https://leetcode.com/problems/longest-palindromic-substring/solutions/2921/share-my-java-solution-using-dynamic-programming/

    /// <summary>
    /// Algorithm: 
    /// To find the longest palindromic substring efficiently expand outwards from all possible centers of palindromes.
    /// A palindrome's center is defined is either the middle character in an odd length palindrome or the two characters 
    /// closest to the center for an even length palindrome. 
    /// 
    /// Analysis: 
    /// f(t) = O(n/2 * (2n - 1)) => n^2 : n/2 to check if palindrome. (2n - 1 centers to check).
    /// f(s) = O(1)
    /// </summary>
    public static string ExpandAroundCenter(string s)
    {
        if (s.Length is 0 or 1)
            return s;

        var longestSubtringLength = 0;
        var longestSubtringStartIndex = 0;
        for (var i = 0; i < s.Length; i++)
        {
            (var left, var right) = ExpandFromCenter(i, i + 1, s);
            var substringLength = right - left + 1;
            if (substringLength > longestSubtringLength)
            {
                longestSubtringLength = substringLength;
                longestSubtringStartIndex = left;
            }

            (left, right) = ExpandFromCenter(i, i, s);
            substringLength = right - left + 1;
            if (substringLength > longestSubtringLength)
            {
                longestSubtringLength = substringLength;
                longestSubtringStartIndex = left;
            }
        }

        return s.Substring(longestSubtringStartIndex, longestSubtringLength);
    }

    public static (int l, int r) ExpandFromCenter(int left, int right, string s)
    {
        if (left < 0 || right >= s.Length || s[left] != s[right])
            return (left, left);

        int l = left, r = right;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            (l, r) = (left, right);
            left--;
            right++;
        }

        return (l, r);
    }

    /// <summary>
    /// Algorithm: 
    /// To find the longest palindromic substring via brute force, iterate through all possible string combinations 
    /// and check if they are palindromic.
    /// 
    /// Analysis: 
    /// f(t) = O(n/2 * n(n-1)/2) => n^2 : n/2 to check if palindrome. (n,2) => n(n-1)/2 => n^2 strings to check.
    /// f(s) = O(1)
    /// </summary>
    public static string RunBruteForce(string s)
    {
        var n = s.Length;
        var longestpalindromeLength = 0;
        var longestPalindrome = "";
        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                if (IsPalindrome(i, j, s))
                {
                    if (longestpalindromeLength < j - i)
                    {
                        longestpalindromeLength = j - i;
                        longestPalindrome = s.Substring(i, j - i + 1);
                    }

                }
            }
        }

        return longestPalindrome;
    }

    /// <summary>
    /// Algorithm: 
    /// To find the longest palindromic substring recursively starting from the center of the string (middle character if odd otherwise middle 2 characters)
    /// check if the current string is a palindrome otherwise check if Si...Sn-1 or if Si+1...Sn is the longest substring.
    /// Save the longest palindrome.
    /// 
    /// Analysis: 
    /// f(t) = O(n/2 * 2^(n-1)) => O(n^3) : n/2 to check if palindrome. 2^(n-1) branches from the center of the string. 
    /// -1 because we don't bother with the trivial 1 character case at the leaves of the recursive calls.
    /// f(s) = O(1)
    /// </summary>
    public static string RunRecursive(string s) => s.Length is 0 or 1 ? s : FindSubstringRecursive(0, s.Length - 1, s);

    private static string FindSubstringRecursive(int left, int right, string s)
    {
        if (left == right)
            return s[left].ToString();

        if (IsPalindrome(left, right, s))
            return s.Substring(left, right - left + 1);

        var longestPalindromeLeft = FindSubstringRecursive(left + 1, right, s);
        var longestPalindromeRight = FindSubstringRecursive(left, right - 1, s);

        return longestPalindromeLeft.Length > longestPalindromeRight.Length
            ? longestPalindromeLeft
            : longestPalindromeRight;
    }

    private static bool IsPalindrome(int i, int j, string s)
    {
        if (IsEven(i - j + 1))
        {
            while (i < j)
            {
                if (s[i] != s[j])
                    return false;

                i++;
                j--;
            }
        }
        else
        {
            while (i != j)
            {
                if (s[i] != s[j])
                    return false;

                i++;
                j--;
            }
        }

        return true;
    }

    private static bool IsEven(int n) => n % 2 == 0;
}
