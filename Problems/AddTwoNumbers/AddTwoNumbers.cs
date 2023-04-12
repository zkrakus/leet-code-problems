using DataStructures.Extensions.ListExtensions;
using DataStructures.Lists;

namespace Problems.AddTwoNumbers;

public static class AddTwoNumbers
{

    /// <summary>
    /// Algorithm: 
    /// Iterate through the lists while neither list is at the end of the list. 
    /// Add the numbers as you iterate. Add 1 if carry is true.
    /// Keep track of carrying as you add. If you carry, set carry to true and store only ones position of sum.
    /// Store the sum inside a new list node.
    /// Move to the next listnode in your list.
    /// Move to the next position of the two inputs.
    /// 
    /// When either list is finished iterating. Finish iterating through the other list while constructing the return list.
    /// Keep adding the carry if you overflow.
    /// After finishing iterating check for overflow one last time.
    /// 
    /// Notes:
    /// The lists are in reverse order so you don't need to worry about leading zeros to align integer positions.
    /// Since you can't carry more than 1 when adding a bool is sufficient to represent the carry.
    /// Since you are dealing with a list you will need to keep track of the head and the current position as you iterate to return the sum.
    /// 
    /// Analysis: 
    /// f(t) = O(max(m,n)) 
    /// f(s) = = max(m,n) + 1 = O(max(m,n))
    /// 
    /// </summary>
    /// <param name="l1">Head of first list to be summed.</param>
    /// <param name="l2">Head of second list to be summed.</param>
    /// <returns>The head of the summed list.</returns>
    public static ListNode<ushort>? Run(ListNode<ushort>? l1, ListNode<ushort>? l2)
    {
        // Handle constraints and arguments.
        if (l1 == null && l2 == null)
            return null;

        if (l1 == null)
            return l2;
        else if (l2 == null)
            return l1;

        ListNode<ushort>? sumListHead = null;
        var sumList = sumListHead;
        var carry = false;

        ushort sum;
        while (l1 != null && l2 != null)
        {
            //Add the numbers as you iterate. 
            sum = (ushort)(l1.Value + l2.Value);

            // Add 1 if carry is true.
            if (carry)
                sum++;

            // Carry if overflow
            carry = sum > 9;
            if (carry)
                sum %= 10;

            // Store the sum inside a new list node while keeping track of new list head.
            if (sumListHead != null)
            {
                sumList!.Next = new ListNode<ushort>(sum);
                sumList = sumList.Next;
            }
            // Handle first iteration.
            else
            {
                sumListHead = new ListNode<ushort>(sum);
                sumList = sumListHead;
            }

            // Increment position of lists
            l1 = l1.Next;
            l2 = l2.Next;
        }

        // If either of the lists have any contents remaining, set that list to l1;
        l1 = l2 ?? l1;

        // Finish iterating through the other list while constructing the return list.
        while (l1 != null)
        {
            // Add carry.
            sum = l1.Value;
            if (carry)
                sum++;

            // Carry if overflow.
            carry = (sum & 10) == 10;
            if (carry)
                sum %= 10;

            // Store sum inside new new list node.
            sumList!.Next = new ListNode<ushort>(sum);

            // Increment position of lists.
            sumList = sumList.Next;
            l1 = l1.Next;
        }

        // Add final carry if needed.
        if (carry)
            sumList!.Next = new ListNode<ushort>(1);

        return sumListHead;
    }

    /// <summary>
    /// Problem:
    /// Given the same problem as for Run, but the head represents the most significant place value.
    /// The output format is the same.
    /// 
    /// e.g. 123 + 123 = 246
    /// Input: (1)->(2)->(3), (1)->(2)->(3)
    /// Output: (6)->(4)->(2)
    /// 
    /// Algorithm:
    /// Same algorithm as for run except we start by reversing the inputs.
    /// 
    /// Analysis:
    /// f(t) = O(2 * max(m,n)) = O(max(m,n) 
    /// f(s) = O(max(m,n) + 1 = O(max(m,n)
    /// </summary>
    public static ListNode<ushort>? RunReverse(ListNode<ushort>? l1, ListNode<ushort>? l2)
    {
        if (l1 != null)
            l1 = l1.Reverse();

        if (l2 != null)
            l2 = l2.Reverse();

        return Run(l1, l2);
    }
}