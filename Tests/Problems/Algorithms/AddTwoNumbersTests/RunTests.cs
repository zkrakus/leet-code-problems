﻿using Core.Extensions.RandomExtensions;
using Problems.Algorithms.AddTwoNumbers;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Problems.Algorithms.AddTwoNumbersTests;

public class RunTests
{
    private readonly ITestOutputHelper output;

    public RunTests(ITestOutputHelper output) => this.output = output;

    [Fact]
    public void Should_Init() =>
        _ = AddTwoNumbers.Run(null, null);

    [Fact]
    public void Should_Return_Non_Null_Identity_List()
    {
        var rand = new Random();
        var n1 = rand.NextLong(1, 10000);
        var expectedResult = Fixtures.ListNodeFixture.CreatePlaceValueList(n1);

        var l1 = Fixtures.ListNodeFixture.CreatePlaceValueList(n1);
        var result = AddTwoNumbers.Run(l1, null);

        var enum1 = result!.GetEnumerator();
        var enum2 = expectedResult.GetEnumerator();
        output.WriteLine("Result | Expected");
        while (enum1.MoveNext() && enum2.MoveNext())
        {
            Assert.Equal(enum1.Current.ToString(), enum2.Current.ToString());
            output.WriteLine(enum1.Current.ToString() + " | " + enum2.Current.ToString());
        }
        output.WriteLine("");

        result = AddTwoNumbers.Run(null, l1);
        enum1 = result!.GetEnumerator();
        enum2 = expectedResult.GetEnumerator();
        output.WriteLine("Result | Expected");
        while (enum1.MoveNext() && enum2.MoveNext())
        {
            Assert.Equal(enum1.Current.ToString(), enum2.Current.ToString());
            output.WriteLine(enum1.Current.ToString() + " | " + enum2.Current.ToString());
        }
    }

    [Fact]
    public void Should_Add()
    {
        var rand = new Random();
        var n1 = rand.NextLong(1, 10000);
        var n2 = rand.NextLong(1, 10000);
        var expectedResult = Fixtures.ListNodeFixture.CreatePlaceValueList(n1 + n2);

        var l1 = Fixtures.ListNodeFixture.CreatePlaceValueList(n1);
        var l2 = Fixtures.ListNodeFixture.CreatePlaceValueList(n2);
        var result = AddTwoNumbers.Run(l1, l2);

        var enum1 = result!.GetEnumerator();
        var enum2 = expectedResult.GetEnumerator();
        output.WriteLine("Result | Expected");
        while (enum1.MoveNext() && enum2.MoveNext())
        {
            Assert.Equal(enum1.Current.ToString(), enum2.Current.ToString());
            output.WriteLine(enum1.Current.ToString() + " | " + enum2.Current.ToString());
        }
    }

    [Fact]
    public void Should_Carry()
    {
        var n1 = 99;
        var n2 = 9;
        var sum = n1 + n2;

        var l1 = Fixtures.ListNodeFixture.CreatePlaceValueList(n1);
        var l2 = Fixtures.ListNodeFixture.CreatePlaceValueList(n2);

        var expectedResult = Fixtures.ListNodeFixture.CreatePlaceValueList(sum);
        var result = AddTwoNumbers.Run(l1, l2);

        var enum1 = result!.GetEnumerator();
        var enum2 = expectedResult.GetEnumerator();
        output.WriteLine("Result | Expected");
        while (enum1.MoveNext() && enum2.MoveNext())
        {
            Assert.Equal(enum1.Current.ToString(), enum2.Current.ToString());
            output.WriteLine(enum1.Current.ToString() + " | " + enum2.Current.ToString());
        }
    }
}