namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentInfo = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string studentName = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentInfo.ContainsKey(studentName))
                {
                    studentInfo[studentName] = new List<decimal>();
                }

                studentInfo[studentName].Add(grade);
            }

            foreach (var student in studentInfo)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
