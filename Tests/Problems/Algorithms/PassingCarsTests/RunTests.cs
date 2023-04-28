using Problems.Algorithms.PassingCars;
using Xunit;

namespace Tests.Problems.Algorithms.PassingCarsTests;
public class RunTests
{
    [Fact]
    public void ShouldReturnSolution_ForInput()
    {
        Assert.Equal(5, PassingCars.Run(new int[] { 0, 1, 0, 1, 1 }));
    }
}
