namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringInput = Console.ReadLine();
            PrintMiddleCharacter(stringInput);
        }

        static void PrintMiddleCharacter(string stringInput)
        {
            if (stringInput.Length % 2 != 0)
            {
                int length = stringInput.Length;
                int middleChar = length / 2;
                Console.WriteLine(stringInput[middleChar]);
            }
            else
            {
                int length = stringInput.Length;
                int middleChar = length / 2;
                int middlePrevChar = length / 2 - 1;
                Console.WriteLine($"{stringInput[middlePrevChar]}{stringInput[middleChar]}");
            }
        }
    }
}
