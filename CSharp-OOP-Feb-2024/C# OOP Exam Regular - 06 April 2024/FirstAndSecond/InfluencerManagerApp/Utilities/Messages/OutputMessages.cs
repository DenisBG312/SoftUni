namespace InfluencerManagerApp.Utilities.Messages
{
    public class OutputMessages
    {
        //RegiterInfluencer
        public const string InfluencerInvalidType = "{0} has not passed validation.";
        public const string UsernameIsRegistered = "{0} is already registered in {1}.";
        public const string InfluencerRegisteredSuccessfully = "{0} registered successfully to the application.";

        //BeginCampaign
        public const string CampaignTypeIsNotValid = "{0} is not a valid campaign in the application.";
        public const string CampaignDuplicated = "{0} campaign cannot be duplicated.";
        public const string CampaignStartedSuccessfully = "{0} started a {1}.";

        //AttractInfluencer
        public const string InfluencerNotFound = "{0} has no {1} registered in the application.";
        public const string CampaignNotFound = "There is no campaign from {0} in the application.";
        public const string InfluencerNotEligibleForCampaign = "{0} is not eligible for the {1} campaign.";
        public const string UnsufficientBudget = "The budget for {0} is insufficient to engage {1}.";
        public const string InfluencerAttractedSuccessfully = "{0} has been successfully attracted to the {1} campaign.";
        public const string InfluencerAlreadyEngaged = "{0} is already engaged for the {1} campaign.";

        //FundCampaign
        public const string InvalidCampaignToFund = "Trying to fund an invalid campaign.";
        public const string NotPositiveFundingAmount = "Funding amount must be greater than zero.";
        public const string CampaignFundedSuccessfully = "{0} campaign has been successfully funded with {1} $";

        //CloseCampaign
        public const string InvalidCampaignToClose = "Trying to close an invalid campaign.";
        public const string CampaignCannotBeClosed = "{0} campaign cannot be closed as it has not met its financial targets.";
        public const string CampaignClosedSuccessfully = "{0} campaign has reached its target.";

        //ConcludeAppContract
        public const string InfluencerNotSigned = "{0} has still not signed a contract.";
        public const string InfluencerHasActiveParticipations = "{0} cannot conclude the contract while enrolled in active campaigns.";
        public const string ContractConcludedSuccessfully = "{0} concluded their contract.";
    }
}
