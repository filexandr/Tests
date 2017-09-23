using System;

namespace Task49
{
    // 49.Delete an element from a doubly linked list. 
    // Time: O(N)
    // Space: O(1)
    public static class Task49
    {
        public static Node Delete(Node head, int index)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));
            if (index < 0) throw new IndexOutOfRangeException("Index must be positive.");

            var node = head;
            for (int i = 0; i < index; i++)
            {
                if (node.Next == null) break;
                node = node.Next;
            }

            // last element
            if (node.Next == null)
            {
                // list with one element
                if (node.Previous == null) return null;
                node.Previous = null;
                return head;
            }

            // first element
            if (node.Previous == null)
            {
                var oldNext = node.Next;
                node.Next = null;
                return oldNext;
            }

            // in the middle
            node.Previous.Next = node.Next;
            return head;
        }
    }
}