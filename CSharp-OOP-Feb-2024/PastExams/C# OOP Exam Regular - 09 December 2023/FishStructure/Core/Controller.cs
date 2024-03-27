using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fish;

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver))
            {
                return $"{diverType} is not allowed in our competition.";
            }

            if (divers.GetModel(diverName) != null)
            {
                return $"{diverName} is already a participant -> {nameof(DiverRepository)}.";
            }

            IDiver diver = null;
            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
            }

            divers.AddModel(diver);

            return $"{diverName} is successfully registered for the competition -> {nameof(DiverRepository)}.";
        }



        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != nameof(DeepSeaFish) && fishType != nameof(PredatoryFish) && fishType != nameof(ReefFish))
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }

            if (fish.GetModel(fishName) != null)
            {
                return $"{fishName} is already allowed -> {nameof(FishRepository)}.";
            }

            IFish newFish = null;
            if (fishType == nameof(ReefFish))
            {
                newFish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                newFish = new PredatoryFish(fishName, points);
            }

            fish.AddModel(newFish);
            return $"{fishName} is allowed for chasing.";
        }




        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return $"{nameof(DiverRepository)} has no {diverName} registered for the competition.";
            }

            if (fish.GetModel(fishName) == null)
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            IDiver diver = divers.GetModel(diverName);
            IFish newFish = fish.GetModel(fishName);
            if (diver.OxygenLevel == 0)
            {
                diver.HasHealthIssues = true;
            }
            if (diver.HasHealthIssues)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            if (diver.OxygenLevel < newFish.TimeToCatch)
            {
                diver.Miss(newFish.TimeToCatch);
                return $"{diverName} missed a good {fishName}.";
            }

            else if (diver.OxygenLevel == newFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(newFish);
                    return $"{diverName} hits a {newFish.Points}pt. {fishName}.";
                }
                else
                {
                    diver.Miss(newFish.TimeToCatch);
                    return $"{diverName} missed a good {fishName}.";
                }
            }

            else
            {
                diver.Hit(newFish);
                return $"{diverName} hits a {newFish.Points}pt. {fishName}.";
            }
        }

        public string HealthRecovery()
        {
            List<IDiver> recoveredDivers = new List<IDiver>();
            foreach (var diver in divers.Models)
            {
                diver.HasHealthIssues = false;
                diver.RenewOxy();
                recoveredDivers.Add(diver);
            }

            return $"{string.Format(OutputMessages.DiversRecovered, recoveredDivers.Count)}";
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();
            IDiver diver = divers.GetModel(diverName);

            sb.AppendLine(diver.ToString());

            sb.AppendLine("Catch Report:");

            foreach (var fish in diver.Catch)
            {
                IFish currFish = this.fish.GetModel(fish);
                sb.AppendLine(currFish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            List<IDiver> arrangedDivers = divers.Models
                .OrderByDescending(p => p.CompetitionPoints)
                .ThenByDescending(c => c.Catch.Count)
                .ThenBy(n => n.Name)
                .Where(d => d.OxygenLevel > 0)
                .ToList();

            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (var arrangedDiver in arrangedDivers)
            {
                sb.AppendLine(arrangedDiver.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
