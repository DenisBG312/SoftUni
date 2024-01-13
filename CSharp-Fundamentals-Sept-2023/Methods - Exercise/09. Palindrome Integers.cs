namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                bool isNumberPalindrome = IsPalindrome(input);
                Console.WriteLine(IsPalindrome(input));
            }
        }

        private static bool IsPalindrome(string input)
        {
            int leftIndex = 0;
            int rightIndex = input.Length - 1;
            while (leftIndex < rightIndex)
            {
                if (input[leftIndex] != input[rightIndex])
                {
                    return false;
                }
                leftIndex++;
                rightIndex--;
            }

            return true;
        }
    }
}
