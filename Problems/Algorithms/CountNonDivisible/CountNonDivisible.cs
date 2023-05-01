using AutoMapper.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.CountNonDivisible;

/// <summary>
/// You are given an array A consisting of N integers.
/// For each number A[i] such that 0 ≤ i<N, we want to count the number of 
/// elements of the array that are not the divisors of A[i]. We say that these elements are non-divisors.
/// 
/// Write an efficient algorithm for the following assumptions:
/// N is an integer within the range[1..50, 000];
/// each element of array A is an integer within the range[1..2 * N].
/// </summary>
public static class CountNonDivisible
{
    /// <summary>
    /// t(n) = 2n + (n * sqrt(2 * n)) = O(n = n(sqrt(n)))
    /// s(n) = O(3n)
    /// </summary>
    public static int[] Run(int[] a)
    {
        if (a.Length == 0)
            return Array.Empty<int>();
        else if (a.Length == 1)
            return new int[] { 0 };

        Dictionary<int, int> occurenceCount = new Dictionary<int, int>();
        foreach (int i in a)
        {
            if (!occurenceCount.ContainsKey(i))
                occurenceCount.Add(i, 1);
            else
                occurenceCount[i]++;
        }

        Dictionary<int, int> divisorCount = new Dictionary<int, int>();
        int[] nonDivisors = new int[a.Length];
        foreach (var elem in occurenceCount.Keys)
        {
            int count = 0;
            for (int i = 1; i <= Math.Sqrt(elem); i++)
            {
                if (elem % i == 0)
                {
                    if (occurenceCount.ContainsKey(i))
                        count += occurenceCount[i];

                    if (i < Math.Sqrt(elem))
                    {
                        int symmetricDivisor = elem / i;
                        if (occurenceCount.ContainsKey(symmetricDivisor))
                            count += occurenceCount[symmetricDivisor];
                    }
                }

            }

            divisorCount.Add(elem, count);
        }

        for (int i = 0; i < a.Length; i++)
        {
            int val = a[i];
            if (divisorCount.ContainsKey(val))
                nonDivisors[i] = a.Length - divisorCount[val];
        }

        return nonDivisors;
    }
}
