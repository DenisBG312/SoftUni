namespace Telephony1;

public class StationaryPhone : ICallable
{
    public string Call(string number)
    {
        if (!number.All(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Dialing... {number}";
    }
}