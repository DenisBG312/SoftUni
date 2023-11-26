using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Product
    {
        public string Item { get; set; }
        public string Date { get; set; }
        public int Calories { get; set; }
        public Product(string item, string date, int calories)
        {
            Item = item;
            Date = date;
            Calories = calories;
        }

        public override string ToString()
        {
            string result = $"Item: {Item}, Best before: {Date}, Nutrition: {Calories}";
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|\|)(?<Item>[A-Za-z\s]+)\1(?<Date>\d{2}/\d{2}/\d{2})\1(?<Calories>\d+)\1";
            string input = Console.ReadLine();

            List<Product> products = new List<Product>();
            int count = 0;
            double totalCalories = 0;
            foreach (Match product in Regex.Matches(input, pattern))
            {
                string item = product.Groups["Item"].Value;
                string date = product.Groups["Date"].Value;
                int calories = int.Parse(product.Groups["Calories"].Value);
                Product productInfo = new Product(item, date, calories);
                products.Add(productInfo);
                count++;
                totalCalories += calories;
            }

            int days = 0;
            while (totalCalories >= 2000)
            {
                days++;
                totalCalories -= 2000;
            }

            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
