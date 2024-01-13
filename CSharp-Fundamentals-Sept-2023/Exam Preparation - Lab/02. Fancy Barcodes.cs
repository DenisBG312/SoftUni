using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //@#+(?<Barcode>[A-Z][A-Za-z-0-9]+[A-Z])@#+
            
            int count = int.Parse(Console.ReadLine());
            string pattern = @"@#+(?<Barcode>[A-Z]{1,}[A-Za-z-0-9]{4,}[A-Z]{1,})@#+";

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string barcode = match.Groups[1].Value;
                    string digits = new string(barcode.Where(x => char.IsDigit(x)).ToArray());
                    if (digits.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {digits}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
