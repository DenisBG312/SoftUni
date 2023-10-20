namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            double totalMax = 0;
            double attendanceMax = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                double attendance = double.Parse(Console.ReadLine());
                //{total bonus} = {student attendances} / {course lectures} * (5 + {additional bonus})
                double totalBonus = attendance / lecturesCount * (5 + additionalBonus);
                if (totalBonus > totalMax)
                {
                    totalMax = totalBonus;
                    attendanceMax = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(totalMax)}.");
            Console.WriteLine($"The student has attended {Math.Ceiling(attendanceMax)} lectures.");
        }
    }
}
