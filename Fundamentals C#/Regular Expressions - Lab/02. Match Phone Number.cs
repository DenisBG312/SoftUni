using System.Text.RegularExpressions;

/*
 +359 2 222 2222,359-2-222-2222, +359/2/222/2222, +359-2 222 2222 +359 2-222-2222, +359-2-222-222 +359-2-222-22222 +359-2-222-2222
 */

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phoneNumber = Console.ReadLine();
            string pattern = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b";

            MatchCollection phones = Regex.Matches(phoneNumber, pattern);
            List<string> phoneNumbers = new List<string>();

            foreach (Match number in phones)
            {
                phoneNumbers.Add(number.ToString());
            }

            Console.WriteLine(string.Join(", ", phoneNumbers));
        }
    }
}
