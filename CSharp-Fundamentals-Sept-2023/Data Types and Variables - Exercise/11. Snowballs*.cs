using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            2
            10
            2
            3
            5
            5
            5
             */
            int n = int.Parse(Console.ReadLine());
            BigInteger bestValue = 0;
            int snowballSnowBest = 0;
            int snowballTimeBest = 0;
            int snowballQualityBest = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                // formula -> (snowballSnow / snowballTime) ^ snowballQuality
                BigInteger snowballValue = (snowballSnow / snowballTime);
                BigInteger snowballValueFull = BigInteger.Pow(snowballValue, snowballQuality);
                if (snowballValueFull >= bestValue)
                {
                    bestValue = snowballValueFull;
                    snowballSnowBest = snowballSnow;
                    snowballTimeBest = snowballTime;
                    snowballQualityBest = snowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnowBest} : {snowballTimeBest} = {bestValue} ({snowballQualityBest})");
        }
    }
}
