namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> words = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words[word] = synonym;
                }
                else
                {
                    words[word] += ", " + synonym; 
                }
            }

            foreach (KeyValuePair<string, string> word in words)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
