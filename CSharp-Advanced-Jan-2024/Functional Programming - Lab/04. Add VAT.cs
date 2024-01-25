namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, decimal> parser = s => decimal.Parse(s);
            Func<decimal, decimal> vat = n => n * 1.2m;

            List<decimal> numbers = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .Select(vat)
                .ToList();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}
