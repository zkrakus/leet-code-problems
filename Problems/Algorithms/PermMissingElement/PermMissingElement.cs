using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.PermMissingElement;
public static class PermMissingElement
{
    /// <summary>
    /// Problem:
    /// An array A consisting of N different integers is given. 
    /// The array contains integers in the range [1..(N + 1)], 
    /// which means that exactly one element is missing. Find the missing element.
    /// 
    /// Analysis:
    /// t(n) = O(n)
    /// s(n) = O(1)
    /// </summary>
    public static int Run(int[] a)
    {
        if (a.Length == 0 || a == null)
            return 1;

        long n = a.Length + 1;
        long sumOfElements = n * (n + 1) / 2;
        long sum = 0;

        for (var i = 0; i < n - 1; i++)
            sum += a[i];

        return (int)(sumOfElements - sum);
    }
}
