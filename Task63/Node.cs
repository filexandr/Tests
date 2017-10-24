namespace Task63
{
    public class Node
    {
        public Node Next;
        public int Value;

        public Node(int value)
        {
            Value = value;
        }

        public Node CreateNext(int value)
        {
            return Next = new Node(value);
        }
    }
}