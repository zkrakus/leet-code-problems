using Problems.Algorithms.ReverseInteger;
using Xunit;

namespace Tests.Problems.Algorithms.ReverseIntegerTests;
public class RunTests
{
    [Fact]
    public void Should_Reverse_Integer()
    {
        Assert.Equal(0, ReverseInteger.Run(0));
        Assert.Equal(1, ReverseInteger.Run(-1));
        Assert.Equal(-1, ReverseInteger.Run(1));
        Assert.Equal(321, ReverseInteger.Run(-123));
        Assert.Equal(-321, ReverseInteger.Run(123));
    }

    [Fact]
    public void Should_Not_Overflow()
    {
        Assert.Equal(0, ReverseInteger.Run(int.MinValue));
        Assert.Equal(0, ReverseInteger.Run(int.MaxValue));
    }
}
