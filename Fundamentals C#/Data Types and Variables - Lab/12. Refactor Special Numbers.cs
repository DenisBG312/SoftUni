int num = int.Parse(Console.ReadLine());
int total = 0;

for (int i = 1; i <= num; i++)
{
    int digit = i;
    while (i > 0)
    {
        total += i % 10;
        i /= 10;
    }
    bool isSpecial = (total == 5) || (total == 7) || (total == 11);
    Console.WriteLine("{0} -> {1}", digit, isSpecial);
    total = 0;
    i = digit;
}
