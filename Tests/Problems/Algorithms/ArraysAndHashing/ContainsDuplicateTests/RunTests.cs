using Problems.Algorithms.ArraysAndHashing.ContainsDuplicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.ArraysAndHashing.ContainsDuplicateTests;

public class RunTests
{
    [Fact]
    public void ShouldReturnFlase_WhenEmpty()
    {
        Assert.False(ContainsDuplicate.Run(Array.Empty<int>()));
    }

    [Fact]
    public void ShouldReturnFlase_WhenSingleElement()
    {
        Assert.False(ContainsDuplicate.Run(new int[] { 0 }));
    }

    [Fact]
    public void ShouldReturnFalse_WhenElementsUnique()
    {
        Assert.False(ContainsDuplicate.Run(new int[] { 0, 1 }));
    }

    [Fact]
    public void ShouldReturnTrue_WhenArrayHasDuplicates()
    {
        Assert.True(ContainsDuplicate.Run(new int[] { 0, 0 }));
    }

    [Fact]
    public void ShouldReturnFalse_ForBoundaries()
    {
        var first = (int)Math.Pow(10, 9);
        var last = (int)Math.Pow(10, 9) * -1;

        Assert.False(ContainsDuplicate.Run(new int[] { first, last }));
    }

    [Fact]
    public void ShouldReturnFalse_ForLargeArray()
    {
        var nums = Enumerable.Range(1, (int)Math.Pow(10, 5)).ToArray();

        Assert.False(ContainsDuplicate.Run(nums));
    }

    [Fact]
    public void ShouldReturnTrue_ForLargeArray()
    {
        var nums = Enumerable.Range(1, (int)Math.Pow(10, 5)).ToArray();
        nums[nums.Length - 1]--;

        Assert.True(ContainsDuplicate.Run(nums));
    }
}
