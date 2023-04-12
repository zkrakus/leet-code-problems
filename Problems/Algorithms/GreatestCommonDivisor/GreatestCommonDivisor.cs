namespace Problems.Algorithms.GreatestCommonDivisor;

public static class GreatestCommonDivisor
{
    public delegate int GCDDelegate(int a, int b);

    /// <summary>
    /// Algorithm: 
    /// To find the GCD through exhaustion we take the min of the two inputs (a, b) and continually decrement 
    /// a copy of the smallest input (c) until a % c and b % c == 0, or c == 1. We find the GCD of each 
    /// 
    /// Analysis: 
    /// f(t) = O(n * (a_(n-1)) : a_(n-1) is the second largest element in the array.
    /// f(s) = = O(1)
    /// 
    /// </summary>
    /// <param name="arr">Array of integers.</param>
    /// <returns>The greatest common divisor.</returns>
    /// <exception cref="ArgumentException">The GCD of an integer and 0 is undefined.</exception>
    /// <exception cref="ArgumentException">Array cannot be null or emtpy.</exception>
    public static int RunBruteForce(int[] arr) => Run(arr, FindGCDBruteForce);

    /// <summary>
    /// Algorithm: 
    /// To improve the algorithm we can take advantage of the following.
    /// Finding the gcd is based on the Euclidian algorithm. 
    /// It's based on the fact that the gcd will not change if we replace the larger number with the difference of the large and smaller number.
    /// e.g. 28 - 7 = 21. The gcd of 28, 7 and 21 are still 7.
    /// We can repeat this process untill both numbers are the same meaning we found the GCD.
    /// 
    /// Analysis: 
    /// f(t) = O(n * (max(a_n) / min(a_n)) : a_n is an element in the n.
    /// f(s) = O(1)
    /// 
    /// </summary>
    /// <param name="arr">Array of integers.</param>
    /// <returns>The greatest common divisor.</returns>
    /// <exception cref="ArgumentException">The GCD of an integer and 0 is undefined.</exception>
    /// <exception cref="ArgumentException">Array cannot be null or emtpy.</exception>
    public static int RunImproved(int[] arr) => Run(arr, FindGCDImproved);

    /// <summary>
    /// Algorithm: 
    /// An optimization of the gcd algorithm involves using the remainder of dividing the large number by the small number.
    /// A way to think about this intuitively is to remember the principle of the unoptimized euclidian algorithm. 
    /// Then understand that the modulus operation returns what remains after we subtract the smallest number from the largest the maximum possible amount of times.
    /// e.g. 28 % 7 = 0. Which is like 28 - 7 x 5 = 0.
    /// 
    /// Analysis: 
    /// f(t) = O(n * log(min(a,b). See: https://www.geeksforgeeks.org/time-complexity-of-euclidean-algorithm/
    /// f(s) = O(1)
    /// 
    /// </summary>
    /// <param name="arr">Array of integers.</param>
    /// <returns>The greatest common divisor.</returns>
    /// <exception cref="ArgumentException">The GCD of an integer and 0 is undefined.</exception>
    /// <exception cref="ArgumentException">Array cannot be null or emtpy.</exception>
    public static int RunOptimized(int[] arr) => Run(arr, FindGCDOptimized);

    public static int Run(int[] arr, GCDDelegate callback)
    {
        // If null there can be no gcd
        if (arr == null)
            throw new ArgumentException("An empty array has no GCD.");

        // An empty array has no GCD.
        if (arr.Length == 0)
            throw new ArgumentException("An empty array has no GCD.");

        // We do a forward look ahead for 0 to maximize readability since we can't optimize based on assumptions as to how this method will be called.
        foreach (var i in arr)
        {
            if (i == 0)
                throw new ArgumentException("The GCD of any integer and 0 is undefined.");
        }

        // A number itself is its own gcd
        if (arr.Length == 1)
            return arr[0];

        var tempGCD = 1;
        for (var i = 0; i < arr.Length - 1; i++)
        {
            tempGCD = callback(arr[i], arr[i + 1]);
        }

        return tempGCD;
    }

    private static int FindGCDBruteForce(int a, int b)
    {
        // The GCD can be no higher than the two min of the two inputs.
        var c = Math.Min(a, b);

        // Decrement the minumum value until the value is divisible by both denominators
        for (var i = c; i > 1; i--)
        {
            if (a % i == 0 && b % i == 0)
                return i;
        }

        return 1;
    }

    private static int FindGCDImproved(int a, int b)
    {
        int c;
        if (a > b)
        {
            c = a - b;
            return FindGCDImproved(c, b);
        }
        else if (b > a)
        {
            c = b - a;
            return FindGCDImproved(c, a);
        }
        else
        {
            return a;
        }
    }

    private static int FindGCDOptimized(int a, int b)
    {
        var min = Math.Min(a, b);
        var max = Math.Max(a, b);

        if (min == 1)
            return 1;

        if (min == max)
            return min;

        // Find the remainder and either return GCD if no remainder or keep looking for GCD.
        var remainder = max % min;
        return remainder == 0 ? min : FindGCDOptimized(remainder, min);
    }
}
