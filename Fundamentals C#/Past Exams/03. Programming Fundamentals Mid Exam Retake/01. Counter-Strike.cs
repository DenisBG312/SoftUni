namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inititalEnergy = int.Parse(Console.ReadLine());
            int winsCount = 0;

            string input = Console.ReadLine();
            while (input != "End of battle")
            {
                int reachEnergy = int.Parse(input);
                if (inititalEnergy < reachEnergy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winsCount} won battles and {inititalEnergy} energy");
                    return;
                }
                inititalEnergy -= reachEnergy;
                winsCount++;

                if (winsCount % 3 == 0)
                {
                    inititalEnergy += winsCount;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {winsCount}. Energy left: {inititalEnergy}");
        }
    }
}
