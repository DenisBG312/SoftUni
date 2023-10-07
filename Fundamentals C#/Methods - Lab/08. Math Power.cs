namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double regularNum = double.Parse(Console.ReadLine());
            int powerNum = int.Parse(Console.ReadLine());

            double totalResult = Math_Power(regularNum, powerNum);
            Console.WriteLine(totalResult);
        }

        static double Math_Power(double regularNum, int powerNum)
        {
            double result = Math.Pow(regularNum, powerNum);
            return result;
        }
    }
}
