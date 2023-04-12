namespace Problems.Algorithms.MedianOfTwoSortedArrays;

public static class MedianOfTwoSortedArrays
{
    //https://www.youtube.com/watch?v=NTop3VTjmxk
    // Revisit the solution proposed by ChatGBT
    public static double Run(int[] nums1, int[] nums2)
    {
        // Later we show that we can bound the number of partitions as it is constrained to the size of the shorter array.
        // We want to gurantee the first array is shorter to reduce the necessary ammount of conditional statements.
        EnsureFirstSetShorter(ref nums1, ref nums2);

        var n1 = nums1.Length;
        var n2 = nums2.Length;

        // Whether than combined arrays' lenghts are even or odd determines the definition of what the median is.
        var isEven = IsEven(nums1.Length + nums2.Length);

        // Think about a single array that's partioned in half along a median.
        // In this context a partition is a vertical line cutting an array into segments.
        // If the array is even each half can be no greater than the max partition length which is the length / 2.
        // The idea of an array having a center and a median are closely correlated concepts.
        // If the array is odd the partition is to the left and right of the median since it has a center value.
        // This also holds true for finding the median of two sorted arrays. We are still partitioning an array into halves excecept
        // we are now parititioning two arrays both into two halves.
        // The differences is that with two sorted arrays we are searching for the correct way to partition both arrays as there is no longer
        // only one solution as to how to divide the arrays in half. In order to determine two halves we can select elements from one array 
        // and put them into a half and select the rest of the elements from the second array such that our newly conceputally formed half 
        // is composed of array1.length + array2.length / 2 elements.
        // Just like with a single array there is a max partition length of
        // array1.length + array2.length / 2, but now we need to figure out how many elements from the two arrays will be in the left half 
        // and how many elements from both arrays will be on the right half.
        // The maximum ammount of ways to partition the arrays is always the length of the smaller array + 1 since we can always partition
        // the smaller array by taking 0 or all elements (1 + n) where any remaining elements can be taken from the right array to satitisy our
        // condition of containing half of the total elements.
        var maxPartitionLength = GetParitionLengths(nums1, nums2);

        // The minimum ammount of elements we can take from the smaller array.
        var min = 0;

        // The maximum elements we can take from the smaller array.
        // The reason we EnsureFirstSetShorter earler is so we can easily bound the max elements 
        // that can be taken from the smaller array as it will always be <= than the maxPartitionLength.
        var max = nums1.Length;

        // The way to think about this algorithm is that we partition each of our nums arrays into a left and right halves
        // along a partition ( a line segmenting each array into a left and right half). We extract the elements from the left
        // and right side of the nums1 partition (l1, r1) and the left and right side of the nums2 partition (l2, r2). 
        // We know that since the arrays are sorted l1 <= r1 && l2 <= r2 will always be true.
        // We want to compare l1 <= r2 and l2 <= r1 because these are the conditions that are fulfilled when we can definetly determine
        // that we properly segmented our array (more on this later).
        // This means both arrays are partitioned such that we can apply a similar technique to when finding a median of a 
        // single even or odd array.
        while (min <= max)
        {
            // Here we apply binary search.
            // Remember that the goal of binary search is to reduce our problem space by a factor of two each iteration.
            // For this problem our problem space is how many numbers from the smaller array should we include in our left partition.
            // It is either none or all the numbers so let's start by adding half the numbers as that usually provides the best average
            // case runtime.
            var nums1Partition = min + (max / 2);

            // We partition the second array by the difference between the max partitions
            // and the ammount of elements we already included in our left partition.
            // We have no other choice since we need to maintain the definition of two halves in order to hope
            // to ever find a median.
            var nums2Partition = maxPartitionLength - nums1Partition;

            // If we ever have nothing to the left or right of a partition in our nums 1 or 2 array we assume
            // the value as negative or positive infinity to ensure our comparison condition is successful. \\
            // Such a condition occurs when all the elements from one array
            // are greater than or less than the opposing array, or when either of the arrays are empty,
            // or if we picked no numbers from our smaller array when partitioning. 
            var l1 = nums1Partition - 1 < 0 ? int.MinValue : nums1[nums1Partition - 1];
            var r1 = nums1Partition == n1 ? int.MaxValue : nums1[nums1Partition];
            var l2 = nums2Partition - 1 < 0 ? int.MinValue : nums2[nums2Partition - 1];
            var r2 = nums2Partition == n2 ? int.MaxValue : nums2[nums2Partition];

            if (l1 <= r2 && l2 <= r1)
            {
                if (isEven)
                    // To understand the min and max consider how the elements would be arranged if the elements were combined
                    // relative to where their current partition is. 
                    // The left partition contains two numbers that are definertly left of center. So the largest one is our median.
                    // Vice-versa for the right hand side.
                    return FindMedianWhenEven(Math.Max(l1, l2), Math.Min(r1, r2));
                else
                    // If the combined array is odd, the element to the right of our partition that's the smallest
                    // is our median. Consider the median of a single odd array when dividing the length by 2.
                    // This is just a natural result due to how integer division works relative to where our partition is placed.
                    return Math.Min(r1, r2);
            }
            else if (l1 > r2)
            {
                // If l1 > r2 when know that we chose too many elements from smaller array and we should choose less.
                // With this condition satisfied we know that choosing more elements from the smaller array will not give us 
                // a correct partition. 
                // The first time this condition executes it would be impossible for us to choose more elements as we already 
                // chose all the elements the first time.
                // We set the max = min + max / 2 which happens to already be the value of the nums1Partition.
                // Since we are minimizing be problem space by half by dividing by two we acheive a log n runtime.
                // Remeber what we are ultimately doing here is halving the number of elements we are chosing from our left array.

                max = nums1Partition; // Don't understand why I need a cut - 1 here. Try using more numbers.
            }
            else if (l2 > r1)
            {
                min = nums1Partition;  // Don't understand why I need a cut + 1 here. Try using more numbers. 
            }
        }

        return 0;
    }

    private static double FindMedianWhenEven(int num1, int num2) => (num1 + num2) / 2.0;

    private static bool IsEven(int num) => num % 2 == 0;

    private static int GetParitionLengths(int[] nums1, int[] nums2) => (nums1.Length + nums2.Length) / 2;

    private static void EnsureFirstSetShorter(ref int[] nums1, ref int[] nums2)
    {
        if (nums2.Length < nums1.Length)
            (nums2, nums1) = (nums1, nums2);
    }
}
