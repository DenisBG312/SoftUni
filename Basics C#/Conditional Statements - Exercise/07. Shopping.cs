using System;

namespace _07._Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Видеокарта – 250 лв./ бр.
            //•	Процесор – 35 % от цената на закупените видеокарти/ бр.
            //•	Рам памет – 10 % от цената на закупените видеокарти/ бр.

            double peterBudget = double.Parse(Console.ReadLine());
            int videocards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double videocardsSum = videocards * 250;
            double processorsSum = (videocardsSum * 0.35) * processors;
            double ramSum = (videocardsSum * 0.1) * ram;
            double totalPrice = videocardsSum + processorsSum + ramSum;
            if (videocards > processors)
            {
                totalPrice *= 0.85;
            }
            if (peterBudget >= totalPrice)
            {
                Console.WriteLine($"You have {peterBudget - totalPrice:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - peterBudget:f2} leva more!");
            }

        }
    }
}
