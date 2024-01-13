namespace _04._Grandpa_Stavri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalRakiq = 0;
            double totalDegreeS = 0;
            
            for (int i = 0; i < days; i++)
            {
                double rakiqQuantity = double.Parse(Console.ReadLine());
                double degree = double.Parse(Console.ReadLine());
                double totalDegree = rakiqQuantity * degree;
                totalRakiq += rakiqQuantity;
                totalDegreeS += totalDegree;
            }
            Console.WriteLine($"Liter: {totalRakiq:f2}");
            double calcDegrees = totalDegreeS / totalRakiq;
            Console.WriteLine($"Degrees: {calcDegrees:f2}");
            if (calcDegrees < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }
            else if (calcDegrees >= 38 && calcDegrees <= 42)
            {
                Console.WriteLine("Super!");
            }
            else
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}
