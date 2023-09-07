using System;

namespace _07._Moving.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double total = lenght * width * height;
            string input = Console.ReadLine();
            double totalCartons = 0;

            while (input != "Done")
            {
                double carton = double.Parse(input);
                totalCartons += carton;
                if (totalCartons >= total)
                {
                    Console.WriteLine($"No more free space! You need {totalCartons - total} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Done")
            {
                Console.WriteLine($"{total - totalCartons} Cubic meters left.");
            }
            
        }
    }
}
