
List<int> ints = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

Queue<int> queue = new Queue<int>();

for (int i = 0; i < ints.Count; i++)
{
    int currNum = ints[i];
    if (currNum % 2 == 0)
    {
        queue.Enqueue(currNum);
    }
}

Console.WriteLine(string.Join(", ", queue));

