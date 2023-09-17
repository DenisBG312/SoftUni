//OutFall 4 $39.99
//CS: OG $15.99
//Zplinter Zell $19.99
//Honored 2 $59.99
//RoverWatch $29.99
//RoverWatch Origins Edition $39.99

double currentBalance = double.Parse(Console.ReadLine());
string input = Console.ReadLine();
double priceOfGame = 0;
double totalSpent = 0;

while (input != "Game Time")
{
    if (input == "OutFall 4")
    {
        priceOfGame = 39.99;
        if (currentBalance >= priceOfGame)
        {
            Console.WriteLine($"Bought {input}");
            currentBalance -= priceOfGame;
        }
        else
        {
            Console.WriteLine("Too Expensive");
            priceOfGame = 0;
        }
    }
    else if (input == "CS: OG")
    {
        priceOfGame = 15.99;
        if (currentBalance >= priceOfGame)
        {
            Console.WriteLine($"Bought {input}");
            currentBalance -= priceOfGame;
        }
        else
        {
            Console.WriteLine("Too Expensive");
            priceOfGame = 0;
        }
    }
    else if (input == "Zplinter Zell")
    {
        priceOfGame = 19.99;
        if (currentBalance >= priceOfGame)
        {
            Console.WriteLine($"Bought {input}");
            currentBalance -= priceOfGame;
        }
        else
        {
            Console.WriteLine("Too Expensive");
            priceOfGame = 0;
        }
    }
    else if (input == "Honored 2")
    {
        priceOfGame = 59.99;
        if (currentBalance >= priceOfGame)
        {
            Console.WriteLine($"Bought {input}");
            currentBalance -= priceOfGame;
        }
        else
        {
            Console.WriteLine("Too Expensive");
            priceOfGame = 0;
        }
    }
    else if (input == "RoverWatch")
    {
        priceOfGame = 29.99;
        if (currentBalance >= priceOfGame)
        {
            Console.WriteLine($"Bought {input}");
            currentBalance  -= priceOfGame;
        }
        else
        {
            Console.WriteLine("Too Expensive");
            priceOfGame = 0;
        }
    }
    else if (input == "RoverWatch Origins Edition")
    {
        priceOfGame = 39.99;
        if (currentBalance >= priceOfGame)
        {
            Console.WriteLine($"Bought {input}");
            currentBalance -= priceOfGame;
        }
        else
        {
            Console.WriteLine("Too Expensive");
            priceOfGame = 0;
        }
    }
    else
    {
        Console.WriteLine("Not Found");
    }
    if (currentBalance == 0)
    {
        Console.WriteLine("Out of money!");
        break;
    }
    totalSpent += priceOfGame;
    input = Console.ReadLine();
}

if (input == "Game Time")
{
    Console.WriteLine($"Total spent: ${totalSpent}. Remaining: ${currentBalance:f2}");
}
