namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ")
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                if (!counts.ContainsKey(currentWord))
                {
                    counts.Add(currentWord, 1);
                }

                counts[currentWord]++;  
            }

            foreach (KeyValuePair<string, int> word in counts)
            {
                if (word.Value % 2 == 0)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}
