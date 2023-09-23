namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i <= num.Length; i++)
            {
                int digit = int.Parse(num);
                while (digit > 0)
                {
                    int lastDigit = digit % 10;
                    sum += lastDigit;
                    digit /= 10;
                }
                if (digit == 0)
                {
                    break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
