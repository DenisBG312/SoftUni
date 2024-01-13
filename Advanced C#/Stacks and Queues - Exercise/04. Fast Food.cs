namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] quantityOfOrder = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(quantityOfOrder);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (quantityFood >= queue.Peek())
                {
                    quantityFood -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
