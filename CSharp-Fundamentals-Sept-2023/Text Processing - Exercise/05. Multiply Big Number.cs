using System.Numerics;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            string multiplyNumber = Console.ReadLine();

            Console.WriteLine(MultiplyNumbers(bigNumber, multiplyNumber));
        }

        private static string MultiplyNumbers(string bigNumber, string multiplyNumber)
        {
            if (bigNumber == "0" || multiplyNumber == "0")
            {
                return "0";
            }

            int carry = 0;
            int multiplier = int.Parse(multiplyNumber);

            char[] resultChars = new char[bigNumber.Length + 1];

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(bigNumber[i].ToString());
                int product = digit * multiplier + carry;

                resultChars[i + 1] = (char)(product%10 + '0');
                carry = product / 10;
            }

            if (carry > 0)
            {
                resultChars[0] = (char)(carry + '0');
            }
            return new string(resultChars);
        }
    }
}
