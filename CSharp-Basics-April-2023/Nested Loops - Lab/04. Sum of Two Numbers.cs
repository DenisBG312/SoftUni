using System;

namespace _03._Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            bool flag = false;

            for (int i = start; i <= end; i++)
            {
                if (flag)
                {
                    break;
                }
                for (int j = start; j <= end; j++)
                {
                    counter++;

                    if ((i + j) == magicalNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {(i + j)})");
                        flag = true;
                        break;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicalNumber}");
            }
        }
    }
}
