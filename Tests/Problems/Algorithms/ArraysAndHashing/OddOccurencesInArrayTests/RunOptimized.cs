using Problems.Algorithms.ArraysAndHashing.OddOccurencesInArray;
using Xunit;

namespace Tests.Problems.Algorithms.ArraysAndHashing.OddOccurencesInArrayTests;
public class RunOptimized
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 }, 5)] // Empty Array
    public void RunOptinized_ShouldReturnOddPair(int[] a, int assertion)
    {
        Assert.Equal(assertion, OddOccurencesInArray.RunOptimized(a));
    }
}
