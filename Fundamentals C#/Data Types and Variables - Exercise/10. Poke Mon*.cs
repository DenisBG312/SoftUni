namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // -> poke power 
            int m = int.Parse(Console.ReadLine()); // -> distance
            int y = int.Parse(Console.ReadLine()); // -> exhaustionFactor
            int targetsCount = 0;
            double halfOfN = n * 0.5;

            while (n >= m)
            {
                if (n == halfOfN && n > 0)
                {
                    if (y > 0)
                    {
                        n /= y;
                    }
                    if (n < m)
                    {
                        break;
                    }
                }
                n -= m;
                targetsCount++;
            }
            Console.WriteLine(n);
            Console.WriteLine(targetsCount);
        }
    }
}
