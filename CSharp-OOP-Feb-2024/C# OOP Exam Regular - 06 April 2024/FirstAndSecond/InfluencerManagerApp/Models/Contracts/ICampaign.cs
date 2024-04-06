namespace InfluencerManagerApp.Models.Contracts
{
    public interface ICampaign
    {
        string Brand { get; }

        double Budget { get; }

        IReadOnlyCollection<string> Contributors { get; }


        void Gain(double amount);

        void Engage(IInfluencer influencer);
    }
}
