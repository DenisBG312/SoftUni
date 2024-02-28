namespace ShoppingSpree
{
    public class Program
    {
        static void Main()
        {
            List<Person> people = ReadPeopleList();

            List<Product> products = ReadProductList();

            AddProducts(people, products);

            PrintPeopleListOfProducts(people);
        }

        private static void PrintPeopleListOfProducts(List<Person> people)
        {
            foreach (var person in people)
            {
                if (person.ProductsBought.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.ProductsBought)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        private static void AddProducts(List<Person> people, List<Product> products)
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = commandArgs[0];
                string productName = commandArgs[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);
                person.AddProduct(product);
            }
        }

        private static List<Product> ReadProductList()
        {
            List<Product> products = new();

            string[] productInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (string input in productInput)
            {
                string[] productDetails = input.Split('=', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    products.Add(new Product(productDetails[0], int.Parse(productDetails[1])));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(1);
                }
            }

            return products;
        }

        private static List<Person> ReadPeopleList()
        {
            List<Person> people = new();

            string[] peopleInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (string input in peopleInput)
            {
                string[] personDetails = input.Split('=', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    people.Add(new Person(personDetails[0], int.Parse(personDetails[1])));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(1);
                }
            }

            return people;
        }
    }
}