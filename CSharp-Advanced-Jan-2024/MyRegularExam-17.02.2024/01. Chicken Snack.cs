namespace _01._FirstExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] amountMoneyArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] foodPriceArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> amountMoney = new Stack<int>(amountMoneyArr);
            Queue<int> foodPrice = new Queue<int>(foodPriceArr);

            int ateFoodsCount = 0;

            while (amountMoney.Count > 0 && foodPrice.Count > 0)
            {
                if (amountMoney.Peek() == foodPrice.Peek())
                {
                    ateFoodsCount++;
                    amountMoney.Pop();
                    foodPrice.Dequeue();
                }
                else if (amountMoney.Peek() > foodPrice.Peek())
                {
                    ateFoodsCount++;
                    int change = amountMoney.Peek() - foodPrice.Peek();
                    amountMoney.Pop();
                    if (amountMoney.Count > 0)
                    {
                        int nextAmount = amountMoney.Pop() + change;
                        amountMoney.Push(nextAmount);
                    }
                    foodPrice.Dequeue();
                }
                else if (amountMoney.Peek() < foodPrice.Peek())
                {
                    amountMoney.Pop();
                    foodPrice.Dequeue();
                }
            }

            if (ateFoodsCount >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {ateFoodsCount} foods.");
            }
            else if (ateFoodsCount != 0)
            {
                if (ateFoodsCount == 1)
                {
                    Console.WriteLine($"Henry ate: {ateFoodsCount} food.");
                }
                else
                {
                    Console.WriteLine($"Henry ate: {ateFoodsCount} foods.");
                }
            }
            else
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}
