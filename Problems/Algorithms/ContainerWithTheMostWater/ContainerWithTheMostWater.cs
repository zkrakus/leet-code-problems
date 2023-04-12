namespace Problems.Algorithms.ContainerWithTheMostWater;

/// <summary>
/// Problem:
/// 
/// You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
/// Find two lines that together with the x-axis form a container, such that the container contains the most water.
/// Return the maximum amount of water a container can store.
/// </summary>
public static class ContainerWithTheMostWater
{
    /// <summary>
    /// Algorithm:
    /// 
    /// Find all combinatins of heights from the input and keep track of the area for each combination.
    /// 
    /// Analysis:
    /// t(n) = (n, k) = n(n-1) / 2 = O(n^2)
    /// s(n) = O(1)
    /// </summary>
    /// <returns></returns>
    public static int RunBruteForce(int[] heights)
    {
        if (heights.Length is 0 or 1)
            return 0;

        var maxArea = 0;
        for (var left = 0; left < heights.Length - 1; left++)
        {
            for (var right = heights.Length - 1; left < right; right--)
            {
                var height = GetWaterHeight(heights[left], heights[right]);
                var width = GetWidth(left, right);
                var area = GetArea(height, width);
                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }

    /// <summary>
    /// Algorithm:
    /// 
    /// We can optimize the brute force algorithm by having left and right pointers. We know that the primary constraints and 
    /// maximizing the water level is the height of the left and right sides of the container. We find the area moving in from 
    /// the left and right most outwards sides of the container. We only move the pointer on the side that has the lower height
    /// moving towards the center finding the max area along the way.
    /// 
    /// Analysis:
    /// t(n) = O(n)
    /// s(n) = O(1)
    /// </summary>
    public static int RunOptimized(int[] heights)
    {
        if (heights.Length is 0 or 1)
            return 0;

        var maxArea = 0;

        int left = 0, right = heights.Length - 1;
        while (left < right)
        {
            var leftHeight = heights[left];
            var rightHeight = heights[right];

            var height = GetWaterHeight(leftHeight, rightHeight);
            var width = GetWidth(left, right);
            var area = GetArea(height, width);
            maxArea = Math.Max(maxArea, area);

            if (leftHeight >= rightHeight)
                right--;
            else
                left++;
        }

        return maxArea;
    }

    private static int GetArea(int height, int width) => height * width;

    private static int GetWaterHeight(int leftHeight, int rightHeight)
        => leftHeight > rightHeight
            ? rightHeight
            : leftHeight;

    private static int GetWidth(int left, int right) => right - left;
}
