using Problems.Algorithms.MedianOfTwoSortedArrays;
using Xunit;

namespace Tests.Problems.Algorithms.MediaOfTwoSortedArraysTests;
public class RunTests
{
    // Take a break on this problem and come back to it.
    // Make a median function that works on arrays.
    // Make a test that creates a bunch of arrays of varying lengths and finds the median 
    // then compare it to your code.
    [Fact]
    public void Should_Find_Median()
    {

        //var nums1 = new int[] { 1, 3, 4, 7, 10, 12 };
        //var nums2 = new int[] { 2, 3, 6, 15 };
        //var median = MedianOfTwoSortedArrays.Run(nums1, nums2);

        //nums1 = new int[] { 1, 3, 4, 7, 10, 12, 13 };
        //nums2 = new int[] { 2, 3, 6, 15 };
        //median = MedianOfTwoSortedArrays.Run(nums1, nums2);

        //nums1 = new int[] { 7, 12, 14, 15 };
        //nums2 = new int[] { 1, 2, 3, 4, 9, 11 };

        //median = MedianOfTwoSortedArrays.Run(nums1, nums2);

        var nums1 = new int[] { 1 };
        var nums2 = new int[] { 2 };

        _ = MedianOfTwoSortedArrays.Run(nums1, nums2);
    }
}
