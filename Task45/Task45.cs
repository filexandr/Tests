using System;
using System.Collections.Generic;

namespace Task45
{
    // 45. Insert in a sorted list.
    // Time: O(N * log N)
    // Space: O(log N)
    public static class Task45
    {
        public static void InsertInSortedList(List<int> list, int value)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (list.Count == 0)
            {
                list.Add(value);
                return;
            }

            if (value <= list[0])
            {
                list.Insert(0, value);
                return;
            }

            if (value >= list[list.Count - 1])
            {
                list.Add(value);
                return;
            }

            list.Insert(FindInsertPos(list, 0, list.Count - 1, value), value);
        }

        private static int FindInsertPos(List<int> list, int from, int to, int value)
        {
            if (list[from] <= value && list[to] >= value)
            {
                if (to - from <= 1) return from;
                var middle = from + (to - from) / 2;

                var leftPos = FindInsertPos(list, from, middle, value);
                if (leftPos >= 0) return leftPos;

                var rightPos = FindInsertPos(list, middle, to, value);
                if (rightPos >= 0) return rightPos;
            }

            return -1;
        }
    }
}