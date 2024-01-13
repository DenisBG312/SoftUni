int endNum = int.Parse(Console.ReadLine());

for (int i = 1; i <= endNum; i++)
{
    int number = i;
    int sum = 0;
    while (number > 0)
    {
        int lastDigit = number % 10;
        sum += lastDigit;
        number /= 10;
    }
    bool isValid = sum == 5 || sum == 7 || sum == 11;
    Console.WriteLine($"{i} -> " + isValid);
}
