namespace Task49
{
    public class Node
    {
        private Node _next;
        private Node _previous;

        public Node Next
        {
            get { return _next; }
            set
            {
                if (_next == value) return;

                if (_next != null && _next.Previous == this)
                {
                    _next._previous = null;
                }

                _next = value;
                if (value != null)
                {
                    value.Previous = this;
                }
            }
        }

        public Node Previous
        {
            get { return _previous; }
            set
            {
                if (_previous == value) return;

                if (_previous != null && _previous.Next == this)
                {
                    _previous._next = null;
                }

                _previous = value;
                if (value != null)
                {
                    value.Next = this;
                }
            }
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}