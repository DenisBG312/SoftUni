namespace _06._Unique_PIN_Codes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end1 = int.Parse(Console.ReadLine());
            int end2 = int.Parse(Console.ReadLine());
            int end3 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= end1; i++)
            {
                for (int j = 1; j <= end2; j++)
                {
                    for (int k = 1; k <= end3; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                Console.WriteLine($"{i}{j}{k}");
                            }
                        }
                    }
                }
            }
        }
    }
}
