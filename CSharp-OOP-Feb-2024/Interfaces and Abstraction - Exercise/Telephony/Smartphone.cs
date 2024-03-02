namespace Telephony1;

public class Smartphone : ICallable, IBrowsable
{
    public string Call(string number)
    {
        if (!number.All(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {number}";
    }

    public string Browse(string site)
    {
        if (site.Any(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {site}!";
    }
}