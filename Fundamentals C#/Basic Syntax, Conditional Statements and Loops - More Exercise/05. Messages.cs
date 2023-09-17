int n = int.Parse(Console.ReadLine());
string character = string.Empty;
string totalWord = string.Empty;

for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());
    switch (num)
    {
        case 0:
            character = " "; break;
        case 2:
            character = "a"; break;
        case 22:
            character = "b"; break;
        case 222:
            character = "c"; break;
        case 3:
            character = "d"; break;
        case 33:
            character = "e"; break;
        case 333:
            character = "f" ; break;
        case 4:
            character = "g"; break;
        case 44:
            character = "h"; break;
        case 444:
            character = "i"; break;
        case 5:
            character = "j"; break;
        case 55:
            character = "k"; break;
        case 555:
            character = "l"; break;
        case 6:
            character = "m"; break;
        case 66:
            character = "n"; break;
        case 666:
            character = "o"; break;
        case 7:
            character = "p"; break;
        case 77:
            character = "q"; break;
        case 777:
            character = "r"; break;
        case 7777:
            character = "s"; break;
        case 8:
            character = "t"; break;
        case 88:
            character = "u"; break;
        case 888:
            character = "v"; break;
        case 9:
            character = "w"; break;
        case 99:
            character = "x"; break;
        case 999:
            character = "y"; break;
        case 9999:
            character = "z" ; break;
    }
    totalWord += character;
}
Console.WriteLine(totalWord);
