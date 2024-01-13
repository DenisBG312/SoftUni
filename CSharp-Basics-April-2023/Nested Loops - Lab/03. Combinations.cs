using System;

namespace _03._Combinations1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double valid = 0;
            for (int i = 0; i <= num; i++)
            {
                for (int j = 0; j <= num; j++)
                {
                    for(int k = 0; k <= num; k++)
                    {
                        if (i + j + k == num)
                        {
                            valid++;
                        }
                    }
                }
            }
            Console.WriteLine(valid);
        }
    }
}
