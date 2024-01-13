using System;

namespace _03._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double totalNum = 0;

            while (totalNum < num)
            {
                int inputNum = int.Parse(Console.ReadLine());
                totalNum += inputNum;
            }
            Console.WriteLine(totalNum);
        }
    }
}
