int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
int num3 = int.Parse(Console.ReadLine());

double[] numbers = { num1, num2, num3 };

Array.Sort(numbers);
Array.Reverse(numbers);

foreach (double number in numbers)
{
    Console.WriteLine(number);
}
