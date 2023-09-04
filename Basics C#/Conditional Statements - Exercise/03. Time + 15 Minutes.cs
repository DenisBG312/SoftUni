using System;

namespace _03._Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += hours * 60;
            minutes += 15;

            hours = minutes / 60;
            minutes = minutes % 60;

            bool newDay = hours == 24;

            if (newDay)
            {
                Console.WriteLine($"0:{minutes:D2}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes:D2}");
            }
        }
    }
}
