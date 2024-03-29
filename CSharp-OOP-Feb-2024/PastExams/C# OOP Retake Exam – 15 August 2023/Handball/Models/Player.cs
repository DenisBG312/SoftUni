using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using static Handball.Utilities.Messages.ExceptionMessages;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;

        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(PlayerNameNull);
                }
                name = value;
            }
        }

        public double Rating { get; protected set; }

        public string Team { get; private set; }
        public void JoinTeam(string name)
        {
            Team = name;
        }

        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Name}");
            sb.AppendLine($"--Rating: {Rating}");
            return sb.ToString().TrimEnd();
        }
    }
}
