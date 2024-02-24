namespace Person;

public class Person
{
    private int _age;
    private string _name;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public virtual int Age
    {
        get => _age;
        set
        {
            if (value >= 0)
            {
                _age = value;
            }
        }   
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}