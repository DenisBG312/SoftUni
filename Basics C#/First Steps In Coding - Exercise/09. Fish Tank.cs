using System;

namespace _09._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            
            int totalAquariumSpace = lenght * width * height;
            double litres = totalAquariumSpace * 0.001;
            double percentageTotal = percentage / 100;

            double totalLitresWater = litres * (1 - percentageTotal);
            Console.WriteLine(totalLitresWater);
        }
    }
}
