using System;

namespace _09._Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //	"room for one person" – 18.00 лв за нощувка
            //	"apartment" – 25.00 лв за нощувка
            //	"president apartment" – 35.00 лв за нощувка
          
            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string review = Console.ReadLine();
            double totalPrice = 0;

            double daysUse = days - 1;
            if (typeRoom == "room for one person")
            {
                totalPrice = daysUse * 18;
            }
            else if (typeRoom == "apartment")
            {
                totalPrice = daysUse * 25;
                if (daysUse < 10)
                {
                    totalPrice *= 0.7;
                }
                else if (daysUse >= 10 && daysUse <= 15)
                {
                    totalPrice *= 0.65;
                }
                else
                {
                    totalPrice *= 0.5;
                }
            }
            else if (typeRoom == "president apartment")
            {
                totalPrice = daysUse * 35;
                if (daysUse < 10)
                {
                    totalPrice *= 0.9;
                }
                else if (daysUse >= 10 && daysUse <= 15)
                {
                    totalPrice *= 0.85;
                }
                else
                {
                    totalPrice *= 0.8;
                }
            }
            if (review == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.1;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
