namespace BorderControl;

public class Citizen : IBuyer
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
        Food = 0;
    }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Birthdate { get; private set; }

    public int Food { get; set; }

    public int BuyFood()
    {
        return 10;
    }
}