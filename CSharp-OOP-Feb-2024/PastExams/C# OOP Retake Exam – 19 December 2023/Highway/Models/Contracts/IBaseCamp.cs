namespace HighwayToPeak.Models.Contracts
{
    public interface IBaseCamp
    {
        IReadOnlyCollection<string> Residents { get; }

        void ArriveAtCamp(string climberName);

        void LeaveCamp(string climberName);
    }
}
