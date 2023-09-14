namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;

            if (typeGroup == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 10.46;
                }

                if (countPeople >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (typeGroup == "Business")
            {
                if (countPeople >= 100)
                {
                    countPeople -= 10;
                }

                if (dayOfWeek == "Friday")
                {
                    price = 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16;
                }
            }
            else if (typeGroup == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 22.50;
                }

                if (countPeople >= 10 &&  countPeople <= 20)
                {
                    price *= 0.95;
                }
            }
            double totalSum = price * countPeople;
            Console.WriteLine($"Total price: {totalSum:f2}");
        }
    }
}
