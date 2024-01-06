

Stack<int> stack = new Stack<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

string input = Console.ReadLine().ToLower();

while (input != "end")
{
    string[] splitted = input.Split(' ');
    if (splitted.Contains("add"))
    {
        int firstNum = int.Parse(splitted[1]);
        int secondNum = int.Parse(splitted[2]);
        stack.Push(firstNum);
        stack.Push(secondNum);
    }
    else if (splitted.Contains("remove"))
    {
        int n = int.Parse(splitted[1]);
        if (stack.Count > n)
        {
            for (int i = 0; i < n; i++)
            {
                stack.Pop();
            }
        }
    }
    input = Console.ReadLine().ToLower();
}

int totalSum = 0;
while (stack.Count > 0)
{
    totalSum += stack.Pop();
}

Console.WriteLine($"Sum: {totalSum}");
