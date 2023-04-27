using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Problems.Algorithms.PermutationCheck;
public static class PermutationCheck
{
    /// <summary>
    /// Problem:
    /// A non-empty array A consisting of N integers is given.
    /// A permutation is a sequence containing each element from 1 to N once, and only once.
    /// 
    /// Check whether array A is a permutation.
    /// 
    /// Analysis:
    /// t(n) = O(n)
    /// s(n) = O(1)
    /// </summary>
    public static int Run(int[] a)
    {
        if (a == null || a.Length == 0)
            return 0;

        var n = a.Length;
        var expectedSum = n * (n + 1) / 2;
        var sum = 0;

        var permutation = new HashSet<int>();
        for (var i = 0; i < n; i++)
        {
            var elem = a[i];
            if (elem > n || permutation.Contains(elem))
                return 0;
            else
            {
                permutation.Add(elem);
            }

            sum += elem;
        }

        return expectedSum - sum == 0 ? 1 : 0;
    }
}

class Solution
{
    public int solution(int[] a)
    {
        if (a == null || a.Length == 0)
            return 0;

        var n = a.Length;
        var expectedSum = n * (n + 1) / 2;
        var sum = a.Sum();

        return expectedSum - sum == 0 ? 1 : 0;
    }
}