using Problems.Algorithms.Strings.IntegerToRoman;
using Xunit;

namespace Tests.Problems.Algorithms.Strings.IntegerToRomanTests;
public class RunTests
{
    [Fact]
    public void Run_ShouldReturnEmpty_WhenNeagative()
    {
        Assert.Equal("", IntegerToRoman.Run(-1));
        Assert.Equal("", IntegerToRoman.Run(int.MinValue));
    }

    [Fact]
    public void Run_ShouldReturnRoman_WhenI()
    {
        Assert.Equal("I", IntegerToRoman.Run(1));
        Assert.Equal("II", IntegerToRoman.Run(2));
        Assert.Equal("III", IntegerToRoman.Run(3));
    }

    [Fact]
    public void Run_ShouldReturnRoman_WhenFour() => Assert.Equal("IV", IntegerToRoman.Run(4));

    [Fact]
    public void Run_ShouldReturnRoman_WhenFive() => Assert.Equal("V", IntegerToRoman.Run(5));

    [Fact]
    public void Run_ShouldReturnRoman_WhenGreaterThanFiveLessThanNine()
    {
        Assert.Equal("VI", IntegerToRoman.Run(6));
        Assert.Equal("VII", IntegerToRoman.Run(7));
        Assert.Equal("VIII", IntegerToRoman.Run(8));
    }

    [Fact]
    public void Run_ShouldReturnRoman_WhenGreaterThanEightLessThanTen() => Assert.Equal("IX", IntegerToRoman.Run(9));

    [Fact]
    public void Run_ShouldReturnRoman_WhenTen() => Assert.Equal("X", IntegerToRoman.Run(10));

    [Fact]
    public void Run_ShouldReturnRoman_WhenGreaterThanTenLessThanFourty()
    {
        Assert.Equal("X", IntegerToRoman.Run(10));
        Assert.Equal("XI", IntegerToRoman.Run(11));
        Assert.Equal("XIV", IntegerToRoman.Run(14));
        Assert.Equal("XVI", IntegerToRoman.Run(16));
        Assert.Equal("XX", IntegerToRoman.Run(20));
        Assert.Equal("XXXIX", IntegerToRoman.Run(39));
    }

    [Fact]
    public void Run_ShouldReturnRoman_WhenGreaterThanThirtyNineLessThanFifty()
    {
        Assert.Equal("XL", IntegerToRoman.Run(40));
        Assert.Equal("XLV", IntegerToRoman.Run(45));
        Assert.Equal("XLIX", IntegerToRoman.Run(49));
    }

    [Fact]
    public void Run_ShouldReturnRoman_WhenFifty() => Assert.Equal("L", IntegerToRoman.Run(50));

    [Fact]
    public void Run_ShouldReturnRoman_WhenGreaterThanFiftyLessThanNinety()
    {
        Assert.Equal("LI", IntegerToRoman.Run(51));
        Assert.Equal("LX", IntegerToRoman.Run(60));
        Assert.Equal("LXXX", IntegerToRoman.Run(80));
        Assert.Equal("LXXXIX", IntegerToRoman.Run(89));
    }

    [Fact]
    public void Run_ShouldReturnRoman_WhenGreaterThanNinetyLessThan100()
    {
        Assert.Equal("XC", IntegerToRoman.Run(90));
        Assert.Equal("XCIX", IntegerToRoman.Run(99));
    }

    [Fact]
    public void Run_ShouldReturnRoman()
    {
        Assert.Equal("C", IntegerToRoman.Run(100));
        Assert.Equal("CD", IntegerToRoman.Run(400));
        Assert.Equal("D", IntegerToRoman.Run(500));
        Assert.Equal("CM", IntegerToRoman.Run(900));
        Assert.Equal("CML", IntegerToRoman.Run(950));
        Assert.Equal("M", IntegerToRoman.Run(1000));
        Assert.Equal("MC", IntegerToRoman.Run(1100));
    }
}
