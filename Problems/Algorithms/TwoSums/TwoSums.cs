namespace Problems.Algorithms.TwoSums;
public static class TwoSums
{
    /// <summary>
    /// Problem:
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// 
    /// Notes:
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// You can return the answer in any order.
    /// 
    /// Algorithm:
    /// Iterate over the array and store each element in a dictionary.
    /// For each element computement the complement of the target you are searching for : complement = target - n
    /// Search for the complement inside you array.
    /// 
    /// Time: t(n) = O(n). One iteration over the the array.
    /// Space: s(n) = O(n). We at most store every element the the array in a dictionary.
    /// 
    /// </summary>
    /// <param name="arr">The input array.</param>
    /// <param name="target">The target computation.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">
    /// Throws exception when input array has less than two arguments
    /// and when there is no solution.
    /// </exception>
    public static int[] Run(int[] arr, int target)
    {
        if (arr.Length < 2)
            throw new ArgumentException("Input array must have at least two arguments.");

        var map = new Dictionary<int, int> { { arr[0], 0 } };
        for (var i = 1; i < arr.Length; i++)
        {
            var item = arr[i];
            if (!map.ContainsKey(item))
                map.Add(item, i);

            var complement = target - item;
            if (map.TryGetValue(complement, out var complementIndex) && complementIndex != i)
                return new int[] { complementIndex, i };
        }

        throw new ArgumentException("Input array must have a solution.");
    }
}