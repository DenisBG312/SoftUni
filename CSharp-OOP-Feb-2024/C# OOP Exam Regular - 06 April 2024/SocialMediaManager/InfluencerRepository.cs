namespace SocialMediaManager
{
    public class InfluencerRepository
    {
        private readonly List<Influencer> data;

        public InfluencerRepository()
        {
            data = new List<Influencer>();
        }

        public IReadOnlyCollection<Influencer> Influencers => data.AsReadOnly();

        public string RegisterInfluencer(Influencer influencer)
        {
            if(influencer == null)
            {
                throw new ArgumentNullException(nameof(influencer), "Influencer is null");
            }

            if(data.Any(i => i.Username == influencer.Username))
            {
                throw new InvalidOperationException($"Influencer with username {influencer.Username} already exists");
            }

            data.Add(influencer);
            return $"Successfully added influencer {influencer.Username} with {influencer.Followers}";
        }

        public bool RemoveInfluencer(string username)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username), "Username cannot be null");
            }

            Influencer influencer = data.FirstOrDefault(i => i.Username == username);
            bool isRemoved = data.Remove(influencer);

            return isRemoved;
        }

        public Influencer GetInfluencerWithMostFollowers()
        {
            Influencer influencer = data.OrderByDescending(i => i.Followers).ToArray()[0];
            return influencer;
        }

        public Influencer GetInfluencer(string username)
        {
            Influencer influencer = data.FirstOrDefault(i => i.Username == username);
            return influencer;
        }
    }
}
