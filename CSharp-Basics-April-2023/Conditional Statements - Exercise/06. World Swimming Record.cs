using System;

namespace _06._World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double lenghtMetres = double.Parse(Console.ReadLine());
            double timeSwimming = double.Parse(Console.ReadLine());
            
            double needToSwim = lenghtMetres * timeSwimming;
            double newTime = Math.Floor(lenghtMetres / 15) * 12.5;
            double totalTime = needToSwim + newTime;
            if (recordInSeconds <= totalTime)
            {
                Console.WriteLine($"No, he failed! He was {totalTime - recordInSeconds:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
        }
    }
}
