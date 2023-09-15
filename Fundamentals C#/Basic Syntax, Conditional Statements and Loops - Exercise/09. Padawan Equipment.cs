namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsaberTotal = (Math.Ceiling(studentsCount * 1.1)) * lightsaberPrice; 
            double robesTotal = studentsCount * robePrice;

            int freeBelts = studentsCount / 6;

            double beltsTotal = (studentsCount - freeBelts) * beltPrice;

            double totalPrice = lightsaberTotal + robesTotal + beltsTotal;

            if (amountMoney >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - amountMoney:f2}lv more.");
            }


        }
    }
}
