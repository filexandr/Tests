using System.Collections.Generic;

namespace Task63
{
    // 63.Given a list of numbers(fixed list). Now given any other list, how can you efficiently find out if
    // there is any element in the second list that is an element of the first list(fixed list). 
    // Time: O(n1 + n2)
    // Space: O(n1)
    public static class Task63
    {
        public static bool Intersects(int[] list1, int[] list2)
        {
            if (list1 == null || list1.Length == 0 ||
                list2 == null || list2.Length == 0) return false;

            var hash = new HashSet<int>();
            foreach (var i in list1)
            {
                hash.Add(i);
            }

            foreach (var i in list2)
            {
                if (hash.Contains(i)) return true;
            }

            return false;
        }
    }
}