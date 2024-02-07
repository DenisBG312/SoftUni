namespace Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine()
                .Split();

            string[] inputTwo = Console.ReadLine()
                .Split();

            string[] inputThree = Console.ReadLine()
                .Split();

            Threeuple<string, string, string> first = 
                new Threeuple<string, string, string>($"{inputOne[0]} {inputOne[1]}", inputOne[2], string.Join(" ", inputOne[3..]));

            Threeuple<string, int, bool> second =
                new Threeuple<string, int, bool>(inputTwo[0], int.Parse(inputTwo[1]), inputTwo[2] == "drunk");

            Threeuple<string, double, string> third =
                new Threeuple<string, double, string>(inputThree[0], double.Parse(inputThree[1]), inputThree[2]);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
