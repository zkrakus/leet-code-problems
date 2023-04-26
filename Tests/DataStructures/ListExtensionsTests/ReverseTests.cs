using DataStructures.Extensions.ListExtensions;
using DataStructures.Lists;
using System;
using System.Collections.Generic;
using Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace Tests.DataStructures.ListExtensionsTests;

public class ReverseTests
{
    private readonly ITestOutputHelper output;

    public ReverseTests(ITestOutputHelper output) => this.output = output;

    [Fact]
    public void ListNode_Reverse_Should_Init()
    {
        ListNode<ushort> node = new(0);
        _ = node!.Reverse();
        Assert.Equal(0, node.Value);
    }

    [Fact]
    public void ListNode_Reverse_Should_Throw_When_Null()
    {
        ListNode<ushort>? nullNode = null;
        _ = Assert.Throws<ArgumentNullException>(() => _ = nullNode!.Reverse());
    }

    [Fact]
    public void ListNode_Reverse_Should_Reverse()
    {
        var head = ListNodeFixture.CreateLongList(length: 3, min: -100, max: 100);

        Stack<long> stack = new();
        var testOutput = "List: ";
        foreach (var item in head)
        {
            stack.Push(item.Value);
            testOutput += $"{item}, ";
        }
        output.WriteLine(testOutput[0..^2]);

        head = head.Reverse();
        testOutput = "List Reverse: ";
        foreach (var item in head!)
        {
            testOutput += $"{item}, ";
            Assert.Equal(item.Value, stack.Pop());
        }
        output.WriteLine(testOutput[0..^2]);
    }
}