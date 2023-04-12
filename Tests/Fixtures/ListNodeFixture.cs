using DataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Extensions.RandomExtensions;

namespace Tests.Fixtures;
internal static class ListNodeFixture
{
    /// <summary>
    /// Creates a linked list by segmenting the input such that each place value has a node.
    /// </summary>
    /// <remarks>
    /// The head of the list is the least significant digit in the input.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws exception when input is negative.
    /// </exception>
    /// <param name="input">The input to be converted.</param>
    /// <returns>The head of the list.</returns>
    public static ListNode<ushort> CreatePlaceValueList(long input)
    {
        if (input < 0)
            throw new ArgumentOutOfRangeException(nameof(input), $"Input cannot be negative.");

        var num = (ushort)(input % 10);
        input /= 10;

        ListNode<ushort> head = new(num);
        var node = head;
        while (input != 0)
        {
            num = (ushort)(input % 10);
            input /= 10;
            node.Next = new ListNode<ushort>(num);
            node = node.Next;
        }

        return head;
    }

    /// <summary>
    /// Generates a linked list of random values.
    /// </summary>
    /// <param name="length">The length of the list.</param>
    /// <param name="min">The minimum value range of a node.</param>
    /// <param name="max">The maximum value range of a node.</param>
    /// <returns>The head of the list.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The length must be > 0</exception>
    public static ListNode<long> CreateLongList(
        ulong length = 1,
        long min = long.MinValue,
        long max = long.MaxValue)
    {
        Random random = new();

        if (length < 1)
            throw new ArgumentOutOfRangeException(nameof(length), "Lists must be of at least length 1.");

        ListNode<long> head = new(random.NextLong(min, max));
        var cur = head;
        for (ulong i = 1; i < length; i++)
        {
            cur.Next = new(random.NextLong(min, max));
            cur = cur.Next;
        }

        return head;
    }

    /// <summary>
    /// Converts an array to a linked list.
    /// </summary>
    /// <param name="input">Array input.</param>
    /// <returns>The head of a singly linked list.</returns>
    /// <exception cref="ArgumentNullException">Throws exception when input is null or empty.</exception>
    public static ListNode<T> CreateList<T>(IEnumerable<T> input) where T : notnull
    {
        ListNode<T> head = new(input.First());
        var current = head;
        foreach (var item in input)
            current = current.Add(item);

        return head;
    }
}