using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace AnimalFeedingProgram
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
            string result = $"{Name}\n" +
                $"  HP: {HP}\n" +
                $"  MP: {MP}";
            return result;
        }
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

                for (int i = 0; i < n; i++)
                {
                    string[] inputs = Console.ReadLine().Split();
                    string name = inputs[0];
                    double hp = double.Parse(inputs[1]);
                    double mp = double.Parse(inputs[2]);
                    Hero hero = new Hero(name, hp, mp);
                    heroes.Add(name, hero);
                }

                string input;
                while ((input = Console.ReadLine()) != "End")
                {
                    string[] arguments = input.Split(" - ");
                    if (arguments[0] == "CastSpell")
                    {
                        string heroName = arguments[1];
                        double mpNeeded = double.Parse(arguments[2]);
                        string spellName = arguments[3];
                        if (heroes[heroName].MP >= mpNeeded)
                        {
                            heroes[heroName].MP -= mpNeeded;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                    }
                    else if (arguments[0] == "TakeDamage")
                    {
                        string heroName = arguments[1];
                        double damage = double.Parse(arguments[2]);
                        string attacker = arguments[3];
                        heroes[heroName].HP -= damage;
                        if (heroes[heroName].HP > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroName);
                        }
                    }
                    else if (arguments[0] == "Recharge")
                    {
                        string heroName = arguments[1];
                        double amount = double.Parse(arguments[2]);
                        double toBeAdded = Math.Min(amount, 200 - heroes[heroName].MP);
                        heroes[heroName].MP += toBeAdded;
                        Console.WriteLine($"{heroName} recharged for {toBeAdded} MP!");
                    }
                    else if (arguments[0] == "Heal")
                    {
                        string heroName = arguments[1];
                        double amount = double.Parse(arguments[2]);
                        double toBeAdded = Math.Min(amount, 100 - heroes[heroName].HP);
                        heroes[heroName].HP += toBeAdded;
                        Console.WriteLine($"{heroName} healed for {toBeAdded} HP!");
                    }
                }

                foreach (var hero in heroes)
                {
                    Console.WriteLine(hero.Value);
                }
            }
        }
    }
}
