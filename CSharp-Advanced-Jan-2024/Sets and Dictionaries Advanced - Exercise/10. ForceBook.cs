namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputParts = input.Split(new[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains("|"))
                {
                    string forceSide = inputParts[0];
                    string forceUser = inputParts[1];

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());
                    }

                    if (!forceBook.Values.Any(list => list.Contains(forceUser)))
                    {
                        forceBook[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string forceUser = inputParts[0];
                    string forceSide = inputParts[1];

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());
                    }

                    if (forceBook.Values.Any(list => list.Contains(forceUser)))
                    {
                        foreach (var side in forceBook)
                        {
                            if (side.Value.Contains(forceUser))
                            {
                                side.Value.Remove(forceUser);
                                break;
                            }
                        }

                        forceBook[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else
                    {
                        forceBook[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }

            foreach (var (forceSide, forceUsers) in forceBook
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"Side: {forceSide}, Members: {forceUsers.Count}");
                foreach (var forceUser in forceUsers.OrderBy(x => x))
                {
                    Console.WriteLine($"! {forceUser}");
                }
            }

        }
    }
}
