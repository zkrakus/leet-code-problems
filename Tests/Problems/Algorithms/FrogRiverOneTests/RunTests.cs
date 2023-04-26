using Problems.Algorithms.FrogRiverOne;
using Xunit;

namespace Tests.Problems.Algorithms.FrogRiverOneTests;
public class RunTests
{
    [Fact]
    public void ShouldReturnSolution_ForInput()
    {
        Assert.Equal(6, FrogRiverOne.Run(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }));
    }
}
