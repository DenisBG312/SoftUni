﻿namespace _01._ListyIterator;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> items = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .ToList();

        ListyIterator<string> listyIterator = new ListyIterator<string>(items);

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "PrintAll":
                    foreach (var item in listyIterator)
                    {
                        Console.Write($"{item} ");
                    }

                    Console.WriteLine();

                    break;
            }
        }
    }
}