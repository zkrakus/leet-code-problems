using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms;

/// <summary>
/// n integer N is given, representing the area of some rectangle.
/// The area of a rectangle whose sides are of length A and B is A* B, and the perimeter is 2 * (A + B).
/// The goal is to find the minimal perimeter of any rectangle whose area equals N.The sides of this rectangle should be only integers.
/// </summary>
public static class MinPermimeterRect
{
    /// <summary>
    /// t(n) == O(sqrt(n))
    /// s(n) == O(1)
    /// </summary>
    public static int Run(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 4;

        long minPermiter = GetPerimeter(1, n);
        long i = 2;
        for (i = 2; i * i < n; i++)
        {
            if (n % i == 0)
            {
                long symmetricDivisor = n / i; 
                minPermiter = Math.Min(minPermiter, GetPerimeter(symmetricDivisor, i));
            }
        }

        if (i * i == n)
            minPermiter = Math.Min(minPermiter, GetPerimeter(i, i));

        return (int)minPermiter;
    }

    private static long GetPerimeter (long a, long b) => 2 * (a + b);
}
