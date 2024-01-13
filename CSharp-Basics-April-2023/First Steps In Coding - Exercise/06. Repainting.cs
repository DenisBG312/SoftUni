using System;

namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Предпазен найлон -1.50 лв.за кв. метър
            //•	Боя - 14.50 лв.за литър
            //•	Разредител за боя - 5.00 лв.за литър

            int neededNylon = int.Parse(Console.ReadLine());
            int neededPaint = int.Parse(Console.ReadLine());
            int neededDiluent = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double nylonSum = (neededNylon + 2) * 1.50;
            double paintSum = (neededPaint * 1.10) * 14.50;
            double diluentSum = neededDiluent * 5.00;

            double totalSumMaterials = nylonSum + paintSum + diluentSum + 0.4;
            double sumForWorkers = (totalSumMaterials * 0.3) * hours;

            Console.WriteLine(totalSumMaterials + sumForWorkers);


        }
    }
}
