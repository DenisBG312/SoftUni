namespace InfluencerManagerApp.Core.Contracts
{
    public interface IController
    {
        string RegisterInfluencer(string typeName, string username, int followers);
        string BeginCampaign(string typeName, string brand);
        string AttractInfluencer(string brand, string username);
        string FundCampaign(string brand, double amount);
        string CloseCampaign(string brand);
        string ConcludeAppContract(string username);
        string ApplicationReport();
    }
}
