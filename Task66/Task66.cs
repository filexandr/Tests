using System;

namespace Task66
{
	// 66. Given a binary tree with nodes, print out the values
	// in pre-order/in-order/post-order without using any extra space.
	// Time: O(n)
	// Space: O(n)
	public static class Task66
	{
		public static void PrintPreOrder(BinaryTreeNode node)
		{
			if (node == null)
				return;

			Console.Write ($"{node.Value} ");
			PrintPreOrder (node.LeftNode);
			PrintPreOrder (node.RightNode);
		}

		public static void PrintInOrder(BinaryTreeNode node)
		{
			if (node == null)
				return;

			PrintPreOrder (node.LeftNode);
			Console.Write ($"{node.Value} ");
			PrintPreOrder (node.RightNode);
		}

		public static void PrintPostOrder(BinaryTreeNode node)
		{
			if (node == null)
				return;

			PrintPreOrder (node.LeftNode);
			PrintPreOrder (node.RightNode);
			Console.Write ($"{node.Value} ");
		}
	}
}