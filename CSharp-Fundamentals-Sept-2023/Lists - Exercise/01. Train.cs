namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagonsList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            int wagonMaxCapacity = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] arguments = input.Split();

                if (arguments[0] == "Add")
                {
                    int passengers = int.Parse(arguments[1]);
                    wagonsList.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(arguments[0]);
                    for (int i = 0; i < wagonsList.Count; i++)
                    {
                        if (wagonsList[i] + passengers <= wagonMaxCapacity)
                        {
                            wagonsList[i] += passengers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagonsList));
        }
    }
}
