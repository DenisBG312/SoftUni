using System;

namespace GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodGr = double.Parse(Console.ReadLine()) * 1000;
            double hayGr = double.Parse(Console.ReadLine()) * 1000;
            double coverGr = double.Parse(Console.ReadLine()) * 1000;
            double weightGr = double.Parse(Console.ReadLine()) * 1000;

            for (int i = 1; i <= 30; i++)
            {
                foodGr -= 300;
                if (i % 2 == 0)
                {
                    double hayToBeExtr = foodGr * 0.05;
                    hayGr -= hayToBeExtr;
                }
                if (i % 3 == 0)
                {
                    double coverToBeExtr = weightGr / 3;
                    coverGr -= coverToBeExtr;
                }
                if (foodGr < 0 || hayGr < 0 || coverGr < 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodGr / 1000:f2}, Hay: {hayGr / 1000:f2}, Cover: {coverGr / 1000:f2}.");
        }
    }
}
