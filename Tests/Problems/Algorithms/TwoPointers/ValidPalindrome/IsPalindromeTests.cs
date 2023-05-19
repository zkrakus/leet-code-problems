using Problems.Algorithms.TwoPointers.ValidPalindrome;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Problems.Algorithms.TwoPointers.ValidPalindrome;

public class IsPalindromeTests
{
    [Theory]
    [MemberData(nameof(PalindromeTestData.WhenEmptyData), MemberType = typeof(PalindromeTestData))]
    public void ShouldReturnTrue_WhenEmpty(IValidPalindrome @class, string[] inputs)
    {
        foreach (var input in inputs)
            Assert.True(@class.IsPalindrome(input));
    }

    [Theory]
    [MemberData(nameof(PalindromeTestData.ValidPalindromeImplementations), MemberType = typeof(PalindromeTestData))]
    public void ShouldReturnTrue_WhenPalindrome(IValidPalindrome @class)
    {
        var allCharacters = Enumerable.Range('a', 26).Union(Enumerable.Range('A', 26));
        var palindrome = new string(allCharacters.Concat(allCharacters.Reverse()).Select(c => (char)c).ToArray());

        Assert.True(@class.IsPalindrome(palindrome.ToString()!));
    }

    [Theory]
    [MemberData(nameof(PalindromeTestData.ValidPalindromeImplementations), MemberType = typeof(PalindromeTestData))]
    public void ShouldReturnTrue_WhenPalindromeHasInvalidCharacters(IValidPalindrome @class)
    {
        var allCharacters = Enumerable.Range('a', 26).Union(Enumerable.Range('A', 26)).Select(i => (char)i).ToArray();
        var nonCharacters = Array.FindAll(Enumerable.Range(0, 128).Select(i => (char)i).ToArray(), (char c) => !char.IsLetter(c));
        var palindromeWithNonCharacters = new string(allCharacters.Concat(nonCharacters.Concat(allCharacters.Reverse())).ToArray());

        Assert.True(@class.IsPalindrome(palindromeWithNonCharacters));
    }

    [Theory]
    [MemberData(nameof(PalindromeTestData.ValidPalindromeImplementations), MemberType = typeof(PalindromeTestData))]
    public void ShouldReturnTrue_WhenPalindromeHasOddLength(IValidPalindrome @class)
    {
        const string input = "aAa";

        Assert.True(@class.IsPalindrome(input));
    }

    [Theory]
    [MemberData(nameof(PalindromeTestData.ValidPalindromeImplementations), MemberType = typeof(PalindromeTestData))]
    public void ShouldReturnFalse_WhenNotPalindrome(IValidPalindrome @class)
    {
        const string input = "ab";

        Assert.False(@class.IsPalindrome(input));
    }


    private static class PalindromeTestData { 
        private static IEnumerable<IValidPalindrome> ValidPalindromeCollection =>
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type =>
                    typeof(IValidPalindrome).IsAssignableFrom(type)
                    && !type.IsAbstract
                    && !type.IsGenericType
                    && type.GetConstructor(Array.Empty<Type>()) != null)
                .Select(type => (IValidPalindrome)Activator.CreateInstance(type)!)
            .ToArray();

        public static IEnumerable<object[]> ValidPalindromeImplementations =>
            ValidPalindromeCollection.Select(@class => new object[] { @class });

        public static IEnumerable<object[]> WhenEmptyData => ValidPalindromeCollection.Select(@class => new object[] { @class, WhenEmptyInput });

        private static readonly string[] WhenEmptyInput = new string[] { "", " " };
    }
}
