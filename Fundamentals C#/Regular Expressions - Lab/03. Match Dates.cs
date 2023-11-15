using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    /*Day: 03, Month: Mar, Year: 1878*/
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";

            MatchCollection regex = Regex.Matches(input, pattern);

            foreach (Match date in regex)
            {
                var day = date.Groups["day"];
                var month = date.Groups["month"];
                var year = date.Groups["year"];

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}
