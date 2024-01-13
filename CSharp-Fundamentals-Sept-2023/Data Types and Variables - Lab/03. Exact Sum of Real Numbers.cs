int num = int.Parse(Console.ReadLine());
decimal sum = 0m;

for (int i = 0; i < num; i++)
{
    decimal numInput = decimal.Parse(Console.ReadLine());
    sum += numInput;
}
Console.WriteLine($"{sum}");

