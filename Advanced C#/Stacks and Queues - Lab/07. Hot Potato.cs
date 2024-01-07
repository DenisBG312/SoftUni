

Queue<string> children = new Queue<string>(Console.ReadLine()
    .Split());

int countThrow = int.Parse(Console.ReadLine());

int count = 0;
while (children.Count > 1)
{
    count++;
    string child = children.Dequeue();
    if (count == countThrow)
    {
        count = 0;
        Console.WriteLine($"Removed {child}");
    }
    else
    {
        children.Enqueue(child);
    }
}
Console.WriteLine($"Last is {children.Dequeue()}");
