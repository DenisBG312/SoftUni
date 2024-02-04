namespace _01.CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
 

            list[0] = 234;


            Console.WriteLine(list[0]);

            list.AddRange(new int[] {1, 2, 3, 6, 2});

            Console.WriteLine(list.RemoveAt(2));
            Console.WriteLine(list.RemoveAt(2));
            Console.WriteLine(list.RemoveAt(2));


            list.InsertAt(2, -5);

            Console.WriteLine(list.Contains(234));
            Console.WriteLine(list.Contains(100));

            list.InsertAt(0, -5);

            list.Swap(0, 1);

            Console.WriteLine(list.Count);
        }
    }
}
