namespace Algorithms.Sorts;
public static class MergeSort
{
    /// <summary>
    /// Algorithm:
    /// Continually subdivides an array by two. Once each array is subdivided to of length one we can consider it sorted.
    /// When trying to sort two sorted arrays we don't have to search for the lowest/highest number in each array we can just  
    /// compare the index of each array in order and place them into a sorted array as we iterate through the subarrays.
    /// Once one of the subarrays is empty we just fill the rest of the sorted array with the remaining elements as they are already sorted.
    /// 
    /// O(n) = nlg(n) // Log n splits and n iterations each split to merge.
    /// O(s) = O(n)  // Merge sort when not parallelized practically sorts depth first meaning space will never be greater than n.
    /// 
    /// </summary>
    /// <param name="arr">The array to be sorted.</param>
    /// <returns>A sorted array.</returns>
    public static int[] Sort(int[] arr) => SplitRec(arr);

    private static int[] SplitRec(int[] arr)
    {
        if (arr.Length == 1)
            return arr;

        var leftArrayLength = (int)Math.Floor(arr.Length / 2d);
        var rightArrayLength = (int)Math.Ceiling(arr.Length / 2d);
        var l = new int[leftArrayLength];
        var r = new int[rightArrayLength];

        Array.Copy(arr, 0, l, 0, leftArrayLength);
        Array.Copy(arr, leftArrayLength, r, 0, rightArrayLength);

        var ls = SplitRec(l);
        var rs = SplitRec(r);

        return Merge(ls, rs);
    }

    private static int[] Merge(int[] l, int[] r)
    {
        int i = 0, j = 0, k = 0;
        var leftArrayLength = l.Length;
        var rightArrayLength = r.Length;
        var sortedArray = new int[leftArrayLength + rightArrayLength];

        while (i < leftArrayLength && j < rightArrayLength)
        {
            var leftValue = l[i];
            var rightValue = r[j];

            if (leftValue <= rightValue)
            {
                sortedArray[k] = leftValue;
                k++;
                i++;
            }

            if (rightValue <= leftValue)
            {
                sortedArray[k] = rightValue;
                k++;
                j++;
            }
        }

        while (i < leftArrayLength)
        {
            sortedArray[k] = l[i];
            k++;
            i++;
        }

        while (j < rightArrayLength)
        {
            sortedArray[k] = r[j];
            k++;
            j++;
        }

        return sortedArray;
    }
}