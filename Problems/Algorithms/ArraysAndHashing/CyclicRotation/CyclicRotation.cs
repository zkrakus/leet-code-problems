using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.ArraysAndHashing.CyclicRotation;
public static class CyclicRotation
{
    public static int[] Run(int[] a, int k)
    {
        if (k == 0 || a == null || a.Length == 0)
            return Array.Empty<int>();

        k %= a.Length;
        var b = new int[a.Length];

        var partition = a.Length - k;
        Array.ConstrainedCopy(a, 0, b, k, partition);
        Array.ConstrainedCopy(a, partition, b, 0, k);

        return b;
    }
}
