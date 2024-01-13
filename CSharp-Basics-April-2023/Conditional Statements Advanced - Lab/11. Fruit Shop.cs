using System;

namespace _11._Fruit_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double cost = 0;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                switch (fruit)
                {
                    case "banana":
                        cost = 2.5;
                        break;
                    case "apple":
                        cost = 1.2;
                        break;
                    case "orange":
                        cost = 0.85;
                        break;
                    case "grapefruit":
                        cost = 1.45;
                        break;
                    case "kiwi":
                        cost = 2.7;
                        break;
                    case "pineapple":
                        cost = 5.5;
                        break;
                    case "grapes":
                        cost = 3.85;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        cost = 2.7;
                        break;
                    case "apple":
                        cost = 1.25;
                        break;
                    case "orange":
                        cost = 0.9;
                        break;
                    case "grapefruit":
                        cost = 1.6;
                        break;
                    case "kiwi":
                        cost = 3;
                        break;
                    case "pineapple":
                        cost = 5.6;
                        break;
                    case "grapes":
                        cost = 4.2;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana" || fruit == "apple" || fruit == "orange" || fruit == "grapefruit" || fruit == "kiwi" || fruit == "pineapple" || fruit == "grapes")
                {
                    double totalPrice = quantity * cost;
                    Console.WriteLine($"{totalPrice:f2}");
                }
            }
        }
    }
}
