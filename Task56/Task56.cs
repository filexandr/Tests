using System.Collections.Generic;

namespace Task56
{
    // 56. Write, efficient code for extracting unique elements from a sorted list of array.
    // e.g. (1, 1, 3, 3, 3, 5, 5, 5, 9, 9, 9, 9) -> (1, 3, 5, 9).
    // Time: O(n)
    // Space: O(n)
    public static class Task56
    {
        public static List<int> ExtractUniqueElements(int[] input)
        {
            if (input == null || input.Length == 0)
                return null;

            var result = new List<int>(input.Length);
            int prevItem = input[0];
            result.Add(prevItem);

            for (var i = 1; i < input.Length; i++)
            {
                var item = input[i];
                if (prevItem != item)
                {
                    result.Add(item);
                    prevItem = item;
                }
            }

            return result;
        }
    }
}