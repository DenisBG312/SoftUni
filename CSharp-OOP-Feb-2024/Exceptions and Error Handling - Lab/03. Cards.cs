using System.Collections.Immutable;
using System.Xml;

namespace _03._Cards
{
    class Card
    {
        private static readonly ImmutableList<string> ValidFaces = ImmutableList.Create<string>("2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A");

        private static readonly ImmutableList<string> ValidSuits = ImmutableList.Create<string>("S", "H", "D", "C");

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            set
            {
                if (!ValidFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }

        public string Suit
        {
            get => suit;
            set
            {
                if (!ValidSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                suit = value;
            }
        }

        public override string ToString()
        {
            string suitSymbol = "";
            switch (Suit)
            {
                case "S":
                    suitSymbol = "\u2660";
                    break;
                case "H":
                    suitSymbol = "\u2665";
                    break;
                case "D":
                    suitSymbol = "\u2666";
                    break;
                case "C":
                    suitSymbol = "\u2663";
                    break;
                default:
                    break;
            }
            return $"[{Face}{suitSymbol}]";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Card> allCards = new List<Card>();

            foreach (var card in inputLine)
            {
                string[] argsSplit = card.Split();
                try
                {
                    Card newCard = new Card(argsSplit[0], argsSplit[1]);
                    allCards.Add(newCard);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", allCards));
        }
    }
}
