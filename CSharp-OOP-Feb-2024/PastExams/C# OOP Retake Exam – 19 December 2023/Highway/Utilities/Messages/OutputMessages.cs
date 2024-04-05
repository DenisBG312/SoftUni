namespace HighwayToPeak.Utilities.Messages
{
    public class OutputMessages
    {
        //AddPeak
        public const string PeakAlreadyAdded = "{0} is already added as a valid mountain destination.";
        public const string PeakDiffucultyLevelInvalid = "{0} peaks are not allowed for international climbers.";
        public const string PeakIsAllowed = "{0} is allowed for international climbing. See details in {1}.";

        //NewClimberAtCamp
        public const string ClimberCannotBeDuplicated = "{0} is a participant in {1} and cannot be duplicated.";
        public const string ClimberArrivedAtBaseCamp = "{0} has arrived at the BaseCamp and will wait for the best conditions.";

        //AttackPeak
        public const string ClimberNotArrivedYet = "Climber - {0}, has not arrived at the BaseCamp yet.";
        public const string PeakIsNotAllowed = "{0} is not allowed for international climbing.";
        public const string ClimberNotFoundForInstructions = "{0} not found for gearing and instructions. The attack of {1} will be postponed.";
        public const string NotCorrespondingDifficultyLevel = "{0} does not cover the requirements for climbing {1}.";
        public const string NotSuccessfullAttack = "{0} did not return to BaseCamp.";
        public const string SuccessfulAttack = "{0} successfully conquered {1} and returned to BaseCamp.";

        //CampRecovery
        public const string ClimberIsNotAtBaseCamp = "{0} not found at the BaseCamp.";
        public const string NoNeedOfRecovery = "{0} has no need of recovery.";
        public const string ClimberRecovered = "{0} has been recovering for {1} days and is ready to attack the mountain.";
    }
}
