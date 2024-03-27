namespace NauticalCatchChallenge.Models.Contracts
{
    public interface IDiver
    {
        string Name { get; }
        int OxygenLevel { get; }
        IReadOnlyCollection<string> Catch { get; }
        double CompetitionPoints { get; }
        bool HasHealthIssues { get; set; }

        void Hit(IFish fish);
        void Miss(int TimeToCatch);
        void UpdateHealthStatus();
        void RenewOxy();
    }
}
