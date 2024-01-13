using System;
using System.Xml.Schema;

namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalTickets = 0;
            double totalTotalTicks = 0;
            double student = 0;
            double standard = 0;
            double kid = 0;

            while (input != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                double getSeat = 0;
                while (freeSeats > getSeat)
                {
                    string type = Console.ReadLine();
                    if (type == "End")
                    {
                        break;
                    }
                    if (type == "student")
                    {
                        student++;
                        getSeat++;
                    }
                    else if (type == "standard")
                    {
                        standard++;
                        getSeat++;
                    }
                    else
                    {
                        kid++;
                        getSeat++;
                    }
                    totalTickets = getSeat;
                }
                totalTotalTicks += totalTickets;
                if (getSeat <= freeSeats)
                {
                    Console.WriteLine($"{input} - {getSeat / freeSeats * 100:f2}% full.");
                }
                input = Console.ReadLine();
            }
            if (input == "Finish")
            {
                Console.WriteLine($"Total tickets: {totalTotalTicks}");
                Console.WriteLine($"{student / totalTotalTicks * 100:f2}% student tickets.");
                Console.WriteLine($"{standard / totalTotalTicks * 100:f2}% standard tickets.");
                Console.WriteLine($"{kid / totalTotalTicks * 100:f2}% kids tickets.");
            }
        }
    }
}
