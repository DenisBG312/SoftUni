using System;
using System.Text;

namespace Animals;

public class Animal
{
    private string name;
    private int age;
    private string gender;
    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            name = value;
        }
    }
    public int Age
    {
        get => age;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            age = value;
        }
    }

    public string Gender
    {
        get => gender;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            gender = value;
        }
    }

    public virtual string ProduceSound() => string.Empty;

    public override string ToString()
        => $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
}