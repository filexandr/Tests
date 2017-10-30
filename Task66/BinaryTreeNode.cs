using System;

namespace Task66
{
    [Serializable]
	public class BinaryTreeNode
	{
		public BinaryTreeNode LeftNode;

		public BinaryTreeNode RightNode;

		public int Value;

	    public BinaryTreeNode(int value)
	    {
	        Value = value;
	    }

        public BinaryTreeNode CreateLeftNode(int value)
		{
			return LeftNode = new BinaryTreeNode (value);
		}

		public BinaryTreeNode CreateRightNode(int value)
		{
			return RightNode = new BinaryTreeNode(value);
        }
	}
}