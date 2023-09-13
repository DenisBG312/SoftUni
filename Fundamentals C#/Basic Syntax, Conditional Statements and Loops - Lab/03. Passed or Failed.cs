namespace _03._Passed_or_Failed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade < 3)
            {
                Console.WriteLine($"Failed!");
            }
            else
            {
                Console.WriteLine($"Passed!");
            }
        }
    }
}
