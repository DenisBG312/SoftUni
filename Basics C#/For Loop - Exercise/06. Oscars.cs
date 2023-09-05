using System;

namespace _06._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameActor = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int juryCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < juryCount; i++)
            {
                string nameJury = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                double totalJuryGiven = (nameJury.Length * juryPoints) / 2;
                academyPoints += totalJuryGiven;
                if (academyPoints >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {academyPoints:f1}!");
                    break;
                }
            }
            if (academyPoints < 1250.5)
            {
                Console.WriteLine($"Sorry, {nameActor} you need {1250.5 - academyPoints:f1} more!");
            }
        }
    }
}
