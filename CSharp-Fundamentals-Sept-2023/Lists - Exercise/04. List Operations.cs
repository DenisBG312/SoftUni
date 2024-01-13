namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split();

                if (arguments[0] == "Add")
                {
                    int number = int.Parse(arguments[1]);
                    numbers.Add(number);
                }
                else if (arguments[0] == "Insert")
                {
                    int number = int.Parse(arguments[1]);
                    int index = int.Parse(arguments[2]);
                    if (IsNotValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (arguments[0] == "Remove")
                {
                    int index = int.Parse(arguments[1]);
                    if (IsNotValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (arguments[0] == "Shift")
                {
                    int count = int.Parse(arguments[2]);
                    count %= numbers.Count;
                    if (arguments[1] == "left")
                    {
                        List<int> shiftedPart = numbers.GetRange(0, count);
                        numbers.RemoveRange(0, count);
                        numbers.InsertRange(numbers.Count, shiftedPart);

                    }
                    else if (arguments[1] == "right")
                    {
                        List<int> shiftedPart = numbers.GetRange(numbers.Count - count, count);
                        numbers.RemoveRange(numbers.Count - count, count);
                        numbers.InsertRange(0, shiftedPart);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool IsNotValidIndex(int index, int numbers)
        {
            return index < 0 || index > numbers;
        }
    }
}
