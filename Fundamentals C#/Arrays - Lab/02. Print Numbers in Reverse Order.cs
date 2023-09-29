namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] number = new int[n];

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                number[i] = numbers;
            }
            for (int i = number.Length - 1; i >= 0; i--)
            {
                Console.Write(number[i] + " ");
            }
        }
    }
}
