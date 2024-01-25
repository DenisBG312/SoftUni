namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> countUpperWords = 
                s => s[0] == s.ToUpper()[0];

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => countUpperWords(x))
                .ToArray();

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
