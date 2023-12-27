using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace AnimalFeedingProgram
{
    class Pianist
    {
        public string Piece { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public Pianist(string piece, string composer, string key)
        {
            Piece = piece;
            Composer = composer;
            Key = key;
        }

        public override string ToString()
        {
            return $"Composer: {Composer}, Key: {Key}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Pianist> pianists = new Dictionary<string, Pianist>();
            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split('|');
                string piece = arguments[0];
                string composer = arguments[1];
                string key = arguments[2];
                Pianist pianist = new Pianist(piece, composer, key);
                pianists.Add(piece, pianist);
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] arguments = input.Split('|');
                if (arguments[0] == "Add")
                {
                    string piece = arguments[1];
                    string composer = arguments[2];
                    string key = arguments[3];

                    if (!pianists.ContainsKey(piece))
                    {
                        Pianist pianist = new Pianist(piece, composer, key);
                        pianists.Add(piece, pianist);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (arguments[0] == "Remove")
                {
                    string piece = arguments[1];
                    if (!pianists.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        pianists.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                }
                else if (arguments[0] == "ChangeKey")
                {
                    string piece = arguments[1];
                    string newKey = arguments[2];
                    if (pianists.ContainsKey(piece))
                    {
                        pianists[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var pianist in pianists)
            {
                Console.WriteLine($"{pianist.Key} -> {pianist.Value}");
            }
        }
    }
}

