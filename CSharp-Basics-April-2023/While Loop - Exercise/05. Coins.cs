using System;

namespace _05._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double changeToReturn = double.Parse(Console.ReadLine()) * 100;
            int count = 0;

            while (changeToReturn > 0)
            {
                if (changeToReturn >= 200)
                {
                    changeToReturn -= 200;
                }
                else if (changeToReturn >= 100)
                {
                    changeToReturn -= 100;
                }
                else if (changeToReturn >= 50)
                {
                    changeToReturn -= 50;
                }
                else if (changeToReturn >= 20)
                {
                    changeToReturn -= 20;
                }
                else if (changeToReturn >= 10)
                {
                    changeToReturn -= 10;
                }
                else if (changeToReturn >= 5)
                {
                    changeToReturn -= 5;
                }
                else if (changeToReturn >= 2)
                {
                    changeToReturn -= 2;
                }
                else if (changeToReturn >= 1)
                {
                    changeToReturn -= 1;
                }
                else
                {
                    break;
                }

                count++;
            }
            Console.WriteLine(count);
        }
    }
}
