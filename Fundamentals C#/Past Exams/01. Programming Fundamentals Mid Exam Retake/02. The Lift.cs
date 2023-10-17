namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            List<int> currentState = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            bool isFour = false;

            for (int i = 0; i < currentState.Count; i++)
            {
                //max people on current lift is 4
                int currentLift = currentState[i];
                while (currentLift < 4)
                {
                    peopleWaiting--;
                    if (peopleWaiting >= 0)
                    {
                        currentLift++;
                        isFour = true;
                    }
                    else
                    {
                        isFour = false;
                        break;
                    }
                }
                result.Add(currentLift);
            }

            if (peopleWaiting > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine(string.Join(" ", result));
            }
            else if (peopleWaiting == 0 && isFour)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
