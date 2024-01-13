using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringList = Console.ReadLine()
                .Split("!")
                .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] token = input.Split();
                string command = token[0];
                if (command == "Urgent")
                {
                    bool isDuplicated = false;
                    string item = token[1];
                    int itemIndex = stringList.FindIndex(x => x == item);
                    if (itemIndex >= 0 && itemIndex < stringList.Count)
                    {
                        for (int i = 0; i < stringList.Count; i++)
                        {
                            if (stringList[i + 1] == item)
                            {
                                isDuplicated = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (isDuplicated)
                        {
                            stringList.RemoveAt(1);
                        }
                    }
                    else
                    {
                        stringList.Insert(0, item);
                    }
                }
                else if (command == "Unnecessary")
                {
                    string item = token[1];
                    stringList.Remove(item);
                }
                else if(command == "Correct")
                {
                    bool isThere = false;
                    string oldItem = token[1].Trim('!');
                    string newItem = token[2].Trim('!');
                    int oldItemIndex = stringList.FindIndex(x => x == oldItem);
                    if (oldItemIndex >= 0 && oldItemIndex < stringList.Count)
                    {
                        stringList.RemoveAt(oldItemIndex);
                        stringList.Insert(oldItemIndex, newItem);
                    }
            
                }
                else if (command == "Rearrange")
                {
                    string item = token[1];
                    int itemIndex = stringList.FindIndex(e => e == item);
                    if (itemIndex >= 0 && itemIndex < stringList.Count)
                    {
                        stringList.RemoveAt(itemIndex);
                        stringList.Add(item);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", stringList));
        }
    }
}
