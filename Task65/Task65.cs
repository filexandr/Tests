using System;

namespace Task65
{
    // 65.Given a singly linked list, print out its contents in reverse order. Can you do it without using any
    // extra space?
    // Time: O(n)
    // Space: O(1)
    public static class Task65
    {
        public static void PrintReverse(Node list)
        {
            Console.WriteLine($"{list?.Value ?? 0}");
            if (list == null) return;
            var node = ReverseLinkedList(list);
            while (node != null)
            {
                Console.Write($" {node.Value}");
                node = node.Next;
            }
        }

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