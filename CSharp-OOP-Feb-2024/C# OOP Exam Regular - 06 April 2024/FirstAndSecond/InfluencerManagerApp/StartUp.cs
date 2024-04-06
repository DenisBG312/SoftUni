using InfluencerManagerApp.Core;
using InfluencerManagerApp.Core.Contracts;

namespace InfluencerManagerApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
