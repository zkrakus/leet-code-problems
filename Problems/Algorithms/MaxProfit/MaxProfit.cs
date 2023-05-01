using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.MaxProfit;

/// <summary>
/// An array A consisting of N integers is given. It contains daily prices of a stock 
/// share for a period of N consecutive days. If a single share was bought on day 
/// P and sold on day Q, where 0 ≤ P ≤ Q < N, then the profit of such transaction is 
/// equal to A[Q] − A[P], provided that A[Q] ≥ A[P]. Otherwise, the transaction brings loss of A[P] − A[Q].
/// 
/// Given an array A consisting of N integers containing daily prices of a stock share for a 
/// period of N consecutive days, returns the maximum possible profit from one transaction during this period. 
/// The function should return 0 if it was impossible to gain any profit.
/// </summary>
public static class MaxProfit
{
    public static int Run(int[] a)
    {
        if (a == null || a.Length == 1)
            return 0;

        long maxProfit = long.MinValue;
        long localMin = long.MaxValue;
        foreach(int tick in a)
        {
            localMin = Math.Min(localMin, tick);
            maxProfit = Math.Max(maxProfit, tick - localMin);
        }

        if (maxProfit < 0)
            return 0;

        return (int)maxProfit;
    }
}
