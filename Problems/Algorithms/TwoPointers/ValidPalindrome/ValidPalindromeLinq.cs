using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Algorithms.TwoPointers.ValidPalindrome;
/// <inheritdoc />
public class ValidPalindromLinq : IValidPalindrome
{

    /// <summary>
    /// Analysis:
    /// t(n) = O(n)
    /// s(n) = O(n)
    /// </summary>
    public bool IsPalindrome(string s)
    {
        if (!s.Any() || s.Length == 1)
            return true;

        var parsedString = string.Concat(s.Where(char.IsLetter));

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
