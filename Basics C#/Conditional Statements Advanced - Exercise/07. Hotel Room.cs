using System;

namespace _07._Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apartamentPrice = 0;
            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartamentPrice = 65;
                    break;
                case "June":
                case "September":
                    studioPrice = 75.2;
                    apartamentPrice = 68.7;
                    break;
                case "July":
                case "August":
                    studioPrice = 76;
                    apartamentPrice = 77;
                    break;
            }
            if (month == "May" && days > 14 || month == "October" && days > 14)
            {
                studioPrice *= 0.7;
            }
            else if (month == "May" && days > 7 || month == "October" && days > 7)
            {
                studioPrice *= 0.95;
            }
            else if (month == "June" && days > 14 || month == "September" && days > 14)
            {
                studioPrice *= 0.8;
            }
            if (days > 14)
            {
                apartamentPrice *= 0.9;
            }
            Console.WriteLine($"Apartment: {apartamentPrice * days:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice * days:f2} lv.");
        }
    }
}
