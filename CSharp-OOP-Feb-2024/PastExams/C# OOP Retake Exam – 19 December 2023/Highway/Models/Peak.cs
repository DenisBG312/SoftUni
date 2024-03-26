using HighwayToPeak.Models.Contracts;
namespace HighwayToPeak.Models
{
    using HighwayToPeak.Utilities.Messages;
    public class Peak : IPeak
    {
        private string name;
        private int elevation;
        private string difficultyLevel;

        public Peak(string name, int elevation, string difficultyLevel)
        {
            Name = name;
            Elevation = elevation;
            DifficultyLevel = difficultyLevel;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Elevation
        {
            get => elevation;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                }
                elevation = value;
            }
        }

        public string DifficultyLevel
        {
            get => difficultyLevel;
            private set
            {
                difficultyLevel = value;
            }
        }


        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}