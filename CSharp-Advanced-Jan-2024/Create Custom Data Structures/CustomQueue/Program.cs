﻿namespace _03.CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(1);
            queue.Enqueue(22);
            queue.Enqueue(33);
            queue.Enqueue(44);
            queue.Enqueue(555);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Peek());

            queue.ForEach(i => Console.Write($"{i} "));

            queue.Clear();

            queue.ForEach(i => Console.Write($"{i} "));

            Console.WriteLine();
            Console.WriteLine(queue.Count);
        }
    }
}
