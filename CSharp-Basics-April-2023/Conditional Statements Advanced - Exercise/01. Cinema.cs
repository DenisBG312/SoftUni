using System;

namespace _01._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Premiere – премиерна прожекция, на цена 12.00 лева.
            //•	Normal – стандартна прожекция, на цена 7.50 лева.
            //•	Discount – прожекция за деца, ученици и студенти на намалена цена от 5.00 лева.

            string projecType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double cost = 0;
            
            if (projecType == "Premiere")
            {
                cost = 12;
            }
            else if (projecType == "Normal")
            {
                cost = 7.5;
            }
            else if (projecType == "Discount")
            {
                cost = 5;
            }
            double totalPrice = rows * cols * cost;
            Console.WriteLine($"{totalPrice:f2} leva");
        }
    }
}
