namespace HighwayToPeak.Models.Contracts
{
    public interface IPeak
    {
        string Name { get; }

        int Elevation { get; }

        string DifficultyLevel { get; }
    }
}
