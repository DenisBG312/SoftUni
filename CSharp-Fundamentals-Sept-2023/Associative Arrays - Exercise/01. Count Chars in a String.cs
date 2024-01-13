namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> charsInts = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == ' ')
                {
                    continue;
                }

                if (!charsInts.ContainsKey(currentChar))
                {
                    charsInts.Add(currentChar, 0);
                }

                charsInts[currentChar]++;
            }

            foreach (KeyValuePair<char, int> kvp in charsInts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
