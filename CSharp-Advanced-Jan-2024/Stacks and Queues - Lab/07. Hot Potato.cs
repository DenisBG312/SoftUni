namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split());
            int countThrow = int.Parse(Console.ReadLine());
            int count = 0;

            while (queue.Count > 1)
            {
                count++;
                string child = queue.Dequeue();
                if (count == countThrow)
                {
                    Console.WriteLine($"Removed {child}");
                    count = 0;
                }
                else
                {
                    queue.Enqueue(child);
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
