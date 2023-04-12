using Problems.Algorithms.Strings.LongestPalindromicSubstring;
using Xunit;

namespace Tests.Problems.Algorithms.Strings.LongestPalindromicSubstringTests;
public class ExpandAroundCenterTests
{
    [Fact]
    public void Should_Init() => Assert.Equal("", LongestPalindromicSubstring.ExpandAroundCenter(""));

    [Fact]
    public void Should_Find_Longest_Palindromic_Substring()
    {
        Assert.Equal("a", LongestPalindromicSubstring.ExpandAroundCenter("a"));
        Assert.Equal("aa", LongestPalindromicSubstring.ExpandAroundCenter("aa"));
        Assert.Equal("a", LongestPalindromicSubstring.ExpandAroundCenter("ab"));
        Assert.Equal("aba", LongestPalindromicSubstring.ExpandAroundCenter("aba"));
        Assert.Equal("a", LongestPalindromicSubstring.ExpandAroundCenter("abc"));
        Assert.Equal("dcabacd", LongestPalindromicSubstring.ExpandAroundCenter("dcabacde"));
        Assert.Equal("bab", LongestPalindromicSubstring.ExpandAroundCenter("babad"));
    }
}
