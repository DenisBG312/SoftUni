using System;

namespace _08._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //	W - ако е победител получава 2000 точки
            //	F - ако е финалист получава 1200 точки
            //	SF - ако е полуфиналист получава 720 точки

            int turnirsCount = int.Parse(Console.ReadLine());
            int beginnerPoints = int.Parse(Console.ReadLine());
            double points = 0;
            double pointsWithoutBeginning = 0;
            double wins = 0;

            for (int i = 0; i < turnirsCount; i++)
            {
                string typeWin = Console.ReadLine();
                switch (typeWin)
                {
                    case "W":
                        beginnerPoints += 2000;
                        pointsWithoutBeginning += 2000;
                        wins++;
                        break;
                    case "F":
                        beginnerPoints += 1200;
                        pointsWithoutBeginning += 1200;
                        break;
                    case "SF":
                        beginnerPoints += 720;
                        pointsWithoutBeginning += 720;
                        break;
                }
            }
            Console.WriteLine($"Final points: {beginnerPoints}");
            double averagePoints = pointsWithoutBeginning / turnirsCount;
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{wins / turnirsCount * 100:f2}%");
        }
    }
}
