using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }

        int removedKnights = 0;

        while (true)
        {
            int maxAttacks = 0;
            int knightRow = -1;
            int knightCol = -1;
          
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        int attacks = CountPotentialAttacks(board, row, col, n);
                        if (attacks > maxAttacks)
                        {
                            maxAttacks = attacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
            }

            if (maxAttacks == 0)
            {
                break;
            }
          
            board[knightRow][knightCol] = '0';
            removedKnights++;
        }

        Console.WriteLine(removedKnights);
    }

    static int CountPotentialAttacks(char[][] board, int row, int col, int n)
    {
        int[] deltaRow = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] deltaCol = { 1, 2, 2, 1, -1, -2, -2, -1 };

        int attacks = 0;

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + deltaRow[i];
            int newCol = col + deltaCol[i];

            if (IsValidCell(newRow, newCol, n) && board[newRow][newCol] == 'K')
            {
                attacks++;
            }
        }

        return attacks;
    }

    static bool IsValidCell(int row, int col, int n)
    {
        return row >= 0 && row < n && col >= 0 && col < n;
    }
}
