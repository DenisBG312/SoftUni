using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using System.Linq;

namespace _02._Mirror_Words
{
    class Pairs
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public Pairs(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public override string ToString()
        {
            return $"{FirstName} <=> {SecondName}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pairsPattern = @"(#|@)(?<FirstName>[A-Za-z]{3,})\1{2}(?<SecondName>[A-Za-z]{3,})\1";

            List<string> validPairs = new List<string>();

            foreach (Match match in Regex.Matches(input, pairsPattern))
            {
                validPairs.Add(match.Value);
            }

            if (validPairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{validPairs.Count} word pairs found!");
            }

            List<string> validPairsCurr = validPairs;
            List<Pairs> validCurrPairs = new List<Pairs>();
            foreach (string pair in validPairsCurr)
            {
                string validPairsPattern = @"(#|@)(?<FirstWord>[A-Za-z]{3,})\1{2}(?<SecondWord>[A-Za-z]{3,})\1";
                foreach (Match match in Regex.Matches(pair, validPairsPattern))
                {
                    string firstWord = match.Groups["FirstWord"].Value;
                    string secondWord = match.Groups["SecondWord"].Value;
                    char[] secondWordChars = secondWord.ToCharArray();
                    Array.Reverse(secondWordChars);
                    string secondWordRev = new string(secondWordChars);
                    if (firstWord == secondWordRev)
                    {
                        Pairs validPair = new Pairs(firstWord, secondWord);
                        validCurrPairs.Add(validPair);
                    }
                }
            }
            if (validCurrPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }
            Console.WriteLine("The mirror words are:");
            string result = string.Join(", ", validCurrPairs);
            Console.WriteLine(result);
        }
    }
}
