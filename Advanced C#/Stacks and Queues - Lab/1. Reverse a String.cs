string input = Console.ReadLine();

Stack<char> chars = new Stack<char>();

foreach (var character in input)
{
    chars.Push(character);
}

while (chars.Count > 0)
{
    Console.Write(chars.Pop());
}
