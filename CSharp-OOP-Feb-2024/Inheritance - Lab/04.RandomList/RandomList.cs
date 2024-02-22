namespace CustomRandomList;

public class RandomList : List<string>
{
    public string RandomString()
    {
        Random random = new Random();

        string item = this[random.Next(0, this.Count)];
        this.Remove(item);
        return item;

    }
}