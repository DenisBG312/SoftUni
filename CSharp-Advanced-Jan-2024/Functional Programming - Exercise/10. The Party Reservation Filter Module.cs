namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                }
                else
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (var filter in filters)
            {
                names.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", names));

            static Predicate<string> GetPredicate(string filter, string value)
            {
                switch (filter)
                {
                    case "Starts with":
                        return n => n.StartsWith(value);
                        break;
                    case "Ends with":
                        return n => n.EndsWith(value);
                        break;
                    case "Length":
                        return n => n.Length == int.Parse(value);
                        break;
                    case "Contains":
                        return n => n.Contains(value);
                    default:
                        return default;
                }
            }
        }
    }
}
