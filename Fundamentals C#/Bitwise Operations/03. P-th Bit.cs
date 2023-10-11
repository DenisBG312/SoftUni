namespace _3._P_th_Bit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int shiftedNumber = number >> position;
            int lsb = shiftedNumber & 1;

            Console.WriteLine(lsb);
        }
    }
}
