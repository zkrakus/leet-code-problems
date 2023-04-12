using Problems.Algorithms.Strings.LongestPalindromicSubstring;
using Xunit;

namespace Tests.Problems.Algorithms.Strings.LongestPalindromicSubstringTests;
public static class RunBruteForceTests
{
    [Fact]
    public static void Should_Init() => Assert.Equal("", LongestPalindromicSubstring.RunBruteForce(""));

    [Fact]

    public static void Should_Find_Longest_Palindromic_Substring()
    {
        Assert.Equal("a", LongestPalindromicSubstring.RunBruteForce("a"));
        Assert.Equal("aa", LongestPalindromicSubstring.RunBruteForce("aa"));
        Assert.Equal("a", LongestPalindromicSubstring.RunBruteForce("ab"));
        Assert.Equal("aba", LongestPalindromicSubstring.RunBruteForce("aba"));
        Assert.Equal("a", LongestPalindromicSubstring.RunBruteForce("abc"));
        Assert.Equal("dcabacd", LongestPalindromicSubstring.RunBruteForce("dcabacde"));
        Assert.Equal("bab", LongestPalindromicSubstring.RunBruteForce("babad"));
    }
}
