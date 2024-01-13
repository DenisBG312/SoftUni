using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int numInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numInputs; i++)
        {
            string input = Console.ReadLine();

            string pattern = @"^(\$|%)(?<Tag>[A-Z][a-z]{2,})\1:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string tag = match.Groups["Tag"].Value;
                int num1 = int.Parse(match.Groups[2].Value);
                int num2 = int.Parse(match.Groups[3].Value);
                int num3 = int.Parse(match.Groups[4].Value);

                string decryptedMessage = $"{(char)num1}{(char)num2}{(char)num3}";

                Console.WriteLine($"{tag}: {decryptedMessage}");
            }
            else
            {
                Console.WriteLine("Valid message not found!");
            }
        }
    }
}
