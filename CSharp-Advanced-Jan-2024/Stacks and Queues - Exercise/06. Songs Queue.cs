namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songsArray = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(songsArray);
            while (songsQueue.Count > 0)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (input[0] == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (input[0] == "Add")
                {
                    string songName = string.Join(' ', input.Skip(1));
                    if (songsQueue.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                        continue;
                    }
                    songsQueue.Enqueue(songName);
                }
                else if (input[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
