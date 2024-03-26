namespace HighwayToPeak.Core
{
    using HighwayToPeak.Core.Contracts;
    using HighwayToPeak.IO.Contracts;
    using HighwayToPeak.IO;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
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

                    if (input[0] == "AddPeak")
                    {
                        string name = input[1];
                        int elevation = int.Parse(input[2]);
                        string difficultyLevel = input[3];

                        result = controller.AddPeak(name, elevation, difficultyLevel);
                    }
                    else if (input[0] == "NewClimberAtCamp")
                    {
                        string name = input[1];
                        bool isOxygenUsed = bool.Parse(input[2]);

                        result = controller.NewClimberAtCamp(name, isOxygenUsed);
                    }
                    else if (input[0] == "AttackPeak")
                    {
                        string climberName = input[1];
                        string peakName = input[2];

                        result = controller.AttackPeak(climberName, peakName);
                    }
                    else if (input[0] == "CampRecovery")
                    {
                        string climberName = input[1];
                        int daysToRecover = int.Parse(input[2]);

                        result = controller.CampRecovery(climberName, daysToRecover);
                    }
                    else if (input[0] == "BaseCampReport")
                    {
                        result = controller.BaseCampReport();
                    }
                    else if (input[0] == "OverallStatistics")
                    {
                        result = controller.OverallStatistics();
                    }
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
