namespace BorderControl;

public class Rebel : IBuyer
{
    public Rebel (string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }
    public int Food { get; set; }
    public int BuyFood()
    {
        return 5;
    }
}