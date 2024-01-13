namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandToken = command.Split();
                command = commandToken[0];
                int num = int.Parse(commandToken[1]);

                if (command == "Add")
                {
                    numbers.Add(num);
                }
                else if (command == "Remove")
                {
                    numbers.Remove(num);
                }
                else if (command == "RemoveAt")
                {
                    numbers.RemoveAt(num);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(commandToken[2]);
                    numbers.Insert(index, num);
                }
            }

            if (command == "end")
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}
