using Algorithms.Search;
using System;
using Xunit;

namespace Tests.Algorithms.BinarySearchTests;
public class SearchTests
{
    [Fact]
    public void Should_Init() =>
        Assert.Equal(~0, BinarySearch.Search(Array.Empty<int>(), 0));

    [Fact]
    public void Should_Return_Correct_Index_When_Found()
    {
        Assert.Equal(0, BinarySearch.Search(new int[] { 0 }, 0));
        Assert.Equal(1, BinarySearch.Search(new int[] { 0, 1 }, 1));
        Assert.Equal(1, BinarySearch.Search(new int[] { 0, 1, 2 }, 1));
    }

    [Fact]
    public void Should_Return_Correct_Index_Complement_When_Not_Found()
    {
        Assert.Equal(~1, BinarySearch.Search(new int[] { 0 }, 1));
        Assert.Equal(~1, BinarySearch.Search(new int[] { 0, 2 }, 1));
        Assert.Equal(~2, BinarySearch.Search(new int[] { 0, 1 }, 2));
    }

    //TODO: BinarySearchTests - Add test for a random integer in an array of randomly composed integers that is sorted.
}