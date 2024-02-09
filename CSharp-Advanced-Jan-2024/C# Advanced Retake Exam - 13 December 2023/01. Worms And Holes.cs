int[] wormsArr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] holesArr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> worms = new Stack<int>(wormsArr);
Queue<int> holes = new Queue<int>(holesArr);

int matches = 0;
int wormsCount = worms.Count;

while (holes.Count != 0 && worms.Count != 0)
{
    if (holes.Peek() == worms.Peek())
    {
        holes.Dequeue();
        worms.Pop();
        matches++;
    }
    else
    {
        holes.Dequeue();
        worms.Push(worms.Pop() - 3);

        if (worms.Peek() <= 0)
        {
            worms.Pop();
        }
    }
}

if (matches != 0)
{
    Console.WriteLine($"Matches: {matches}");
}
else
{
    Console.WriteLine("There are no matches.");
}

if (worms.Count == 0 && matches == wormsCount)
{
    Console.WriteLine("Every worm found a suitable hole!");
}
else if (worms.Count == 0)
{
    Console.WriteLine("Worms left: none");
}
else
{
    Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
}

if (holes.Count == 0)
{
    Console.WriteLine("Holes left: none");
}
else
{
    Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
}




