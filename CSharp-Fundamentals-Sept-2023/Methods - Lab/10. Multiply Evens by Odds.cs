namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));

            Console.WriteLine(GetMultipleOfEvenAndOdds(num));
        }

        static int GetSumOfEvenDigits(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                int currDigit = num % 10;

                if (currDigit % 2 == 0)
                {
                    sum += currDigit;
                }

                num /= 10;
            }
            return sum;
        }

        static int GetSumOfOddDigits(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                int currDigit = num % 10;
                if ( currDigit % 2 != 0)
                {
                    sum += currDigit;
                }
                num /= 10;
            }
            return sum;
        }

        static int GetMultipleOfEvenAndOdds(int num)
        {
            return GetSumOfEvenDigits(num) * GetSumOfOddDigits(num);
        }
    }
}
