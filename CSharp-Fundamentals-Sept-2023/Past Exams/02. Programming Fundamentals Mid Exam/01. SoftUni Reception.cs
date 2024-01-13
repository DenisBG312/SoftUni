namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmp = int.Parse(Console.ReadLine());
            int secondEmp = int.Parse(Console.ReadLine());
            int thirdEmp = int.Parse(Console.ReadLine());
            int totalEmp = firstEmp + secondEmp + thirdEmp;
            int hours = 0;
            int studentsCount = int.Parse(Console.ReadLine());

            while (studentsCount > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }

                studentsCount -= totalEmp;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
