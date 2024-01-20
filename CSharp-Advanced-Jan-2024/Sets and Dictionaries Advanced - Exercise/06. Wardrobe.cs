namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split(" -> ");
                string color = arguments[0];
                string[] clothes = arguments[1].Split(",");
                foreach (var clothe in clothes)
                {
                    if (!wardrobes.ContainsKey(color))
                    {
                        wardrobes.Add(color, new Dictionary<string, int>());
                    }

                    if (!wardrobes[color].ContainsKey(clothe))
                    {
                        wardrobes[color].Add(clothe, 0);
                    }

                    wardrobes[color][clothe]++;
                }
            }

            string[] searchedClothe = Console.ReadLine().Split();

            foreach (var wardrobe in wardrobes)
            {
                Console.WriteLine($"{wardrobe.Key} clothes:");
                foreach (var clothe in wardrobe.Value)
                {
                    Console.Write($"* {clothe.Key} - {clothe.Value}");
                    if (wardrobe.Key == searchedClothe[0] && clothe.Key == searchedClothe[1])
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
