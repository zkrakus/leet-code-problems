using System.Text.RegularExpressions;

namespace Problems.Algorithms.TwoPointers.ValidPalindrome;

/// <inheritdoc />
public class ValidPalindromeRegex : IValidPalindrome
{
    private const string _isAlphabeticalAsciiRegex = "[^a-zA-Z]";
    private static readonly Regex regex = new(_isAlphabeticalAsciiRegex);

    /// <summary>
    /// Analysis:
    /// t(n) = O(n)
    /// s(n) = O(n)
    /// </summary>
    public bool IsPalindrome(string s)
    {
        if (!s.Any() || s.Length == 1)
            return true;

        var parsedString = regex.Replace(s, string.Empty);

        int left = 0, right = parsedString.Length - 1;
        while (left < right)
        {
            if (parsedString[left] != parsedString[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}
