namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] arguments = input.Split();
                int num1 = int.Parse(arguments[1]);
                if (arguments[0] == "add")
                {
                    int num2 = int.Parse(arguments[2]);
                    numbers.Push(num1);
                    numbers.Push(num2);
                }
                else if (arguments[0] == "remove")
                {
                    if (numbers.Count > num1)
                    {
                        for (int i = 0; i < num1; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
