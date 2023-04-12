using System.Collections;

namespace DataStructures.Lists;

/// <summary>
/// Simple list node class used to construct singly linked lists.
/// </summary>
public class ListNode<T> : IEnumerable<ListNode<T>> where T : notnull
{
    /// <summary>
    /// The node's value.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// The concurrent list node.
    /// </summary>
    public ListNode<T>? Next { get; set; }

    /// <summary>
    /// The default constructor.
    /// </summary>
    /// <param name="value">The node's value.</param>
    public ListNode(T value) => Value = value;

    /// <summary>
    /// Operation to add a concurrent list node.
    /// </summary>
    /// <param name="value">The concurrent node's value.</param>
    /// <returns>The created node.</returns>
    public ListNode<T> Add(T value) => Next = new ListNode<T>(value);

    /// <summary>
    /// String representing the value of the current object.
    /// </summary>
    /// <returns>The string value of <see cref="Value"/></returns>
    public override string? ToString() => Value.ToString();

    public IEnumerator<ListNode<T>> GetEnumerator()
    {
        var tmp = this;

        while (tmp != null)
        {
            yield return tmp;
            tmp = tmp.Next;
        }
    } // If you want the fully implemented version without yeild set this function to => new ListNodeEnumerator(this);

    // Explicit interface implementation is required because in order to implement the generic IEnumerable<T> interface,
    // we also have to implement the IEnumerable interface. We are explicitly implementing it so that we can use
    // the same method signature as the generic signature (try commenting out and see errors).
    // Also we explicitly implement this interface and not the generic interface so that dynamically set variables (vars)
    // are typed correctly instead of being typed as object.
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class ListNodeEnumerator : IEnumerator<ListNode<T>>
    {
        /// <summary>
        /// The head of the list.
        /// </summary>
        public ListNode<T> Head { get; init; }

        /// <summary>
        /// The node of the list being iterated over.
        /// </summary>
        private ListNode<T>? Cur { get; set; }

        /// <summary>
        /// Flag determining of the end of list has been reached.
        /// </summary>
        private bool eol = false;

        /// <summary>
        /// Returns an enumumerator that iterates through the list.
        /// </summary>
        /// <param name="head">The head of the list iterator.</param>
        public ListNodeEnumerator(ListNode<T> head) => Head = head;

        ListNode<T> IEnumerator<ListNode<T>>.Current => Cur!;

        public object Current => Cur!;

        public bool MoveNext()
        {
            // Check if we finished iterating. 
            // Can't do a typical null check because of how iterators work, we have to start current at null.
            // Since both the beginning and end of a list starts with null we need another flag to denote finishing iteration.
            // We use null to denote the beginning of the list and a flag to denote the end.
            if (eol)
            {
                return false;
            }
            else if (Cur == null)
            {
                Cur = Head;
                return true;
            }
            else
            {
                Cur = Cur.Next;
                if (Cur == null)
                {
                    eol = true;
                    return false;
                }

                return true;
            }
        }

        public void Reset()
        {
            Cur = null;
            eol = false;
        }

        public void Dispose() { }
    }
}