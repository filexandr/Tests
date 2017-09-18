using System;
using System.Collections.Generic;

namespace Task39
{
    public static class Task39
    {
        // 39.Given an array of size N in which every number is between 1 and N, determine if there are any
        // duplicates in it and what kind.You are allowed to destroy or modify the array if you like.
        // Time: maximum O(3N), 1N is for validation.
        // Space: O(1). List is returned only for testing purposes.
        public static List<int> GetDuplicates(int[] input)
        {
            var result = new List<int>();

            // Validation
            if (input == null || input.Length == 1) return result;

            for (int i = 0; i < input.Length; i++)
            {
                var value = input[i];
                if (value < 1 || value > input.Length)
                {
                    throw new ArgumentException("All values must be in range 1..N", nameof(input));
                }
            }

            // Mark numbers in their locations because every number is between 1 and N.
            // 1..N = original value
            // 0    = empty
            // -X   = X entries
            for (var i = 0; i < input.Length; i++)
            {
                var value = input[i];

                // Reference to itself - start counting
                if (value == i + 1)
                {
                    input[i] = - 1;
                }
                // Reference to another cell - reset the cell and start walking
                else if (value > 0)
                {
                    input[i] = 0;
                    var newPosition = value - 1;
                    while (newPosition >= 0)
                    {
                        value = input[newPosition];

                        // Continue counting
                        if (value < 1)
                        {
                            input[newPosition] += -1;
                            if (input[newPosition] == -2)
                            {
                                result.Add(newPosition + 1);
                            }

                            newPosition = -1;
                        }
                        // We came to position which holds itself - duplicate!
                        else if (value - 1 == newPosition)
                        {
                            input[newPosition] = -2;
                            result.Add(newPosition + 1);
                            newPosition = -1;
                        }
                        // Continue to walk
                        else
                        {
                            input[newPosition] = -1;
                            newPosition = value - 1;
                        }
                    }
                }
            }

            return result;
        }
    }
}