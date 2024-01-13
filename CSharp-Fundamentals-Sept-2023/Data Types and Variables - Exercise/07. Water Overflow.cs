namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int constLitres = 255;
            int litresTotalSum = 0;
            
            for (int i = 0; i < n; i++)
            {
                int litresToBePoured = int.Parse(Console.ReadLine());
                if (constLitres >= litresTotalSum)
                {
                    litresTotalSum += litresToBePoured;
                    if (litresTotalSum > constLitres)
                    {
                        Console.WriteLine("Insufficient capacity!");
                        litresTotalSum -= litresToBePoured;
                    }
                }
            }
            Console.WriteLine(litresTotalSum);
        }
    }
}
