namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int courses = n / p;
            int remainder = n % p;

            if (remainder == 0)
            {
                Console.WriteLine(courses);
            }
            else
            {
                Console.WriteLine(courses + remainder / remainder);
            }
            

        }
    }
}
