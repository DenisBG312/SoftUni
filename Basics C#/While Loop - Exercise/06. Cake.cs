using System;

namespace _06._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakeLenght = int.Parse(Console.ReadLine());
            int cakeWidth = int.Parse(Console.ReadLine());
            double cakeTotal = cakeLenght * cakeWidth;
            string input = Console.ReadLine();

            while (input != "STOP")
            {
                double peacesToBeGet = double.Parse(input);
                cakeTotal -= peacesToBeGet;
                if (cakeTotal < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(cakeTotal)} pieces more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "STOP")
            {
                Console.WriteLine($"{cakeTotal} pieces are left.");
            }
        }
    }
}
