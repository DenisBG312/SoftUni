using System.Text.RegularExpressions;

namespace _02._Destination_Mapper_
{
    class Town
    {
        public string Name { get; set; }

        public Town(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(=|\/)(?<Town>[A-Z][A-Za-z]{2,})\1";

            List<Town> validTowns = new List<Town>();

            double travelPoints = 0;
            foreach (Match town in Regex.Matches(input, pattern))
            {
                string name = town.Groups["Town"].Value;
                Town validTown = new Town(name);
                validTowns.Add(validTown);
                travelPoints += name.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", validTowns)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
