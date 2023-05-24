using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.Brackets;

/// <summary>
/// Problem: 
/// A string S consisting of N characters is considered to be properly nested if any of the following conditions is true:
/// 
/// S is empty;
/// S has the form "(U)" or "[U]" or "{U}" where U is a properly nested string;
/// S has the form "VW" where V and W are properly nested strings.
/// 
/// For example, the string "{[()()]}" is properly nested but "([)()]" is not.
/// 
/// Given a string S consisting of N characters, return 1 if S is properly nested and 0 otherwise.
/// </summary>
public static class Brackets
{
    /// <summary>
    /// Analysis:
    /// t(n) == O(n)
    /// s(n) == O(n/2) = O(n)
    /// </summary>
    public static int Run(string s)
    {
        if (s == null || s.Length == 0)
            return 1;

        Stack<char> stack = new();
        Dictionary<char, char> brackets = new Dictionary<char, char>() { { '{', '}' }, { '[', ']' }, { '(', ')' } };
        foreach (var c in s)
        {
            if (brackets.ContainsKey(c))
                stack.Push(c);
            else
            {
                if (brackets.Count != 0 && brackets[stack.Peek()] != c)
                    return 0;

                _ = stack.Pop();
            }
        }

        return stack.IsNullOrEmpty() ? 1 : 0;
    }
}
