namespace SbaerTest
{
    class Program
    {
        static Random rand = new Random();
        static LinkedList linkedList = new LinkedList();

        static ListNode Head;
        static ListNode Tail;
        static ListNode Node;
        static int Count;

        static ListNode RandomNode()
        {
            ListNode current = Head;
            int randomIndex = rand.Next(0, Count);
            int counter = 0;

            while (current != null)
            {
                if (counter == randomIndex)
                    break;

                current = current.Next;
                counter++;
            }

            return current;
        }

        static void Main()
        {
            ListRand serializeList = new ListRand();
            ListRand deserializeList = new ListRand();
            FileStream stream;

            linkedList.Add("Bob");
            linkedList.Add("Bill");
            linkedList.Add("Tom");
            linkedList.Add("Kate");

            Head = linkedList.Head;
            Tail = linkedList.Tail;
            Count = linkedList.Count;
            Node = Head;

            for (int i = 0; i < Count; i++)
            {
                Node.Rand = RandomNode();
                Node = Node.Next;
            }

            serializeList.Head = Head;
            serializeList.Tail = Tail;

            stream = new FileStream("file.txt", FileMode.OpenOrCreate);
            serializeList.Serialize(stream);

            stream = new FileStream("file.txt", FileMode.Open);
            deserializeList.Deserialize(stream);
        }
    }
}