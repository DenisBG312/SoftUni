namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandToken = input.Split();
                string command = commandToken[0];
                int index = int.Parse(commandToken[1]);
                int value = int.Parse(commandToken[2]);

                if (command == "Shoot")
                {
                    if (ValidIndex(index, numbersList))
                    {
                        Shoot(index, value, numbersList);    
                    }
                }
                else if (command == "Add")
                {
                    if (ValidIndex(index, numbersList))
                    {
                        numbersList.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (command == "Strike")
                {
                    if (ValidIndex(index, numbersList) &&
                        ValidIndex(index + value, numbersList) &&
                        ValidIndex(index - value, numbersList))
                    {
                        for (int i = 1; i <= value; i++)
                        {
                            numbersList.RemoveAt(index + i);
                        }

                        numbersList.RemoveAt(index);

                        for (int i = 1; i <= value; i++)
                        {
                            numbersList.RemoveAt(index - i);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }

            Console.WriteLine(string.Join("|", numbersList));
            
        }

        private static bool ValidIndex(int index, List<int> numbersList)
        {
            return index < numbersList.Count && index >= 0;
        }

        private static void Shoot(int index, int value, List<int> numbersList)
        {
            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i == index)
                {
                    if (numbersList[i] > value)
                    {
                        numbersList[i] -= value;
                    }
                    else
                    {
                        numbersList.RemoveAt(i);
                    }
                }
            }
        }
    }
}
