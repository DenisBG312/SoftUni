namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Action<string, string[]> printNamesWithTitle = (title, names) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.None)
                .ToArray();

            printNamesWithTitle("Sir", input);
        }
    }
}
