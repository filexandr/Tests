using System.Collections.Generic;

namespace Task61
{
    // 61.An array of pointers to(very long) strings.Find pointers to the(lexicographically) smallest and
    // largest strings
    // Time: O((maxlen+1)*n) where maxlen = max(smallest str len, largest str len)
    // Space: O(2*n)

    
    public static class Task61
    {
        public static void FindSmallestAndLargest(string[] input, out HashSet<int> smallest, out HashSet<int> largest)
        {
            smallest = new HashSet<int>();
            largest = new HashSet<int>();
            if (input == null || input.Length == 0) return;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != null)
                {
                    smallest.Add(i);
                    largest.Add(i);
                }
            }

            if (smallest.Count == 0 && largest.Count == 0) return;

            bool minFound = false;
            char? minChar = null;
            bool maxFound = false;

            for (int c = 0; c < int.MaxValue; c++)
            {
                HashSet<int> currentMinIndices = null;
                if (!minFound)
                {
                    currentMinIndices = new HashSet<int>();
                    minChar = null;
                }

                var currentMaxIndices = new HashSet<int>();
                char? maxChar = null;

                for (int i = 0; i < input.Length; i++)
                {
                    if (currentMinIndices != null && smallest.Contains(i))
                    {
                        if (input[i].Length - 1 < c)
                        {
                            if (minChar.HasValue)
                            {
                                currentMinIndices.Clear();
                                minChar = null;
                            }

                            minFound = true;
                            currentMinIndices.Add(i);
                        }

                        if (!minFound)
                        {
                            if (minChar.HasValue)
                            {
                                if (input[i][c] < minChar.Value)
                                {
                                    currentMinIndices.Clear();
                                    minChar = input[i][c];
                                    currentMinIndices.Add(i);
                                }
                                else if (input[i][c] == minChar.Value)
                                {
                                    currentMinIndices.Add(i);
                                }
                            }
                            else
                            {
                                minChar = input[i][c];
                                currentMinIndices.Add(i);
                            }
                        }
                    }

                    if (!maxFound && largest.Contains(i))
                    {
                        if (input[i].Length - 1 >= c)
                        {
                            if (maxChar.HasValue)
                            {
                                if (input[i][c] > maxChar.Value)
                                {
                                    currentMaxIndices.Clear();
                                    maxChar = input[i][c];
                                    currentMaxIndices.Add(i);
                                }
                                else if (input[i][c] == maxChar.Value)
                                {
                                    currentMaxIndices.Add(i);
                                }
                            }
                            else
                            {
                                maxChar = input[i][c];
                                currentMaxIndices.Add(i);
                            }
                        }
                    }
                }

                smallest = currentMinIndices;
                if (currentMaxIndices.Count != 0) largest = currentMaxIndices;

                maxFound = currentMaxIndices.Count < 2;
                if (minFound && maxFound) break;
            }
        }
    }
}