namespace Task44
{
    // 44. Reverse a linked list.
    // Time: O(n)
    // Space: O(1) 
    public static class Task44
    {
        public static Node ReverseLinkedList(Node node)
        {
            if (node?.Next == null) return node;

            var next = node.Next;
            node.Next = null;

            while (next != null)
            {
                var oldNext = next.Next;
                next.Next = node;
                node = next;
                next = oldNext;
            }

            return node;
        }
    }
}