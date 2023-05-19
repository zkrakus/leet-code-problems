using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Algorithms.TwoPointers.ValidPalindrome;

/// <inheritdoc/>
internal class ValidPalindromePredicate : IValidPalindrome
{
    /// <summary>
    /// Analysis:
    /// t(n) = O(n + n + n + n/2) = O(n)
    /// s(n) = O(n)
    /// </summary>
    public bool IsPalindrome(string s)
    {
        if (!s.Any() || s.Length == 1)
            return true;

        var parsedString = string.Concat(Array.FindAll(s.ToCharArray(), IsAlphabeticalAscii));

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

    private static bool IsAlphabeticalAscii(char c)
        => char.ToLower(c) is >= 'a' and <= 'z';
}
