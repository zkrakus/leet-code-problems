using Problems.Algorithms.FindIntervalsOfDuplicateElements;
using System;
using System.Linq;
using Xunit;

namespace Tests.Problems.Algorithms.FindIntervalsOfDuplicateElementsTests;
public class EunTests
{
    [Fact]
    public static void Should_Init() => FindIntervalsOfDuplicateElements.Run(Array.Empty<char>());

    [Fact]
    public static void Should_Segement_Array()
    {
        Assert.True((new int[] { 1 }).SequenceEqual(FindIntervalsOfDuplicateElements.Run(new char[] { 'a' })));
        Assert.True((new int[] { 2 }).SequenceEqual(FindIntervalsOfDuplicateElements.Run(new char[] { 'a', 'a' })));
        Assert.True((new int[] { 1, 1 }).SequenceEqual(FindIntervalsOfDuplicateElements.Run(new char[] { 'a', 'b' })));
        Assert.True((new int[] { 1, 1, 1 }).SequenceEqual(FindIntervalsOfDuplicateElements.Run(new char[] { 'a', 'b', 'c' })));
        Assert.True((new int[] { 3 }).SequenceEqual(FindIntervalsOfDuplicateElements.Run(new char[] { 'a', 'b', 'a' })));
        Assert.True((new int[] { 3, 1 }).SequenceEqual(FindIntervalsOfDuplicateElements.Run(new char[] { 'a', 'b', 'a', 'c' })));
        Assert.True((new int[] { 5 }).SequenceEqual(FindIntervalsOfDuplicateElements.Run(new char[] { 'a', 'b', 'a', 'c', 'b' })));
    }
}
