namespace Task64
{
    // 64.Given a singly linked list, determine whether it contains a loop or not
    // Time: O(n)
    // Space: O(1)
    public static class Task64
    {
        public static bool IsСyclical(Node headNode)
        {
            if (headNode?.Next == null) return false;

            Node walker1 = headNode;
            Node walker2 = headNode.Next;
            while (walker1 != null && walker2 != null)
            {
                if (walker1 == walker2) return true;
                walker1 = walker1.Next;
                walker2 = walker2.Next?.Next;
            }

            return false;
        }
    }
}
