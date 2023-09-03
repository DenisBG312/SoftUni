using System;

namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositedSum = double.Parse(Console.ReadLine());
            int monthDeposit = int.Parse(Console.ReadLine());
            double yearlyPercentage = double.Parse(Console.ReadLine());
            double sum = depositedSum + monthDeposit * ((depositedSum * (yearlyPercentage/100)) / 12);
            Console.WriteLine(sum);
        }
    }
}
