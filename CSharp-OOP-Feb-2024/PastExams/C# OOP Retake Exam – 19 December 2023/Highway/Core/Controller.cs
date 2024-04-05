using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core
{
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
                return $"{string.Format(OutputMessages.PeakAlreadyAdded, name)}";
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return $"{string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel)}";
            }
            IPeak peak = new Peak(name, elevation, difficultyLevel);

            peaks.Add(peak);
            return $"{string.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository))}";
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.Get(name) != null)
            {
                return $"{string.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository))}";
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

            return $"{string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name)}";
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = climbers.Get(climberName);
            IPeak peak = peaks.Get(peakName);

            if (climber == null)
            {
                return $"{string.Format(OutputMessages.ClimberNotArrivedYet, climberName)}";
            }

            if (peak == null)
            {
                return $"{string.Format(OutputMessages.PeakIsNotAllowed, peakName)}";
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return $"{string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName)}";
            }

            if (peak.DifficultyLevel == "Extreme" && climber is not OxygenClimber)
            {
                return $"{string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName)}";
            }

            baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);
            if (climber.Stamina <= 0)
            {
                return $"{string.Format(OutputMessages.NotSuccessfullAttack, climberName)}";
            }
            
            baseCamp.ArriveAtCamp(climberName);
            return $"{string.Format(OutputMessages.SuccessfulAttack, climberName, peakName)}";
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return $"{string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName)}";
            }

            IClimber climber = climbers.Get(climberName);

            if (climber.Stamina >= 10)
            {
                return $"{string.Format(OutputMessages.NoNeedOfRecovery, climberName)}";
            }

            climber.Rest(daysToRecover);
            return $"{string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover)}";
        }

        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();

            if (baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            sb.AppendLine("BaseCamp residents:");

            foreach (var climberName in baseCamp.Residents.OrderBy(x => x))
            {
                IClimber climber = climbers.Get(climberName);
                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");
            List<IClimber> orderedClimbers = climbers.All
                .OrderByDescending(x => x.ConqueredPeaks.Count)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var climber in orderedClimbers)
            {
                sb.AppendLine(climber.ToString());

                List<IPeak> filteredPeaks = new List<IPeak>();

                foreach (var peak in climber.ConqueredPeaks)
                {
                    IPeak peakCurr = peaks.Get(peak);
                    filteredPeaks.Add(peakCurr);
                }

                foreach (var peak in filteredPeaks
                             .OrderByDescending(x => x.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
