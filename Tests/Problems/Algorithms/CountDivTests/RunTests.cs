using Problems.Algorithms.CountDiv;
using Xunit;

namespace Tests.Problems.Algorithms.CountDivTests;
public class RunTests
{
    [Fact]
    public void ShouldReturnSolution_ForInput()
    {
        Assert.Equal(1, CountDiv.Run(0, 0, 11));
        Assert.Equal(0, CountDiv.Run(1, 1, 11));
        Assert.Equal(3, CountDiv.Run(6, 11, 2));
        Assert.Equal(20, CountDiv.Run(11, 345, 17));
        Assert.Equal(2000000000, CountDiv.Run(0, int.MaxValue, 1));
        Assert.Equal(2000000000, CountDiv.Run(0, int.MaxValue, int.MaxValue));
    }
}
