using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        private List<string> contributors;

        public Campaign(string brand, double budget)
        {
            Brand = brand;
            Budget = budget;
            contributors = new List<string>();
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }
                brand = value;
            }
        }
        public double Budget { get; private set; }
        public IReadOnlyCollection<string> Contributors => contributors.AsReadOnly();
        public void Gain(double amount)
        {
            Budget += amount;
        }

        public void Engage(IInfluencer influencer)
        {
            int campaignPrice = influencer.CalculateCampaignPrice();
            Budget -= campaignPrice;

            contributors.Add(influencer.Username);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {contributors.Count}";
        }
    }
}
