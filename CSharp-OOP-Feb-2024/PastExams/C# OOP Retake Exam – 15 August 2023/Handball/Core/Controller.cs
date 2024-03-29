using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using static Handball.Utilities.Messages.OutputMessages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }
        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(TeamAlreadyExists, name, nameof(TeamRepository));
            }
            else
            {
                teams.AddModel(new Team(name));
                return string.Format(TeamSuccessfullyAdded, name, nameof(TeamRepository));
            }
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName is not nameof(Goalkeeper) && typeName is not nameof(CenterBack) &&
                typeName is not nameof(ForwardWing))
            {
                return string.Format(InvalidTypeOfPosition, typeName);
            }

            if (players.ExistsModel(name))
            {
                string position = this.players.GetModel(name).GetType().Name;

                return string.Format(PlayerIsAlreadyAdded, name, nameof(PlayerRepository), position);
            }

            IPlayer player = null;
            if (typeName is nameof(Goalkeeper))
            {
                player = new Goalkeeper(name);
            }
            else if (typeName is nameof(CenterBack))
            {
                player = new CenterBack(name);
            }
            else if (typeName is nameof(ForwardWing))
            {
                player = new ForwardWing(name);
            }
            players.AddModel(player);
            return string.Format(PlayerAddedSuccessfully, name);

        }

        public string NewContract(string playerName, string teamName)
        {

            if (!players.ExistsModel(playerName))
            {
                return string.Format(PlayerNotExisting, playerName, nameof(PlayerRepository));
            }   

            if (!teams.ExistsModel(teamName))
            {
                return string.Format(TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);
            if (player.Team != null)
            {
                return string.Format(PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(SignContract, playerName, teamName);
        }






        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);
            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(GameHasWinner, firstTeamName, secondTeamName);
            }
            else if (secondTeam.OverallRating > firstTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();
                return string.Format(GameHasWinner, secondTeamName, firstTeamName);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(GameIsDraw, firstTeamName, secondTeamName);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = teams.GetModel(teamName);
            List<IPlayer> orderedTeam = team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            foreach (IPlayer player in orderedTeam)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string LeagueStandings()
        {
            List<ITeam> orderedTeams = teams.Models
                .OrderByDescending(x => x.PointsEarned)
                .ThenByDescending(p => p.OverallRating)
                .ThenBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");
            foreach (ITeam orderedTeam in orderedTeams)
            {
                sb.AppendLine(orderedTeam.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
