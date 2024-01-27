namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> action = strings =>
                Console.WriteLine(string.Join(Environment.NewLine, strings));

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.None)
                .ToArray();

            action(names);
        }
    }
}

