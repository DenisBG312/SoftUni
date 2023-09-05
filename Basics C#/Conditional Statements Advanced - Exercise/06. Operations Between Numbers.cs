using System;

namespace _06._Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double sbor = 0;
            string eo = "";


            if (operation == "+")
            {
                sbor = n1 + n2;
                if (sbor % 2 == 0)
                {
                    eo = "even";
                }
                else
                {
                    eo = "odd";
                }
                Console.WriteLine($"{n1} + {n2} = {sbor} - {eo}");
            }
            else if (operation == "-")
            {
                sbor = n1 - n2;
                if (sbor % 2 == 0)
                {
                    eo = "even";
                }
                else
                {
                    eo = "odd";
                }
                Console.WriteLine($"{n1} - {n2} = {sbor} - {eo}");
            }
            else if (operation == "*")
            {
                sbor = n1 * n2;
                if (sbor % 2 == 0)
                {
                    eo = "even";
                }
                else
                {
                    eo = "odd";
                }
                Console.WriteLine($"{n1} * {n2} = {sbor} - {eo}");
            }
            else if (operation == "/")
            {
                if (n2 != 0)
                {
                    sbor = n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {sbor:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                
            }
            else if (operation == "%")
            {
                if (n2 != 0)
                {
                    sbor = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {sbor}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
            }

        }
    }
}
