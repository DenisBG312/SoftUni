

int n = int.Parse(Console.ReadLine());

Queue<string> cars = new Queue<string>();

string input = Console.ReadLine();

int passedCount = 0;

while (input != "end")
{
    if (input == "green")
    {
        for (int i = 0; i < n; i++)
        {
            if (cars.Count == 0)
            {
                break;
            }
            passedCount++;
            Console.WriteLine($"{cars.Dequeue()} passed!");
        }
    }
    else
    {
        cars.Enqueue(input);
    }

    input = Console.ReadLine();
}

Console.WriteLine($"{passedCount} cars passed the crossroads.");
