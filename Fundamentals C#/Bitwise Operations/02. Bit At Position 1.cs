namespace _2._Bit_at_Position_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int shiftedNumber = number >> 1;
            int lsb = shiftedNumber & 1;

            Console.WriteLine(lsb);
        }
    }
}
