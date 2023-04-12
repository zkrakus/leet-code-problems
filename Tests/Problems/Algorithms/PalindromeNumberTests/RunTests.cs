using Problems.Algorithms.PalindromeNumber;
using Xunit;

namespace Tests.Problems.Algorithms.PalindromeNumberTests;
public class RunTests
{

    [Fact]
    public void Should_Check_If_Palindrome()
    {
        Assert.False(PalindromeNumber.Run(-1));
        Assert.True(PalindromeNumber.Run(1));
        Assert.True(PalindromeNumber.Run(11));
        Assert.True(PalindromeNumber.Run(121));
        Assert.True(PalindromeNumber.Run(1221));
        Assert.False(PalindromeNumber.Run(123));
        Assert.False(PalindromeNumber.Run(int.MaxValue));

    }
}
