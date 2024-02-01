namespace Custom_Doubly_Linked_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddFirst(0);
            linkedList.AddFirst(-1);

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            linkedList.ForEach(n =>
            {
                Console.WriteLine(n);
            });

            int[] array = linkedList.ToArray();

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
