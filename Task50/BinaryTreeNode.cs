namespace Task50
{
    public class BinaryTreeNode
    {
        private BinaryTreeNode _leftNode;
        private BinaryTreeNode _rightNode;

        public BinaryTreeNode ParentNode { get; set; }
        public int Value { get; set; }

        public BinaryTreeNode LeftNode
        {
            get { return _leftNode; }
            set
            {
                if (_leftNode != null && _leftNode.ParentNode == this)
                {
                    _leftNode.ParentNode = null;
                }

                _leftNode = value;
                if (_leftNode != null)
                {
                    _leftNode.ParentNode = this;
                }
            }
        }

        public BinaryTreeNode RightNode
        {
            get { return _rightNode; }
            set
            {
                if (_rightNode != null && _rightNode.ParentNode == this)
                {
                    _rightNode.ParentNode = null;
                }

                _rightNode = value;
                if (_rightNode != null)
                {
                    _rightNode.ParentNode = this;
                }
            }
        }

        public BinaryTreeNode(BinaryTreeNode parentNode)
        {
            ParentNode = parentNode;
        }

        public override string ToString()
        {
            return $"Parent={ParentNode?.Value}, Value={Value}, Left={LeftNode?.Value}, Right={RightNode?.Value}";
        }
    }
}