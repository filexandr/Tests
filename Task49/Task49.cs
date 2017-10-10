using System;

namespace Task49
{
    // 49.Delete an element from a doubly linked list. 
    // Time: O(N)
    // Space: O(1)
    public static class Task49
    {
        public static Node Delete(Node head, Node toDelete)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));
            if (toDelete == null) throw new ArgumentNullException(nameof(toDelete));

            var node = head;
            while (node != null && node != toDelete)
            {
                node = node.Next;
            }

            if (node == null)
            {
                throw new Exception("Node not found");
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