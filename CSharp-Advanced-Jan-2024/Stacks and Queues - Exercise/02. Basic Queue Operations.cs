namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numbersQueue = new Queue<int>();

            for (int i = 0; i < firstLine[0]; i++)
            {
                numbersQueue.Enqueue(secondLine[i]);
            }

            for (int i = 0; i < firstLine[1]; i++)
            {
                numbersQueue.Dequeue();
            }

            if (numbersQueue.Contains(firstLine[2]))
            {
                Console.WriteLine("true");
            }
            else if (numbersQueue.Count != 0)
            {
                Console.WriteLine(numbersQueue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
