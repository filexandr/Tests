using System;

namespace OnlineTask2
{
    // Given a sorted(increasing order) array, write a program to create a binary tree with minimal height.
    // Time: O(n)
    // Space: O(n)
    public class BinaryTree
    {
        public Node Head;

        public static BinaryTree Create(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                throw new ArgumentException("Input array is null or empty");
            }

            var result = new BinaryTree
            {
                Head = FullfillNode(input, 0, input.Length - 1)
            };

            return result;
        }

        private static Node FullfillNode(int[] input, int fromIndex, int toIndex)
        {
            if (fromIndex > toIndex)
            {
                return null;
            }

            if (fromIndex == toIndex)
            {
                return new Node { Value = input[fromIndex]};
            }

            var len = toIndex - fromIndex + 1;
            var middleIndex = fromIndex + len / 2;
            var result = new Node
            {
                Value = input[middleIndex],
                Left = FullfillNode(input, fromIndex, middleIndex - 1),
                Right = FullfillNode(input, middleIndex + 1, toIndex)
            };

            return result;
        }
    }
}