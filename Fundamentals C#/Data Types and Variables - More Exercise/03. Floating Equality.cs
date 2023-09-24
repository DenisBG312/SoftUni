namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal a = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());
            decimal diff = 0;
            decimal constEps = 0.000001m;

            decimal maxNum = Math.Max(a, b);
            if (maxNum == a)
            {
                diff = a - b;
            }
            else
            {
                diff = b - a;
            }
            bool isValid = diff < constEps;
            Console.WriteLine(isValid);
        }
    }
}
