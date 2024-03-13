namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            List<double> numbers = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                if (!ReadNumbers(start, end, numbers))
                {
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static bool ReadNumbers(int start, int end, List<double> numbers)
        {
            try
            {
                double number = double.Parse(Console.ReadLine());
                if (number <= start || number >= end)
                {
                    throw new ArgumentException($"Your number is not in range {start} - {end}!");
                }

                numbers.Add(number);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Number!");
                return false;
            }
            return true;
        }
    }
}
