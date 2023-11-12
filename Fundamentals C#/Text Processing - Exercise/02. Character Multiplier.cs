using System.Runtime.ExceptionServices;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ");

            Console.WriteLine(GetSum(strings[0], strings[1]));
        }

        private static int GetSum(string first, string second)
        {
            int result = 0;
            int length = Math.Max(first.Length, second.Length);

            for (int i = 0; i < length; i++)
            {
                if (i < first.Length && i < second.Length)
                {
                    result += first[i] * second[i];
                }
                else if (i < first.Length)
                {
                    result += first[i];
                }
                else if (i < second.Length)
                {
                    result += second[i];
                }
            }

            return result;
        }
    }
}
