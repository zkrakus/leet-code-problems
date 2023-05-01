using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Problems.Algorithms.Dominator;
/// <summary>
/// Problem:
/// An array A consisting of N integers is given. 
/// The dominator of array A is the value that occurs in more than half of the elements of A.
/// 
/// For example, consider array A such that
/// A[0] = 3    A[1] = 4    A[2] =  3
/// A[3] = 2    A[4] = 3    A[5] = -1
/// A[6] = 3    A[7] = 3
/// 
/// The dominator of A is 3 because it occurs in 5 out of 8 elements of A(namely in those with indices 0, 2, 4, 6 and 7) and 5 is more than a half of 8.
/// Given an array A consisting of N integers, returns index of any element of array A in which the dominator of A occurs.The function should return −1 if array A does not have a dominator.
/// </summary>
public static class Dominator
{
    /// <summary>
    /// Analysis:
    /// t(n) = O(n)
    /// s(n) = O(n)
    /// </summary>
    public static int Run(int[] a)
    {
        if (a == null || a.Length == 0)
            return -1;
        else if (a.Length == 1)
            return 0;

        var dominatorPreciate = a.Length / 2;
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < a.Length; i++)
        {
            var elem = a[i];
            if (!map.ContainsKey(elem))
                map.Add(elem, 1);
            else
            {
                if (++map[elem] > dominatorPreciate)
                    return i;
            }
        }

        return -1;
    }
}
