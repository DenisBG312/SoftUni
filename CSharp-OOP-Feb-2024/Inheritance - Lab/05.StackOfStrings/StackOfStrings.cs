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

    public void AddRange(List<string> list)
    {
        foreach (var element in list)
        { 
            this.Push(element);
        }
    }
}