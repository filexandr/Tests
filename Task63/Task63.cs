using System;
using System.Collections.Generic;

namespace Task63
{
    // 63.Given a list of numbers(fixed list). Now given any other list, how can you efficiently find out if
    // there is any element in the second list that is an element of the first list(fixed list). 
    // Time: O(n)
    // Space: O(1)
    public static class Task63
    {
        public static bool Intersects(Node list1, Node list2)
        {
            if (list1 == null || list2 == null) return false;
            if (list1.Next == null && list2.Next == null) return list1 == list2;

            if (IsСyclical(list1)) throw new ArgumentException("List 1 is cyclical.");
            if (IsСyclical(list2)) throw new ArgumentException("List 2 is cyclical.");

            var list2EndNode = list2;
            while (list2EndNode.Next != null) list2EndNode = list2EndNode.Next;
            list2EndNode.Next = list1;
            return IsСyclical(list2);
        }

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