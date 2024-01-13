using System.Collections.Generic;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Every second lost game, Petar trashes his headset.
            //Every third lost game, Petar trashes his mouse.
            //When Petar trashes both his mouse and headset in the same lost game, he also trashes his keyboard.
            //Every second time, when he trashes his keyboard, he also trashes his display.

            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double totalExpenses = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    totalExpenses += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    totalExpenses += mousePrice;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    totalExpenses += keyboardPrice;
                    if (i % 12  == 0)
                    {
                        totalExpenses += displayPrice;
                    }
                }
            }
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
