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
                if (tokens.Length == 5)
                {
                    all.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (tokens.Length == 3)
                {
                    if (tokens[0].StartsWith("Pet"))
                    {
                        all.Add(new Pet(tokens[1], tokens[2]));
                    }
                }
            }

            string yearToGet = Console.ReadLine();

            foreach (var identifiable in all
                         .Where(y => y.Birthdate.EndsWith(yearToGet))
                         .Select(y => y.Birthdate))
            {
                Console.WriteLine(identifiable);
            }

        }
    }
}
