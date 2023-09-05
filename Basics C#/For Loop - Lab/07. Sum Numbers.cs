using System;

namespace _07._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double total = 0;
            for (int i = 0; i < num; i++)
            {
                int n = int.Parse(Console.ReadLine());
                total += n;
            }
            Console.WriteLine(total);
        }
    }
}
