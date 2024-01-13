namespace _01._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                char[] reversedWord = input.Reverse().ToArray();

                Console.WriteLine($"{input} = {string.Join("", reversedWord)}");

                input = Console.ReadLine();
            }
        }
    }
}
