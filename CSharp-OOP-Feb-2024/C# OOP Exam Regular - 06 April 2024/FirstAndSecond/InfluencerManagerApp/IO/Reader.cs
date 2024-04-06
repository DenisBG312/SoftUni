namespace InfluencerManagerApp.IO
{
    using InfluencerManagerApp.IO.Contracts;
    using System;
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
