using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.MaxProuctOfThree;

/// <summary>
/// Problem:
/// A non-empty array A consisting of N integers is given. 
/// The product of triplet (P, Q, R) equates to A[P] * A[Q] * A[R] (0 ≤ P <= Q <= R <= N).
/// Find the maximal product of any triplet.
/// 
/// Constraint:
/// N is an integer within the range [3..100,000];
/// each element of array A is an integer within the range[−1, 000..1, 000].
/// </summary>
public static class MaxProductOfThree
{
    /// <summary>
    /// Analysis:
    /// t(n) = O(n(log(n))
    /// s(n) = O(1)
    /// </summary>
    public static int Run(int[] a)
    {
        if (a is null || a.Length < 3)
            return 0;

        Array.Sort(a);
        
        var length = a.Length;
        var product = 0;
        if (a[0] * a[1] * a[length - 1] > a[length - 1] * a[length - 2] * a[length - 3])
            product = a[0] * a[1] * a[length - 1];
        else
            product = a[length - 1] * a[length - 2] * a[length - 3];

        return product;
    }
}
