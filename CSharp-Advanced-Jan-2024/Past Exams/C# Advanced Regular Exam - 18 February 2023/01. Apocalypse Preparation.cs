using System;

namespace _01._Apocalypse_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));


            Dictionary<int, string> table = new Dictionary<int, string>()
            {
                {30, "Patch"},
                {40, "Bandage"},
                {100, "MedKit"}
            };

            Dictionary<string, int> items = new Dictionary<string, int>();

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int result = textiles.Peek() + medicaments.Peek();

                if (table.ContainsKey(result))
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (result == 30)
                    {
                        if (!items.ContainsKey("Patch"))
                        {
                            items.Add("Patch", 0);
                        }
                        items["Patch"]++;
                    }
                    else if (result == 40)
                    {
                        if (!items.ContainsKey("Bandage"))
                        {
                            items.Add("Bandage", 0);
                        }
                        items["Bandage"]++;
                    }
                    else if (result == 100)
                    {
                        if (!items.ContainsKey("MedKit"))
                        {
                            items.Add("MedKit", 0);
                        }
                        items["MedKit"]++;
                    }
                }
                else if (result > 100)
                {
                    if (!items.ContainsKey("MedKit"))
                    {
                        items.Add("MedKit", 0);
                    }
                    items["MedKit"]++;
                    int newResult = result - 100;
                    medicaments.Pop();
                    textiles.Dequeue();
                    medicaments.Push(medicaments.Pop() + newResult);
                }
                else
                {
                    textiles.Dequeue();
                    medicaments.Push(medicaments.Pop() + 10);
                }
            }

            if (textiles.Count == 0 && medicaments.Count > 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (textiles.Count > 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else if (textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            foreach (var kvp in items
                         .OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                if (kvp.Value == 0)
                {
                    continue;
                }
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}
