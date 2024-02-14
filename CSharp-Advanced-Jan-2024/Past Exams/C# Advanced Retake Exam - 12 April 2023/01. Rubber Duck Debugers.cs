namespace _01._Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] timeTakingArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numberOfTasksArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int vaderDucky = 0;
            int thorDucky = 0;
            int bigBlueDucky = 0;
            int smallYellowDucky = 0;



            Queue<int> timeTaking = new Queue<int>(timeTakingArr);
            Stack<int> numberOfTasks = new Stack<int>(numberOfTasksArr);

            while (timeTaking.Count > 0 && numberOfTasks.Count > 0)
            {
                int time = timeTaking.Peek();
                int task = numberOfTasks.Peek();

                int result = time * task;

                if (result > 240)
                {
                    timeTaking.Enqueue(timeTaking.Dequeue());
                    numberOfTasks.Push(numberOfTasks.Pop() - 2);
                }
                else if (result >= 181 && result <= 240)
                {
                    smallYellowDucky++;
                    timeTaking.Dequeue();
                    numberOfTasks.Pop();
                }
                else if (result >= 121 && result <= 180)
                {
                    bigBlueDucky++;
                    timeTaking.Dequeue();
                    numberOfTasks.Pop();
                }
                else if (result >= 61 && result <= 120)
                {
                    thorDucky++;
                    timeTaking.Dequeue();
                    numberOfTasks.Pop();
                }
                else if (result >= 0 && result <= 60)
                {
                    vaderDucky++;
                    timeTaking.Dequeue();
                    numberOfTasks.Pop();
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {vaderDucky}");
            Console.WriteLine($"Thor Ducky: {thorDucky}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueDucky}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowDucky}");
        }
    }
}
