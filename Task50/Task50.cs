using System;

namespace Task50
{
    // 50.Write a function to find the depth of a binary tree.
    // Time: O(N)
    // Space: O(N)
    public class Task50
    {
        public static BinaryTreeNode Create(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException(nameof(inputArray));
            }

            return FillNode(null, inputArray, 0, inputArray.Length - 1);
        }

        private static BinaryTreeNode FillNode(BinaryTreeNode parentNode, int[] inputArray, int indexFrom, int indexTo)
        {
            if (indexTo < indexFrom) return null;

            var middle = indexFrom;
            if (indexTo - indexFrom > 1)
            {
                middle = indexFrom + (indexTo - indexFrom) / 2;
            }

            var result = new BinaryTreeNode(parentNode)
            {
                Value = inputArray[middle]
            };

            result.LeftNode = FillNode(result, inputArray, indexFrom, middle - 1);
            result.RightNode = FillNode(result, inputArray, middle + 1, indexTo);
            return result;
        }

        public static int Depth(BinaryTreeNode node)
        {
            int depth = 0;
            int steps = 0;
            DepthVisit(node, ref steps, ref depth);
            return depth;
        }

        private static void DepthVisit(BinaryTreeNode node, ref int steps, ref int depth)
        {
            if (node == null) return;

            steps++;
            depth = Math.Max(steps, depth);
            DepthVisit(node.LeftNode, ref steps, ref depth);
            DepthVisit(node.RightNode, ref steps, ref depth);
            steps--;
        }
    }
}