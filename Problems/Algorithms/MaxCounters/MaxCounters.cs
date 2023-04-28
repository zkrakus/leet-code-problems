using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.MaxCounters;
public static class MaxCounters
{
    /// <summary>
    /// Problem:
    /// You are given N counters, initially set to 0, and you have two possible operations on them:
    /// increase(X) − counter X is increased by 1, 
    /// max counter − all counters are set to the maximum value of any counter.
    /// 
    /// A non-empty array A of M integers is given.This array represents consecutive operations:
    /// if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X), 
    /// if A[K] = N + 1 then operation K is max counter.
    /// 
    /// Return the values of the countesr after the operations are processed.
    /// 
    /// Analysis:
    /// t(n) = O(m + n) : n is the number of counters and m is the number of operations.
    /// s(n) = O(n) : where n is the amount of counters.
    /// </summary>
    /// <param name="n">Number of counters.</param>
    /// <param name="a">Array of opeartions</param>
    public static int[] Run(int n, int[] a)
    {
        if (!a.Any() || a == null || n == 0)
            return a;

        var counters = new int[n];
        var localMax = 0;
        var globalMax = 0;

        for (var i = 0; i < a.Length; i++)
        {
            var counterIndex = a[i];

            if (counterIndex == n + 1)
                globalMax = localMax;
            else if (counterIndex <= n)
            {
                int currentValue = counters[counterIndex - 1];
                if (currentValue < globalMax)
                    counters[counterIndex - 1] = globalMax;

                counters[counterIndex - 1]++;
                localMax = Math.Max(localMax, counters[counterIndex - 1]);
            }
        }

        for(var i = 0; i < n; i++)
        {
            if (counters[i] < globalMax)
                counters[i] = globalMax;
        }

        return counters;
    }
}
