namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = rackCapacity;
            int racks = 0;

            Stack<int> boxes = new Stack<int>(clothesInBox);

            if (boxes.Any())
            {
                racks++;
            }

            while (boxes.Count > 0)
            {
                if (boxes.Peek() <= currentRackCapacity)
                {
                    currentRackCapacity -= boxes.Pop();
                }
                else
                {
                    racks++;
                    currentRackCapacity = rackCapacity;
                }
            }

            Console.WriteLine(racks);
        }

    }
}
