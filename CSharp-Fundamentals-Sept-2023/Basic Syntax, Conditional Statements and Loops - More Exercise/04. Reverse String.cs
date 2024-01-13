string input = Console.ReadLine();
string usernameReversed = string.Empty;

for (int i = input.Length - 1; i >= 0; i--)
{
    usernameReversed += input[i];
}

Console.WriteLine(usernameReversed);
