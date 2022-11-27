namespace SbaerTest
{
    class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int counter;

        public void Serialize(FileStream s)
        {
            List<ListNode> doublyList = new List<ListNode>();
            ListNode node = Head;

            do
            {
                doublyList.Add(node);
                node = node.Next;
            } 
            while (node != null);

            using (BinaryWriter writer = new BinaryWriter(s))
            {
                foreach (ListNode e in doublyList)
                {
                    Console.WriteLine(e.Data + "  ---  " + e.Rand.Data);

                    writer.Write(e.Data);
                    writer.Write(doublyList.IndexOf(e.Rand));
                }              
            }

            Console.WriteLine("List serialized");
        }

        public void Deserialize(FileStream s)
        {
            List<ListNode> doublyList = new List<ListNode>();
            ListNode node = new ListNode();
            List<int> indexOfRand = new List<int>();

            counter = 0;
            Head = node;

            try
            {
                using (BinaryReader reader = new BinaryReader(s))
                {
                    while (reader.PeekChar() > -1)
                    {
                        node.Data = reader.ReadString();
                        indexOfRand.Add(reader.ReadInt32());

                        ListNode next = new ListNode();
                        node.Next = next;
                        next.Prev = node;

                        doublyList.Add(node);
                        node = next;

                        counter++;
                    }
                }

                Tail = node.Prev;

                for (int i = 0; i < counter; i++)
                {
                    doublyList[i].Rand = doublyList[indexOfRand[i]];
                    Console.WriteLine(doublyList[i].Data + "  ---  " + doublyList[i].Rand.Data);
                }

                Console.WriteLine("List deserialized");
            }
            catch
            {
                Console.WriteLine("Deserialize failure");
            }
        }
    }
}