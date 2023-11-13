using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"([=\/])([A-Z][a-zA-Z]{2,})\1";
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(input);

        var validDestinations = matches
            .Select(match => match.Groups[2].Value)
            .ToList();

        int travelPoints = validDestinations.Sum(destination => destination.Length);

        Console.WriteLine($"Destinations: {string.Join(", ", validDestinations)}");
        Console.WriteLine($"Travel Points: {travelPoints}");
    }
}
