namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int totalSum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                int factorialNum = 1;
                int firstNum = int.Parse(num[i].ToString());

                for (int j = 1; j <= firstNum; j++)
                {
                    factorialNum *= j;
                }
                totalSum += factorialNum;
            }
            if (totalSum == int.Parse(num))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
