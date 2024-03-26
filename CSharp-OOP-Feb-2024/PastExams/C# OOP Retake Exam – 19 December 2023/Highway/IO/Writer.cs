namespace HighwayToPeak.IO
{
    using System;
    using HighwayToPeak.IO.Contracts;
    public class Writer : IWriter
    {
        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
