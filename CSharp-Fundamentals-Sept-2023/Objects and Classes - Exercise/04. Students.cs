namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                string[] studentArgs = Console.ReadLine().Split(" ").ToArray();
                student.FirstName = studentArgs[0];
                student.LastName = studentArgs[1];
                student.Grade = float.Parse(studentArgs[2]);

                students.Add(student);
            }

            List<Student> orderedStudents = students
                .OrderByDescending(student => student.Grade)
                .ToList();

            Console.WriteLine(string.Join("\n", orderedStudents));
        }
    }
}
