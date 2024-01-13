using System;

namespace _02._Exam_Preparation1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int poorGradesCount = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double checks = 0;
            double totalGrade = 0;
            double poorGrades = 0;
            string lastExercise = "";
            while (input != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                totalGrade += grade;
                checks++;
                lastExercise = input;
                if (grade <= 4)
                {
                    poorGrades++;
                    if (poorGrades >= poorGradesCount)
                    {
                        Console.WriteLine($"You need a break, {poorGrades} poor grades.");
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            if (input == "Enough")
            {
                Console.WriteLine($"Average score: {totalGrade / checks:f2}");
                Console.WriteLine($"Number of problems: {checks}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }
        }
    }
}
