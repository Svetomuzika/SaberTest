namespace SbaerTest
{
    class LinkedList
    {
        public ListNode Head;
        public ListNode Tail; 
        public int counter;
        public int Count { get { return counter; } }

        public void Add(string data)
        {
            ListNode node = new ListNode() { Data = data };

            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }

            Tail = node;
            counter++;
        }
    }
}