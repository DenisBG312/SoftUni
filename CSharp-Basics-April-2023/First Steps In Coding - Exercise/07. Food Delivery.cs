using System;

namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veganMenu = int.Parse(Console.ReadLine());

            double chickenPrice = chickenMenu * 10.35;
            double fishPrice = fishMenu * 12.40;
            double veganPrice = veganMenu * 8.15;
            double dessert = (chickenPrice + fishPrice + veganPrice) * 0.2;

            double sum = ((chickenPrice + fishPrice + veganPrice + dessert) + 2.5);
            Console.WriteLine(sum);
        }
    }
}
