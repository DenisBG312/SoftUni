namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintTopNumber(num);
        }

        static void PrintTopNumber(int number)
        {
            bool isDivisable = false;
            bool isOdd = false;
            int sum = 0;
            int currDigit = 0;
            for (int i = 0; i < number; i++)
            {
                currDigit = i;
                while (currDigit > 0)
                {
                    if ((currDigit % 10) % 2 != 0)
                    {
                        isOdd = true;
                    }
                    sum += currDigit % 10;
                    currDigit /= 10;
                }
                if (sum % 8 == 0)
                {
                    isDivisable = true;
                }

                if (isDivisable && isOdd)
                {
                    Console.WriteLine(i);
                }

                sum = 0;
                isDivisable = false;
                isOdd = false;
            }
        }
    }
}
