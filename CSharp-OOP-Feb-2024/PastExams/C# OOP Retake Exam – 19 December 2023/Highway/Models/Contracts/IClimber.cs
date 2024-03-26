namespace HighwayToPeak.Models.Contracts
{
    public interface IClimber
    {
        string Name { get; }

        int Stamina { get; }

        IReadOnlyCollection<string> ConqueredPeaks { get; }

        void Climb(IPeak peak);

        abstract void Rest(int daysCount);
    }
}
