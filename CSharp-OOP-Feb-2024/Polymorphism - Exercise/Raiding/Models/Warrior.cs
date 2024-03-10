namespace Raiding.Models;

public class Warrior : BaseHero
{
    private const int DefaultPower = 100;
    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }

    public Warrior(string name) : base(name, DefaultPower)
    {
    }
}