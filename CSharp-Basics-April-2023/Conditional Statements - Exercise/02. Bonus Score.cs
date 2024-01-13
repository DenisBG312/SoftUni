using System;

namespace _02._Bonus_Score
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double beginScore = double.Parse(Console.ReadLine());
            double bonus = 0;

            if (beginScore <= 100)
            {
                bonus += 5;
            }
            else if (beginScore > 100 && beginScore <= 1000)
            {
                bonus = beginScore * 0.2;
            }
            else
            {
                bonus = beginScore * 0.1;
            }
            if (beginScore % 2 == 0)
            {
                bonus += 1;
            }
            if (beginScore % 10 == 5)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(beginScore + bonus);
        }
    }
}
