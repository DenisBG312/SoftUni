using System;

namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int litres = int.Parse(Console.ReadLine());
            int percentageDiscount = int.Parse(Console.ReadLine());
            double packetPens = pens * 5.80;
            double packetMarkers = markers * 7.20;
            double totalLitres = litres * 1.20;
            double discountNumber = percentageDiscount * 0.01;
            double sum = packetPens + packetMarkers + totalLitres;
            double sumDiscount = sum - (sum * discountNumber);
            Console.WriteLine(sumDiscount);
            
        }
    }
}
