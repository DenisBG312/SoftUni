using System.Text.RegularExpressions;

/*
Bethany Taylor, Oliver miller, sophia Johnson, SARah Wilson, John Smith, Sam Smith
*/

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]{1,}\b \b[A-Z][a-z]{1,}\b";

            MatchCollection matchedNames = Regex.Matches(input, pattern);

            foreach (Match match in matchedNames)
            {
                Console.Write($"{match} ");
            }

            Console.WriteLine();
        }
    }
}
