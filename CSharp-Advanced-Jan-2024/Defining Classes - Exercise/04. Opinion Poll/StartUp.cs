namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = args[0];
                int age = int.Parse(args[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            List<Person> peopleSort = people.OrderBy(x => x.Name).ToList();

            foreach (var person in peopleSort.Where(x => x.Age > 30))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");     
            }

        }
    }
}
