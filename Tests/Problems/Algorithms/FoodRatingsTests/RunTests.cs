﻿using Problems.Algorithms.FoodRatings;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.FoodRatingsTests;
public class RunTests
{
    [Fact]
    public void ShouldFindHighestAverageRating()
    {
        FoodRatings.Run();
        Console.WriteLine();
    }
}
