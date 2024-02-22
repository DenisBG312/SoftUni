namespace CustomStack;

public class StackOfStrings : Stack<string>
{
    public bool IsEmpty()
    {
        if (this.Count == 0)
        {
            return true;
        }
        return false;
    }

    public Stack<string> AddRange(List<string> list)
    {
        foreach (var element in list)
        { 
            this.Push(element);
        }
        return this;
    }
}
