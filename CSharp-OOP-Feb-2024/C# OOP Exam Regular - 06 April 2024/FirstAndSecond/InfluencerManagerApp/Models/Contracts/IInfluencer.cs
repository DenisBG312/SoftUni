namespace InfluencerManagerApp.Models.Contracts
{
    public interface IInfluencer
    {
        string Username { get; }

        int Followers { get; }

        double EngagementRate { get; }

        double Income { get; }

        IReadOnlyCollection<string> Participations { get; }


        void EarnFee(double amount);

        void EnrollCampaign(string brand);

        void EndParticipation(string brand);

        int CalculateCampaignPrice();
    }
}
