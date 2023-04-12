namespace Problems.Algorithms.FindMaxSum;
public static class FindMaxSum
{
    /// <summary>
    /// Find the max sum of two integers in the array. 
    /// ex: 
    /// (1,2) = 3
    /// (1,2,3,4) = 7
    /// 
    /// Algorithm: Iterate through the input keeping track of the current number.
    /// Compare the number with the largest number. If it's larger or equal we replace the second largest with the largest
    /// and then the largest with n. We need to do the equality portion of the comparison 
    /// to account for duplicate inputs to ensure second largest gets updated.
    /// If the input is not >= largest, we do a comparison against the second largest. If it's greater we swap, otherwise we continue.
    /// When we finish iterating we return the sum.
    /// 
    /// s(n) = O(1) We only use two, no data structures.
    /// t(n) = O(n) We only do one pass of n.
    /// 
    /// </summary>
    public static int Run(int[] input)
    {
        if (input.Length < 2)
            throw new ArgumentException("Input must contain at least 2 integers.");

        int largest = 0, secondLargest = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var number = input[i];
            if (number >= largest)
            {
                secondLargest = largest;
                largest = number;
            }
            else if (number > secondLargest)
            {
                secondLargest = number;
            }
        }

        return largest + secondLargest;
    }
}
