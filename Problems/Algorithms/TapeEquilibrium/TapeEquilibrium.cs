using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.TapeEquilibrium;
public class TapeEquilibrium
{
    /// <summary>
    /// Problem:
    /// A non-empty array A consisting of N integers is given. Array A represents numbers on a tape.
    /// Any integer P, such that 0 < P<N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].
    /// The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|
    /// In other words, it is the absolute difference between the sum of the first part and the sum of the second part.
    /// 
    /// </summary>
    public static int Run(int[] a)
    {
        long leftSum = a[0];
        long rightSum = a.Sum() - a[0];
        var minDifference = Math.Abs(rightSum - leftSum);

        int l = 1, r = 2;
        while (r < a.Length)
        {
            leftSum += a[l];
            rightSum -= a[l];
            minDifference = Math.Min(minDifference, Math.Abs(rightSum - leftSum));

            l++;
            r++;
        }

        return (int)minDifference;
    }
}
