Stack<string> stack = new Stack<string>(Console.ReadLine().Split().Reverse());

int result = int.Parse(stack.Pop());

while (stack.Count > 0)
{
    string operation = stack.Pop();
    int secondNum = int.Parse(stack.Pop());
    if (operation == "+")
    {
        result += secondNum;
    }
    else if (operation == "-")
    {
        result -= secondNum;
    }
}
Console.WriteLine(result);
