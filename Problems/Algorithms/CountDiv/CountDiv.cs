using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Problems.Algorithms.CountDiv;
/// <summary>
/// iven three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, 
/// i.e.: { i : A ≤ i ≤ B, i mod K = 0 }
/// 
/// For example, for A = 6, B = 11 and K = 2, your function should return 3, 
/// because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.
/// </summary>
public static class CountDiv
{
    public static int Run(int a, int b, int k)
    {
        if (k == 0)
            return 0;

        int divisorCount = 0;
        divisorCount += b / k;
        divisorCount -= a / k;

        if (a % k == 0)
            divisorCount++;

        return divisorCount;
    }
}
