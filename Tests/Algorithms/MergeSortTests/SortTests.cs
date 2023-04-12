using Algorithms.Sorts;
using System;
using System.Linq;
using Xunit;

namespace Tests.Algorithms.MergeSortTests;

public class SortTests
{
    [Fact]
    public static void Should_Init() => MergeSort.Sort(Array.Empty<int>());

    [Fact]
    public static void Should_Sort()
    {
        Assert.True(Enumerable.SequenceEqual(MergeSort.Sort(new int[] { 1 }), new int[] { 1 }));
        Assert.True(Enumerable.SequenceEqual(MergeSort.Sort(new int[] { 2, 1 }), new int[] { 1, 2 }));
        Assert.True(Enumerable.SequenceEqual(MergeSort.Sort(new int[] { 3, 2, 1 }), new int[] { 1, 2, 3 }));
        Assert.True(Enumerable.SequenceEqual(MergeSort.Sort(new int[] { 4, 3, 2, 1 }), new int[] { 1, 2, 3, 4 }));
        Assert.True(Enumerable.SequenceEqual(MergeSort.Sort(new int[] { 3, 1, 4, 2 }), new int[] { 1, 2, 3, 4 }));
        Assert.True(Enumerable.SequenceEqual(MergeSort.Sort(new int[] { 3, 4, 2, 1 }), new int[] { 1, 2, 3, 4 }));
    }
}
