namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> kvp = new SortedDictionary<char, int>();

            foreach (char c in input)
            {
                if (!kvp.ContainsKey(c))
                {
                    kvp.Add(c, 1);
                }
                else
                {
                    kvp[c]++;
                }
            }

            foreach (var occurence in kvp)
            {
                Console.WriteLine($"{occurence.Key}: {occurence.Value} time/s");
            }
        }
    }
}
