namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    names.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string> peopleToDouble = names.FindAll(GetPredicate(filter, value));

                    foreach (string person in peopleToDouble)
                    {
                        int index = names.FindIndex(p => p == person);
                        names.Insert(index, person);
                    }
                }
            }

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            static Predicate<string> GetPredicate(string filter, string value)
            {
                switch (filter)
                {
                    case "StartsWith":
                        return n => n.StartsWith(value);
                        break;
                    case "EndsWith":
                        return n => n.EndsWith(value);
                        break;
                    case "Length":
                        return n => n.Length == int.Parse(value);
                        break;

                    default:
                        return default;
                }
            }
        }
    }
}
