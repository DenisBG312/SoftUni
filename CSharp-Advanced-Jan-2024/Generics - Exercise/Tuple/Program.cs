namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine()
                .Split()
                .ToArray();

            string[] inputTwo = Console.ReadLine()
                .Split()
                .ToArray();

            string[] inputThree = Console.ReadLine()
                .Split()
                .ToArray();



            CustomTuple<string, string> tuple = 
                new CustomTuple<string, string>(inputOne[0] + " " + inputOne[1], inputOne[2]);

            CustomTuple<string, int> tupleTwo = 
                new CustomTuple<string, int>(inputTwo[0], int.Parse(inputTwo[1]));

            CustomTuple<int, double> tupleThree =
                new CustomTuple<int, double>(int.Parse(inputThree[0]), double.Parse(inputThree[1]));

            Console.WriteLine(tuple);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}
