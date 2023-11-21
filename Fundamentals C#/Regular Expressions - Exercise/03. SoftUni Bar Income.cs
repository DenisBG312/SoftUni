using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Bar
    {
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Bar(string customerName, string product, int quantity, decimal price)
        {
            CustomerName = customerName;
            Product = product;
            Quantity = quantity;
            Price = price;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<Name>[A-Z][a-z]+)\%.*\<(?<Product>\w+)\>.*\|(?<Quantity>\d+)\|.*?(?<Price>\d+(\.\d+)?)\$";

            List<Bar> bars = new List<Bar>();
            decimal totalprice = 0;
            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                foreach (Match item in Regex.Matches(input, pattern))
                {
                    string customerName = item.Groups["Name"].Value;
                    string product = item.Groups["Product"].Value;
                    int quantity = int.Parse(item.Groups["Quantity"].Value);
                    decimal price = decimal.Parse(item.Groups["Price"].Value);
                    Bar bar = new Bar(customerName, product, quantity, price);
                    bars.Add(bar);
                    decimal totalProductPrice = bar.Price * bar.Quantity;
                    Console.WriteLine($"{customerName}: {product} - {totalProductPrice:f2}");
                    totalprice += totalProductPrice;
                }
            }

            Console.WriteLine($"Total income: {totalprice:f2}");
        }
    }
}
