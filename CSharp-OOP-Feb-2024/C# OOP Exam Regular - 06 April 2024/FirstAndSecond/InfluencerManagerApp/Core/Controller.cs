using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using Microsoft.VisualBasic.CompilerServices;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }
        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != nameof(BusinessInfluencer)
                && typeName != nameof(FashionInfluencer)
                && typeName != nameof(BloggerInfluencer))
            {
                return $"{string.Format(OutputMessages.InfluencerInvalidType, typeName)}";
            }

            if (influencers.FindByName(username) != null)
            {
                return $"{string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository))}";
            }

            IInfluencer influencer = null;
            if (typeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else if (typeName == nameof(BloggerInfluencer))
            {
                influencer = new BloggerInfluencer(username, followers);
            }

            influencers.AddModel(influencer);

            return $"{string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username)}";
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
            {
                return $"{string.Format(OutputMessages.CampaignTypeIsNotValid, typeName)}";
            }

            if (campaigns.FindByName(brand) != null)
            {
                return $"{string.Format(OutputMessages.CampaignDuplicated, brand)}";
            }

            ICampaign campaign = null;
            if (typeName == nameof(ProductCampaign))
            {
                campaign = new ProductCampaign(brand);
            }
            else if (typeName == nameof(ServiceCampaign))
            {
                campaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(campaign);
            return $"{string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName)}";
        }

        public string AttractInfluencer(string brand, string username)
        {
            if (influencers.FindByName(username) == null)
            {
                return $"{string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username)}";
            }

            if (campaigns.FindByName(brand) == null)
            {
                return $"{string.Format(OutputMessages.CampaignNotFound, brand)}";
            }

            IInfluencer influencer = influencers.FindByName(username);
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign.Contributors.Contains(username))
            {
                return $"{string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand)}";
            }

            if (campaign is ProductCampaign)
            {
                if (influencer is not BusinessInfluencer && influencer is not FashionInfluencer)
                {
                    return $"{string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand)}";
                }
            }
            else if (campaign is ServiceCampaign)
            {
                if (influencer is not BusinessInfluencer && influencer is not BloggerInfluencer)
                {
                    return $"{string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand)}";
                }
            }

            int campaignPrice = influencer.CalculateCampaignPrice();
            if (campaign.Budget < campaignPrice)
            {
                return $"{string.Format(OutputMessages.UnsufficientBudget, brand, username)}";
            }

            influencer.EarnFee(campaignPrice);
            influencer.EnrollCampaign(brand);

            campaign.Engage(influencer);

            return $"{string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand)}";
        }

        public string FundCampaign(string brand, double amount)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return $"{string.Format(OutputMessages.InvalidCampaignToFund)}";
            }

            if (amount <= 0)
            {
                return $"{string.Format(OutputMessages.NotPositiveFundingAmount)}";
            }

            ICampaign campaign = campaigns.FindByName(brand);
            campaign.Gain(amount);
            return $"{string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount)}";
        }

        public string CloseCampaign(string brand)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return $"{string.Format(OutputMessages.InvalidCampaignToClose)}";
            }

            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign.Budget <= 10000)
            {
                return $"{string.Format(OutputMessages.CampaignCannotBeClosed, brand)}";
            }

            foreach (var contributor in campaign.Contributors)
            {
                var influencer = influencers.FindByName(contributor);
                if (influencer != null)
                {
                    influencer.EarnFee(2000);
                    influencer.EndParticipation(brand);
                }
            }

            campaigns.RemoveModel(campaign);
            return $"{string.Format(OutputMessages.CampaignClosedSuccessfully, brand)}";
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            if (influencer == null)
            {
                return $"{string.Format(OutputMessages.InfluencerNotSigned, username)}";
            }

            if (influencer.Participations.Any())
            {
                return $"{string.Format(OutputMessages.InfluencerHasActiveParticipations, username)}";
            }

            influencers.RemoveModel(influencer);
            return $"{string.Format(OutputMessages.ContractConcludedSuccessfully, username)}";
        }

        public string ApplicationReport()
        {
            var orderedInfluencers = influencers.Models
                .OrderByDescending(x => x.Income)
                .ThenByDescending(x => x.Followers);

            StringBuilder sb = new StringBuilder();

            foreach (var influencer in orderedInfluencers)
            {
                sb.AppendLine(influencer.ToString());

                var orderedCampaigns = campaigns.Models.Where(c => influencer.Participations.Contains(c.Brand)).OrderBy(c => c.Brand);
                if (orderedCampaigns.Any())
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var campaign in orderedCampaigns)
                    {
                        sb.AppendLine($"--{campaign.ToString()}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
