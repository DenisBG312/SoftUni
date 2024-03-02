namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> all = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                if (tokens.Length == 3)
                {
                    all.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 2)
                {
                    all.Add(new Robot(tokens[0], tokens[1]));
                }
            }

            string lastFakeDigits = Console.ReadLine();

            foreach (var name in all.Where
                             (c => c.Id.EndsWith(lastFakeDigits))
                            .Select(c => c.Id)
                            .ToList())
            {
                Console.WriteLine(name);
            }
        }
    }
}
