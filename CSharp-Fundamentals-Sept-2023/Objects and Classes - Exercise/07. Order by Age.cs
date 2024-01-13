namespace _07._Order_by_Age
{
    class PersonInformation
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public PersonInformation(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonInformation> persons = new List<PersonInformation>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                PersonInformation person = new PersonInformation(tokens[0], tokens[1], int.Parse(tokens[2]));
                persons.Add(person);
            }

            var result = persons.OrderBy(x => x.Age);
            foreach (PersonInformation person in result)
            {
                Console.WriteLine(person);
            }
        }
    }
}
