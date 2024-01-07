namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Queue<string> customers = new Queue<string>();
            int count = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                    count = 0;
                    continue;
                }
                customers.Enqueue(input);
                count++;
            }
            Console.WriteLine($"{count} people remaining.");
        }
    }
}
