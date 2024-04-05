namespace HighwayToPeak.IO
{
    using System;
    using HighwayToPeak.IO.Contracts;
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
