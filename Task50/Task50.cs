using System;
using System.Collections.Generic;

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

        #region Recursion

        public static int DepthRecursion(BinaryTreeNode node)
        {
            int depth = 0;
            int steps = 0;
            DepthRecursionVisit(node, ref steps, ref depth);
            return depth;
        }

        private static void DepthRecursionVisit(BinaryTreeNode node, ref int steps, ref int depth)
        {
            if (node == null) return;

            steps++;
            depth = Math.Max(steps, depth);
            DepthRecursionVisit(node.LeftNode, ref steps, ref depth);
            DepthRecursionVisit(node.RightNode, ref steps, ref depth);
            steps--;
        }

        #endregion

        #region Iterative

        public static int DepthIterative(BinaryTreeNode node)
        {
            int depth = 0;

            var stack = new Stack<Tuple<int, BinaryTreeNode>>();
            var stackNode = node;
            int? stackLevel = 1;

            while (stackNode != null)
            {
                depth = Math.Max(stackLevel.Value, depth);

                if (stackNode.LeftNode != null)
                {
                    stack.Push(new Tuple<int, BinaryTreeNode>(stackLevel.Value + 1, stackNode.LeftNode));
                }

                if (stackNode.RightNode != null)
                {
                    stack.Push(new Tuple<int, BinaryTreeNode>(stackLevel.Value + 1, stackNode.RightNode));
                }

                var stackObject = stack.Count > 0 ? stack.Pop() : null;
                stackLevel = stackObject?.Item1;
                stackNode = stackObject?.Item2;
            }

            return depth;
        }

        #endregion
    }
}