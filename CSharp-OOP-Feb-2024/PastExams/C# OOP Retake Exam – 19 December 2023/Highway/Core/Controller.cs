namespace HighwayToPeak.Core
{
    using HighwayToPeak.Core.Contracts;
    using HighwayToPeak.Models;
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Repositories;
    using HighwayToPeak.Repositories.Contracts;
    using HighwayToPeak.Utilities.Messages;
    using System;
    using System.Text;

    public class Controller : IController
    {

        private IRepository<IPeak> peaks;
        private IRepository<IClimber> climbers;
        private IBaseCamp baseCamp;

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.Get(name) != null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            IPeak peak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(peak);

            return string.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository));
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (climbers.Get(climberName) == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (peaks.Get(peakName) == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            IClimber climber = climbers.Get(climberName);
            IPeak peak = peaks.Get(peakName);

            if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == nameof(NaturalClimber))
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }

            baseCamp.ArriveAtCamp(climberName);
            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();

            if (baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            sb.AppendLine("BaseCamp residents:");

            foreach (var climberName in baseCamp.Residents)
            {
                IClimber climber = climbers.Get(climberName);
                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = climbers.Get(climberName);

            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            climber.Rest(daysToRecover);
            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.Get(name) != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));
            }

            IClimber climber;

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count).ThenBy(c => c.Name))
            {
                sb.AppendLine(climber.ToString().TrimEnd());
                List<IPeak> filteredPeaks = new List<IPeak>();

                foreach (var peak in climber.ConqueredPeaks)
                {
                    IPeak temp = peaks.Get(peak);
                    filteredPeaks.Add(temp);
                }

                foreach (var peak in filteredPeaks.OrderByDescending(p => p.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
