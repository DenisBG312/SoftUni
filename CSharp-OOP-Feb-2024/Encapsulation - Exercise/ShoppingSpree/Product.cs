namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private int cost;

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

        public int Cost
        {
            get => cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}