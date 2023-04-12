namespace Problems.Algorithms.CountAnalogousArrays;
public class CountAnalagousArrays
{
    /// <summary>
    /// Problem: Given an array holding the difference between a pair of consecutive integers and lower and upper limits, 
    /// find the number of possible arrays that can meet these criteria.
    /// 
    /// Algorithm:
    /// Iterate through the consecutive difference array. Find the local and uppder values.
    /// Find the difference between the maximum bounds and the local bounds to get the analogous array.
    /// Add 1 to include the consecutive difference array. 
    /// 
    /// </summary>
    /// <param name="consecutiveDifference">Array containing differences of consequitive integers. </param>
    /// <param name="lowerBound">The lower bound that must satisfy all analogous arrays.</param>
    /// <param name="upperBound">The upper bound that must satisfy all analogous arrays.</param>
    /// <returns>The ammount of possible analogous arrays.</returns>
    public static int Run(int[] arr, int lower, int upper)
    {
        // No solution.
        if (upper - lower < 0)
            return 0;

        int localLower = int.MaxValue, localUpper = int.MinValue;
        for (var i = 0; i < arr.Length; i++)
        {
            var n = arr[i];
            localLower = Math.Min(localLower, n);
            localUpper = Math.Max(localUpper, n);
        }

        // We add as the array of consecutive differences is an array that can satisfies the condition.
        // We do a max with 0 account for when there is no solution to the consecutive differenc array in which case
        // our expression with return a negative. 
        return Math.Max(0, upper - lower - (localUpper - localLower) + 1);
    }
}
