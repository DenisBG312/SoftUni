    using System;

    namespace _07._Area_of_Figures
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                string figure = Console.ReadLine();
                if (figure == "square")
                {
                    double lenght = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{lenght * lenght}:f3");
                }
                else if (figure == "rectangle")
                {
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{a * b}:f3");
                }
                else if (figure == "circle")
                {
                    double r = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{r * r * Math.PI}:f3");
                }
                else if (figure == "triangle")
                {
                    double a = double.Parse(Console.ReadLine());
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{(a * h) / 2}:f3");
                }
            }
        }
    }
