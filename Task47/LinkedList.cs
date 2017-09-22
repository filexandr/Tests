using System;

namespace Task47
{
    public class LinkedList
    {
        public Node Head { get; set; }

        // Time: O(N)
        // Space: O(1)
        public void AddLast(Node node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (Head == null)
            {
                Head = node;
                return;
            }

            var lastNode = findLeftAtIndex(int.MaxValue);
            lastNode.Next = node;

        }

        // Time: O(N)
        // Space: O(1)
        public void AddAtIndex(Node node, int index)
        {
            if (index == 0 || Head == null)
            {
                node.Next = Head;
                Head = node;
                return;
            }

            var leftNode = findLeftAtIndex(index);
            node.Next = leftNode.Next;
            leftNode.Next = node;
        }

        // Time: O(N)
        // Space: O(1)
        public void Delete(int index)
        {
            if (Head == null)
            {
                throw new Exception("List is empty.");
            }

            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            var leftNode = findLeftAtIndex(index);
            leftNode.Next = leftNode.Next?.Next;
        }

        private Node findLeftAtIndex(int index)
        {
            if (index <= 0) throw new ArgumentException("Index must be positive.", nameof(index));
            Node node = Head;
            for (var i = 1; i < index; i++)
            {
                if (node.Next == null) return node;
                node = node.Next;
            }

            return node;
        }
    }
}