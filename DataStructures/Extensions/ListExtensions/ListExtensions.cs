using DataStructures.Extensions.StackExtensions;
using DataStructures.Lists;

namespace DataStructures.Extensions.ListExtensions;

public static class ListExtensions
{
    /// <summary>
    /// Reverses a list.
    /// </summary>
    /// <param name="node">The head of a list.</param>
    /// <returns>The head of the reversed list.</returns>
    public static ListNode<T> Reverse<T>(this ListNode<T> node) where T : notnull => node.ToStack().ToListNode();

    /// <summary>
    /// Converts a list to a stack of nodes.
    /// </summary>
    /// <remarks>
    /// Elements are pushed onto the stack in the opposite order in which they are iterated over.
    /// The first element in the list will be at the top of the stack. 
    /// </remarks>
    /// <param name="node">The head of a list.</param>
    /// <returns>A stack of <see cref="ListNode"/></returns>
    public static Stack<T> ToStackInverted<T>(this ListNode<T> node) where T : notnull
    {
        var stack = node.ToStack();
        Stack<T> invertedStack = new();
        foreach (var item in stack)
        {
            invertedStack.Push(item);
        }

        return invertedStack;
    }

    /// <summary>
    /// Converts a list to a stack of ListNode.
    /// </summary>
    /// <remarks>Elements are pushed onto the stack in the same order in which they are iterated over.</remarks>
    /// <param name="node">The head of a list.</param>
    /// <exception cref="Exception">Throws exception when node is null.</exception>
    /// <returns>A stack of the list.</returns>
    public static Stack<T> ToStack<T>(this ListNode<T> node) where T : notnull
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node), "Cannot reverse a null list.");

        Stack<T> stack = new();
        foreach (var item in node)
            stack.Push(item.Value);

        return stack;
    }
}
