using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.IO.Contracts;
using InfluencerManagerApp.IO;

namespace InfluencerManagerApp.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
            controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "RegisterInfluencer")
                    {
                        string typeName = input[1];
                        string userName = input[2];
                        int followers = int.Parse(input[3]);

                        result = controller.RegisterInfluencer(typeName, userName, followers);
                    }
                    else if (input[0] == "BeginCampaign")
                    {
                        string typeName = input[1];
                        string brand = input[2];

                        result = controller.BeginCampaign(typeName, brand);
                    }
                    else if (input[0] == "AttractInfluencer")
                    {
                        string brand = input[1];
                        string userName = input[2];

                        result = controller.AttractInfluencer(brand, userName);
                    }
                    else if (input[0] == "FundCampaign")
                    {
                        string brand = input[1];
                        double amount = double.Parse(input[2]);

                        result = controller.FundCampaign(brand, amount);
                    }
                    else if (input[0] == "CloseCampaign")
                    {
                        string brand = input[1];

                        result = controller.CloseCampaign(brand);
                    }
                    else if (input[0] == "ConcludeAppContract")
                    {
                        string userName = input[1];

                        result = controller.ConcludeAppContract(userName);
                    }
                    else if (input[0] == "ApplicationReport")
                    {
                        result = controller.ApplicationReport();
                    }
                    writer.WriteLine(result);
                    writer.WriteText(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    writer.WriteText(ex.Message);
                }
            }

        }
    }
}
