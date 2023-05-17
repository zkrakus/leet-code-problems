using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.ArraysAndHashing.OddOccurencesInArray;

/// <summary>
/// Problem:
/// A non-empty array A consisting of N integers is given. 
/// The array contains an odd number of elements, and each element of the array 
/// can be paired with another element that has the same value, except for one element that is left unpaired.
/// </summary>
public static class OddOccurencesInArray
{
    /// <summary>
    /// Analysis:
    /// t(n) = O(a.length)
    /// s(n) = O(a.length / 2) => O(a.length)
    /// </summary>
    public static int Run(int[] a)
    {
        if (a is null || a.Length == 0)
            return 0;

        var pairs = new HashSet<int>();
        foreach (var i in a)
            _ = !pairs.Contains(i) ? pairs.Add(i) : pairs.Remove(i);

        return pairs.First();
    }

    /// <summary>
    /// Analysis:
    /// t(n) = O(a.length)
    /// s(n) = O(1)
    /// </summary>
    public static int RunOptimized(int[] a)
    {
        if (a is null || a.Length == 0)
            return 0;

        var oddPair = 0;
        foreach (var i in a)
            oddPair ^= i;

        return oddPair;
    }
}
