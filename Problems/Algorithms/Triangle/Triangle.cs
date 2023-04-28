using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.Triangle;

/// <summary>
/// An array A consisting of N integers is given. A triplet (P, Q, R) is triangular if 0 ≤ P < Q < R < N : and
/// A[P] + A[Q] > A[R],
/// A[Q] + A[R] > A[P],
/// A[R] + A[P] > A[Q].
/// </summary>
public static class Triangle
{
    /// <summary>
    /// Analysis:
    /// t(n) = O(n(log(n))
    /// s(n) == O(1)
    /// </summary>
    public static int Run(int[] a)
    {
        if (a == null || a.Length < 3)
        {
            return 0;
        }

        Array.Sort(a);

        int i = 0;
        var length = a.Length;
        while (i + 2 < length)
        {
            long p = a[i];
            long q = a[i + 1];
            long r = a[i + 2];

            if (p + q > r
                && q + r > p
                && r + p > q)
                return 1;

            i++;
        }

        return 0;
    }
}
