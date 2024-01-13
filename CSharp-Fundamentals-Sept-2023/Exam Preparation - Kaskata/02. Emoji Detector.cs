using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Emoji
    {
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string emojiPattern = @"(\:{2}|\*{2})(?<Emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";
            List<string> coolEmojis = new List<string>();

            ulong coolTreshold = 1;
            foreach (Match digit in Regex.Matches(input, digitsPattern))
            {
                coolTreshold *= ulong.Parse(digit.Value);
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            int count = 0;
            foreach (Match emoji in Regex.Matches(input, emojiPattern))
            {
                string currEmoji = emoji.Groups["Emoji"].Value;
                double totalResult = 0;
                count++;
                foreach (char character in currEmoji)
                {
                    totalResult += character;
                }

                if (totalResult < coolTreshold)
                {
                    continue;
                }

                coolEmojis.Add(emoji.Value);
            }

            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
            foreach (string coolEmoji in coolEmojis)
            {
                Console.WriteLine(coolEmoji);
            }
        }
    }
}
