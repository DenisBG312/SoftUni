namespace _01._Christmas_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paperCount = int.Parse(Console.ReadLine());
            int rolkiCount = int.Parse(Console.ReadLine());
            double lepiloCount = double.Parse(Console.ReadLine());
            double percentDiscount = double.Parse(Console.ReadLine()) / 100;

            double paperPrice = paperCount * 5.8;
            double rolkiPrice = rolkiCount * 7.2;
            double lepiloPrice = lepiloCount * 1.2;
            double totalPrice = paperPrice + rolkiPrice + lepiloPrice;
            double totalPriceDisc = totalPrice - (totalPrice * percentDiscount);

            Console.WriteLine($"{totalPriceDisc:f3}");
        }
    }
}
