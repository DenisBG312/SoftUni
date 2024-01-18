namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, Dictionary<string, double>> kvp = new Dictionary<string, Dictionary<string, double>>();
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] splitted = input.Split(", ");
                string shop = splitted[0];
                string product = splitted[1];
                double price = double.Parse(splitted[2]);

                if (!kvp.ContainsKey(shop))
                {
                    kvp.Add(shop, new Dictionary<string, double>());
                }

                if (!kvp[shop].ContainsKey(product))
                {
                    kvp[shop].Add(product, 0);
                }

                kvp[shop][product] = price;
            }

            kvp = kvp.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
            foreach (var (store, products) in kvp)
            {
                Console.WriteLine($"{store}->");

                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
