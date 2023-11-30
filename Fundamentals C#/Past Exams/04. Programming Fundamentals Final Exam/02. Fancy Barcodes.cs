using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        class Product
        {
            public string Name { get; set; }
            public string Digits { get; set; }

            public Product(string name, string digits)
            {
                Name = name;
                Digits = digits;
            }
        }
        static void Main(string[] args)
        {
            string pattern = @"(@#+)(?<Product>[A-Z]{1,}[A-Za-z-0-9]{4,}[A-Z]{1,})(@#+)";
            List<Product> validProducts = new List<Product>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Match match = Regex.Match(barcode, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string digits = new string (barcode.Where(x => char.IsDigit(x)).ToArray());
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
