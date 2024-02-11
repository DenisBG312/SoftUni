using System.Linq;

namespace MouseInTheKitchen
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] cupboard = new string[dimentions[0], dimentions[1]];
            int mouseRow = -1;
            int mouseCol = -1;
            int totalCheeseNumber = 0;

            for (int i = 0; i < cupboard.GetLength(0); i++)
            {
                string newRow = Console.ReadLine();

                for (int j = 0; j < cupboard.GetLength(1); j++)
                {
                    cupboard[i, j] = newRow[j].ToString();

                    if (newRow[j].ToString() == "M")
                    {
                        mouseRow = i;
                        mouseCol = j;
                        cupboard[mouseRow, mouseCol] = "*";
                    }
                    if (cupboard[i, j] == "C")
                    {
                        totalCheeseNumber++;
                    }
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "danger")
            {
                if ((command == "left" && mouseCol == 0) ||
                    (command == "right" && mouseCol == cupboard.GetLength(1) - 1) ||
                    (command == "up" && mouseRow == 0) ||
                    (command == "down" && mouseRow == cupboard.GetLength(0) - 1))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }
                else
                {
                    if ((command == "left" && cupboard[mouseRow, mouseCol - 1] == "@") ||
                        (command == "right" && cupboard[mouseRow, mouseCol + 1] == "@") ||
                        (command == "up" && cupboard[mouseRow - 1, mouseCol] == "@") ||
                        (command == "down" && cupboard[mouseRow + 1, mouseCol] == "@"))
                    {
                        continue;
                    }
                    else
                    {
                        if (command == "left")
                        {
                            mouseCol--;
                        }
                        else if (command == "right")
                        {
                            mouseCol++;
                        }
                        else if (command == "up")
                        {
                            mouseRow--;
                        }
                        else if (command == "down")
                        {
                            mouseRow++;
                        }

                        if (cupboard[mouseRow, mouseCol] == "C")
                        {
                            totalCheeseNumber--;
                            cupboard[mouseRow, mouseCol] = "*";
                            if (totalCheeseNumber == 0)
                            {
                                cupboard[mouseRow, mouseCol] = "M";
                                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                break;
                            }
                            continue;
                        }
                        if (cupboard[mouseRow, mouseCol] == "T")
                        {
                            Console.WriteLine("Mouse is trapped!");
                            break;
                        }
                    }
                }
            }
            if (command == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
            }
            cupboard[mouseRow, mouseCol] = "M";

            for (int i = 0; i < cupboard.GetLength(0); i++)
            {
                for (int j = 0; j < cupboard.GetLength(1); j++)
                {
                    Console.Write(cupboard[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

