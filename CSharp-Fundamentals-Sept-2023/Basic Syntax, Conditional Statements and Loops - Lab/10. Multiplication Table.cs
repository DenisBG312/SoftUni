namespace _10._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int times = 1;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{firstNum} X {times} = {firstNum * times}");
                times++;
            }
        }
    }
}
