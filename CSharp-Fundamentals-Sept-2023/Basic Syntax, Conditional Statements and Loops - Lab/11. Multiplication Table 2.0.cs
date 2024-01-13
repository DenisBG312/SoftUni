namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            if (multiplier <= 10)
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{firstNum} X {multiplier} = {firstNum * multiplier}");
                    multiplier++;
                }
            }
            else
            {
                Console.WriteLine($"{firstNum} X {multiplier} = {firstNum * multiplier}");
            }
        }
    }
}
