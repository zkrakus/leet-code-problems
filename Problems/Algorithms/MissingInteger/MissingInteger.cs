using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.MissingInteger;

/// <summary>
/// Problem:
/// Given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
/// For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
/// </summary>
public static class MissingInteger
{
    /// <summary>
    /// Analysis:
    /// t(n) = n + n(log(n))
    /// s(n) = O(1)
    /// </summary>
    public static int Run(int[] a)
    {
        if (a is null || !a.Any())
            return 0;

        Array.Sort(a);

        int expected = 1;
        for(int i  = 0; i < a.Length; i++)
        {
            int elem = a[i];
            if (elem < 1)
                continue;

            if (elem == expected)
                expected++;
            else if (elem > expected)
                return expected;
        }

        return expected;
    }

    /// Analysis:
    /// t(n) = O(4n) = O(n)
    /// s(n) = O(2n) = O(n) 
    public static int RunOptimized(int[] a)
    {
        if (a is null || !a.Any())
            return 0;

        var set = a.Distinct().ToDictionary(x => x);
        var elements = Enumerable.Range(1, a.Length);

        foreach (var elem in elements)
        {
            if (!set.ContainsKey(elem))
                return elem;
        }

        return elements.Last() + 1;
    }
}
