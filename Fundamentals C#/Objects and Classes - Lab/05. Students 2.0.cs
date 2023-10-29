namespace _5._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] token = input.Split();
                bool doesExist = false;

                foreach (Student student in studentsList)
                {
                    if (student.FirstName == token[0]
                        && student.LastName == token[1])
                    {
                        student.Age = int.Parse(token[2]);
                        student.HomeTown = token[3];
                        doesExist = true;
                        break;
                    }
                }

                if(!doesExist) //does not exist
                {
                    Student student = new Student();
                    student.FirstName = token[0];
                    student.LastName = token[1];
                    student.Age = int.Parse(token[2]);
                    student.HomeTown = token[3];

                    studentsList.Add(student);
                }

            }
            string chosenTown = Console.ReadLine();
            foreach (Student student in studentsList)
            {
                if (student.HomeTown == chosenTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
