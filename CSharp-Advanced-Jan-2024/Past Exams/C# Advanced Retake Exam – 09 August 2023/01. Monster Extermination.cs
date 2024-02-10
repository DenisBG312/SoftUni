using Microsoft.VisualBasic;

namespace _01._Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] monstersArmorArr = Console.ReadLine()
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            int[] soldierImpactArr = Console.ReadLine()
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            Queue<int> monsterArmour = new Queue<int>(monstersArmorArr);
            Stack<int> soldierImpact = new Stack<int>(soldierImpactArr);
            int killedMonsters = 0;

            while (monsterArmour.Count > 0 && soldierImpact.Count > 0)
            {
                if (monsterArmour.Peek() <= soldierImpact.Peek())
                {
                    killedMonsters++;
                    int leftSoldierDamage = soldierImpact.Peek() - monsterArmour.Peek();

                    if (leftSoldierDamage == 0)
                    {
                        soldierImpact.Pop();
                        monsterArmour.Dequeue();
;                    }
                    else
                    {
                        monsterArmour.Dequeue();
                        if (soldierImpact.Count == 1)
                        {
                            soldierImpact.Pop();
                            soldierImpact.Push(leftSoldierDamage);
                        }
                        else
                        {
                            soldierImpact.Pop();
                            soldierImpact.Push(soldierImpact.Pop() + leftSoldierDamage);
                        }
                    }
                }
                else
                {
                    int leftArmour = monsterArmour.Peek() - soldierImpact.Peek();
                    soldierImpact.Pop();
                    monsterArmour.Dequeue();
                    monsterArmour.Enqueue(leftArmour);
                }
            }

            if (monsterArmour.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
            }

            if (soldierImpact.Count == 0)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {killedMonsters}");
        }
    }
}
