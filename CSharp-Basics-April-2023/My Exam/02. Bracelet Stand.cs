namespace _02._Bracelet_Stand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double terezaMoney = double.Parse(Console.ReadLine());
            double profitDay = double.Parse(Console.ReadLine());
            double expenses = double.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            double savedPocket = 5 * terezaMoney;
            double profitMoney = 5 * profitDay;
            double totalMoney = savedPocket + profitMoney;
            double totalMoneyExp = totalMoney - expenses;
            
            if (totalMoneyExp > presentPrice)
            {
                Console.WriteLine($"Profit: {totalMoneyExp:f2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {presentPrice - totalMoneyExp:f2} BGN.");
            }
        }
    }
}
