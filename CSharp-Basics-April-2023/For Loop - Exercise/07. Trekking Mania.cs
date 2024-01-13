using System;

namespace _07._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());
            double musala = 0;
            double monblan = 0;
            double kilimandjaro = 0;
            double k2 = 0;
            double everest = 0;
            double totalPeople = 0;
            for (int i = 0; i < groupsCount; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                if (peopleInGroup <= 5 )
                {
                    musala+= peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    monblan+= peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    kilimandjaro+= peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2+= peopleInGroup;
                }
                else
                {
                    everest+= peopleInGroup;
                }
                totalPeople += peopleInGroup;
            }
            double clMusala = musala / totalPeople * 100;
            double clMonblan = monblan / totalPeople * 100;
            double clKilimanjaro = kilimandjaro / totalPeople * 100;
            double clK2 = k2 / totalPeople * 100;
            double clEverest = everest / totalPeople * 100;
            Console.WriteLine($"{clMusala:f2}%");
            Console.WriteLine($"{clMonblan:f2}%");
            Console.WriteLine($"{clKilimanjaro:f2}%");
            Console.WriteLine($"{clK2:f2}%");
            Console.WriteLine($"{clEverest:f2}%");
        }
    }
}
