namespace Raiding.Models;

public abstract class BaseHero
{
    public string Name { get; protected set; }
    public int Power { get; protected set; }
    protected BaseHero(string name, int power)
    {
        Name = name;
        Power = power;
    }
    public abstract string CastAbility();
}