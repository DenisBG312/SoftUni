namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> productsBought = new();

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> ProductsBought => productsBought.AsReadOnly();

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public void AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
                return;
            }

            Console.WriteLine($"{Name} bought {product.Name}");
            productsBought.Add(product);
            Money -= product.Cost;
        }

    }
}