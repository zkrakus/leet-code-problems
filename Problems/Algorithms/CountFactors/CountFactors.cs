using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.CountFactors;

/// <summary>
/// A positive integer D is a factor of a positive integer N if there exists an integer M such that N = D * M
/// For example, 6 is a factor of 24, because M = 4 satisfies the above condition(24 = 6 * 4).
/// </summary>
public static class CountFactors
{

    /// <summary>
    /// Analysis:
    /// t(n) == O(sqrt(n))
    /// s(n) == O(1)
    /// </summary>
    public static int Run(int n)
    {
        if (n == 0)
            return 0;
        else if (n == 1)
            return 1;

        n = Math.Abs(n);
        int result = 0;
        int i = 1;
        for(i = 1; i * i < n; i++)
        {
            if (n % i == 0)
                result += 2;
        }

        if (i * i == n)
            result += 1;

        return result;
    }
}
