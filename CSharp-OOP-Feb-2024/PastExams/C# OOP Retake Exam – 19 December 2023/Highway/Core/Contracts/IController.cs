namespace HighwayToPeak.Core.Contracts
{
    public interface IController
    {
        string AddPeak(string name, int elevation, string difficultyLevel);
        string NewClimberAtCamp(string name, bool isOxygenUsed);
        string AttackPeak(string climberName, string peakName);
        string CampRecovery(string climberName, int daysToRecover);
        string BaseCampReport();
        string OverallStatistics();
    }
}
