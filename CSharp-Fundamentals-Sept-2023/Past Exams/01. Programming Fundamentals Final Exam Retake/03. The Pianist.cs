namespace _03._The_Pianist
{
    class Pieces
    {
        public string Piece { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public Pieces(string piece, string composer, string key)
        {
            Piece = piece;
            Composer = composer;
            Key = key;
        }

        public override string ToString()
        {
            string result = $"{Piece} -> Composer: {Composer}, Key: {Key}";
            return result;
        }
    }
    internal class Program
    {
        static List<Pieces> pieces = new List<Pieces>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split("|");
                string pieceName = arguments[0];
                string composer = arguments[1];
                string key = arguments[2];

                Pieces currPiece = new Pieces(pieceName, composer, key);
                pieces.Add(currPiece);
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] arguments = input.Split("|");
                if (arguments[0] == "Add")
                {
                    Add(arguments[1], arguments[2], arguments[3]);
                }
                else if (arguments[0] == "Remove")
                {
                    Remove(arguments[1]);
                }
                else if (arguments[0] == "ChangeKey")
                {
                    ChangeKey(arguments[1], arguments[2]);
                }
            }

            foreach (Pieces piece in pieces)
            {
                Console.WriteLine(piece);
            }
        }

        private static void ChangeKey(string pieceName, string newKey)
        {
            Pieces piece = pieces.FirstOrDefault(x => x.Piece == pieceName);

            if (piece == null)
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                return;
            }

            piece.Key = newKey;
            Console.WriteLine($"Changed the key of {piece.Piece} to {piece.Key}!");
        }

        private static void Remove(string pieceName)
        {
            Pieces piece = pieces.FirstOrDefault(x => x.Piece == pieceName);

            if (piece == null)
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                return;
            }

            pieces.Remove(piece);
            Console.WriteLine($"Successfully removed {piece.Piece}!");
        }

        private static void Add(string pieceName, string composer, string key)
        {
            Pieces piece = pieces.FirstOrDefault(x => x.Piece == pieceName);
            if (piece != null)
            {
                Console.WriteLine($"{piece.Piece} is already in the collection!");
                return;
            }

            Pieces newPiece = new Pieces(pieceName, composer, key);
            pieces.Add(newPiece);
            Console.WriteLine($"{newPiece.Piece} by {newPiece.Composer} in {newPiece.Key} added to the collection!");
        }
    }
}
