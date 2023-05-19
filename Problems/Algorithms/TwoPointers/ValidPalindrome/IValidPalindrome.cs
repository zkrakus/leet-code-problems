using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.TwoPointers.ValidPalindrome;

/// <summary>
/// Problem:
/// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and 
/// removing all non-alphanumeric characters, it reads the same forward and backward.Alphanumeric characters include letters and numbers.
/// Given a string s, return true if it is a palindrome, or false otherwise.
/// 
/// Constraints:
/// 1 <= s.length <= 2 * 105
/// s consists only of printable ASCII characters.
/// </summary>
public interface IValidPalindrome
{
    public bool IsPalindrome(string s);
}
