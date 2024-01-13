namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstHand.Count > 0 && secondHand.Count > 0)
            {
                int firstCard = firstHand[0];
                int secondCard = secondHand[0];

                if (firstCard > secondCard)
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                    firstHand.Add(firstCard);
                    firstHand.Add(secondCard);
                }
                else if (secondCard > firstCard)
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                    secondHand.Add(secondCard);
                    secondHand.Add(firstCard);
                }
                else
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
            }

            if (firstHand.Count > secondHand.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
            }
        }
    }
}
