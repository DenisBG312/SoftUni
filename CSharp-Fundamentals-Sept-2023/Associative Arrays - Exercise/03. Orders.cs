namespace _03._Orders
{

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Update(double price, int quantity)
        {
            Price = price;
            Quantity += quantity;
        }

        public double GetTotal()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return $"{Name} -> {GetTotal():f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] tokens = input.Split();
                string name = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                Product product = new Product(name, price, quantity);
                if (!products.ContainsKey(name))
                {
                    products.Add(product.Name, product);
                }
                else
                {
                    products[name].Update(product.Price, product.Quantity);
                }
            }

            foreach (KeyValuePair<string, Product> kvp in products)
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }
}
