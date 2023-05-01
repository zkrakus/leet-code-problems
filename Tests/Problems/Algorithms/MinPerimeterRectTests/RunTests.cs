using Problems.Algorithms;
using Xunit;

namespace Tests.Problems.Algorithms.MinPerimeterRectTests;
public class RunTests
{
    [Theory]
    [InlineData(22, 30)]
    [InlineData(204, 101)] // Prime
    public void ShouldReturnSolutionForInput(int assertion, int n)
    {
        Assert.Equal(assertion, MinPermimeterRect.Run(n));
    }
}
