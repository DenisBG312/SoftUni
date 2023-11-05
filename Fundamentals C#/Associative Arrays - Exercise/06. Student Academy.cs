namespace _06._Student_Academy
{
    internal class Program
    {
        class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }

            public Student (string name)
            {
                Name = name;
                Grades = new List<double>();
            }

            public override string ToString()
            {
                return $"{Name} -> {Grades.Average():f2}";
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Student> studentGrade = new Dictionary<string, Student> ();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!studentGrade.ContainsKey(name))
                {
                    Student student = new Student(name);
                    studentGrade.Add(student.Name, student);
                }

                studentGrade[name].Grades.Add(grade);
            }

            foreach (KeyValuePair<string, Student> kvp in studentGrade)
            {
                if (kvp.Value.Grades.Average() >= 4.50)
                {
                    Console.WriteLine(kvp.Value);
                }   
            }
        }
    }
}
