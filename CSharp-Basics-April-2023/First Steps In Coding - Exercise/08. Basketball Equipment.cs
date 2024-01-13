using System;

namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Четем таксата за една година
            int taxPerYear = int.Parse(Console.ReadLine());

            // Намираме цената на всяка част от екипировката

            //•	Баскетболни кецове – 40 % по - малка от таксата за една година
            double shoes = taxPerYear - taxPerYear * 0.4;
            //•	Баскетболен екип – 20 % по - евтина от тази на кецовете
            double outfit = shoes - shoes * 0.2;
            //•	Баскетболна топка – 1 / 4 от цената на баскетболния екип
            double ball = outfit / 4;
            //•	Баскетболни аксесоари – 1 / 5 от цената на баскетболната топка
            double acc = ball / 5;
            // Намираме общата сума
            double sum = taxPerYear + shoes + outfit + ball + acc;
            //Отпечатваме общата сума
            Console.WriteLine(sum);
        }
    }
}
