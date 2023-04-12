using DataStructures.Lists;

namespace DataStructures.Extensions.StackExtensions;

public static class StackExtensions
{
    /// <summary>
    /// Converts a stack to a list of type <see cref="ListNode"/>.
    /// </summary>
    /// <param name="stack">The stack to convert.</param>
    /// <remarks></remarks>
    /// <returns>The head of the list.</returns>
    /// <exception cref="InvalidOperationException">
    /// Throws an invalid operation if trying to convert an empty stack to a list.
    /// Reasoning: a valid list contains at least one list element. 
    /// We could return a null value, but then we have to remember to null coalesce this edge case.
    /// Instead we require a valid input to ensure this edge case is not missed.
    /// This also plays better with C# 8.0's Nullable Reference Types.
    /// </exception>
    public static ListNode<T> ToListNode<T>(this Stack<T> stack) where T : notnull
    {
        var tmpList = stack.ToList();
        if (tmpList.Count < 1)
            throw new InvalidOperationException("Cannot convert an empty stack to a list.");

        var head = new ListNode<T>(tmpList[0]);
        var cur = head;
        foreach (var item in tmpList.Skip(1))
        {
            cur.Next = new ListNode<T>(item);
            cur = cur.Next;
        }

        return head;
    }
}
