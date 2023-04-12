using Problems.Algorithms.Strings.LongestSubstringWithoutRepeatingCharacters;
using System.Linq;
using Xunit;

namespace Tests.Problems.Algorithms.Strings.LongestSubstringWIthoutRepeatingCharactersTests;
public class RunTests
{
    [Fact]
    public static void Should_Init()
    {
        Assert.Equal("", LongestSubstringWIthoutRepeatingCharacters.Run(""));
        Assert.Equal("a", LongestSubstringWIthoutRepeatingCharacters.Run("a"));

    }

    [Fact]
    public static void Should_Find_Longest_Substring()
    {
        Assert.True("ab".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("ab")));
        Assert.True("ab".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("abb")));
        Assert.True("ab".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("abba")));
        Assert.True("a".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("aa")));
        Assert.True("ab".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("aba")));
        Assert.True("abcd".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("abcabcd")));
        Assert.True("abcd".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("abcdabc")));
        Assert.True("abcd".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("abcdabcd")));
        Assert.True("abc".SequenceEqual(LongestSubstringWIthoutRepeatingCharacters.Run("abcabcbb")));
    }

    [Fact]
    public static void Should_Find_Longest_Substring_Length()
    {
        Assert.Equal(1, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("aa"));
        Assert.Equal(2, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("ab"));
        Assert.Equal(2, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("abb"));
        Assert.Equal(2, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("aba"));
        Assert.Equal(2, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("abba"));
        Assert.Equal(4, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("abcabcd"));
        Assert.Equal(4, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("abcdabc"));
        Assert.Equal(4, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("abcdabcd"));
        Assert.Equal(3, LongestSubstringWIthoutRepeatingCharacters.RunOptimized("abcabcbb"));
    }
}
