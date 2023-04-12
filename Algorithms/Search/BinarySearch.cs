namespace Algorithms.Search;
public static class BinarySearch
{
    /// <summary>
    /// Algorithm:
    /// Continually subdivides an array down the middle be recursively subdividing the array by reindexing.
    /// Subdivision occurs by recursively calling the binary search method with narrowing indexes.
    /// 
    /// O(n) = log(n)
    /// O(s) = O(1)
    /// 
    /// Notes:
    /// Works just like <see cref="Array.BinarySearch"/>, but doesn't use IComparable.
    /// The array being searched should be sorted.
    /// 
    /// </summary>
    /// <param name="arr">The array to be searched.</param>
    /// <param name="n">The number we are searching for.</param>
    /// <returns>The index of the number if found, or its complement if not found.</returns>
    public static int Search(int[] arr, int n)
        => arr.Length == 0 ? ~0 : BinarySearchRec(arr, 0, arr.Length, n);

    /// <summary>
    /// Recursive binary search method. Uses indexes to subdivide the array.
    /// </summary>
    /// <param name="arr">The original array.</param>
    /// <param name="i">The starting index of the subarray.</param>
    /// <param name="j">The length of the array to be searched from the index.</param>
    /// <param name="n">The integer being searched.</param>
    /// <returns>The number if found, or its complement if not found.</returns>
    private static int BinarySearchRec(int[] arr, int i, int j, int n)
    {
        // Find the middle index of the array.
        // If the array is odd the middle index will be the middle odd value bisecting the array.
        // If the array is even, the middle index will be the first integer in the bisected array on the right.
        // Special case, if the array is of length of, the left bisected array is of size 0. 
        // Whenever the array is odd the right bisected array will always be one cell larger due to integer division.
        var m = i + ((j - i) / 2);

        // If the integer being searched should go at the end of the array
        // (e.g. the searched integer is greater than an element in the array)
        // return the the last index in the array + 1.
        if (m >= arr.Length)
        {
            return ~arr.Length;
        }

        // See if the middle value is the searched value.
        if (arr[m] == n)
        {
            return m;
        }

        // If the calculated middle index is equal to the left index or smaller, we can no longer bisect the array
        // ending the recursive calls.
        if (m <= i)
        {
            // If the searched number is less than the value of the middle cell, we return the complement of the middle index.
            // We return the complement as it lets the user know the number was not found without throwing an error.
            // We return the middle index, because if the number was added to the array and this algorithm rerun, this would the the index 
            // returned. If the searched number is larger than the value of the middle cell we return the complement of the middle index + 1
            // for the same reason as above.
            return n < arr[m] ? ~m : ~++m;
        }

        return arr[m] > n ? BinarySearchRec(arr, i, m, n) : BinarySearchRec(arr, m + 1, j, n);
    }
}
