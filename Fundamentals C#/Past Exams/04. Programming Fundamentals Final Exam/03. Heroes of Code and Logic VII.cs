namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public string Name { get; set; }
        public double HP { get; set; }
        public double MP { get; set; }

        public Hero(string name, double hp, double mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                   $"  HP: {HP}\n" +
                   $"  MP: {MP}";
        }
    }
    internal class Program
    {
        static List<Hero> heroes = new List<Hero>();
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split()
                    .ToArray();
                string name = arguments[0];
                double hp = double.Parse(arguments[1]);
                double mp = double.Parse(arguments[2]);
                Hero hero = new Hero(name, hp, mp);
                heroes.Add(hero);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(" - ");
                if (arguments[0] == "CastSpell")
                {
                    CastSpell(arguments[1], double.Parse(arguments[2]), arguments[3]);
                }
                else if (arguments[0] == "TakeDamage")
                {
                    TakeDamage(arguments[1], double.Parse(arguments[2]), arguments[3]);
                }
                else if (arguments[0] == "Recharge")
                {
                    Recharge(arguments[1], double.Parse(arguments[2]));
                }
                else if (arguments[0] == "Heal")
                {
                    Heal(arguments[1], double.Parse(arguments[2]));
                }
            }

            foreach (Hero hero in heroes)
            {
                Console.WriteLine(hero);
            }
        }

        private static void Heal(string heroName, double amount)
        {
            Hero hero = heroes.FirstOrDefault(x => x.Name == heroName);
            if (hero == null)
            {
                return;
            }

            double totalAmount = Math.Min(amount, 100 - hero.HP);
            hero.HP += totalAmount;
            Console.WriteLine($"{hero.Name} healed for {totalAmount} HP!");
        }

        private static void Recharge(string heroName, double amount)
        {
            Hero hero = heroes.FirstOrDefault(x => x.Name == heroName);
            if (hero == null)
            {
                return;
            }

            double totalAmount = Math.Min(amount, 200 - hero.MP);
            hero.MP += totalAmount;
            Console.WriteLine($"{hero.Name} recharged for {totalAmount} MP!");
        }

        private static void TakeDamage(string heroName, double damage, string attacker)
        {
            Hero hero = heroes.FirstOrDefault(x => x.Name == heroName);
            if (hero == null)
            {
                return;
            }

            hero.HP -= damage;
            if (hero.HP > 0)
            {
                Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.HP} HP left!");
            }
            else
            {
                heroes.Remove(hero);
                Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
            }
        }

        private static void CastSpell(string heroName, double mpNeeded, string spellName)
        {
            Hero hero = heroes.FirstOrDefault(x => x.Name == heroName);
            if (hero == null)
            {
                return;
            }

            if (hero.MP >= mpNeeded)
            {
                hero.MP -= mpNeeded;
                Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.MP} MP!");
            }
            else
            {
                Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
            }
        }
    }
}
