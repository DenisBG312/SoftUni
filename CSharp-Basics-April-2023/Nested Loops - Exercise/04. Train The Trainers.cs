using System;

namespace _04._Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juryCount = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double totalGrades = 0;
            double count = 0;
            
            while (input != "Finish")
            {
                double totalGrade = 0;
                for (int i = 1; i <= juryCount; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    totalGrade += grade;
                    count++;
                }
                totalGrades += totalGrade;
                double averageGrade = totalGrade / juryCount;
                Console.WriteLine($"{input} - {averageGrade:f2}.");
                input = Console.ReadLine();
            }
            if (input == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {totalGrades / count:f2}.");
            }
        }
    }
}
