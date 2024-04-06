namespace SocialMediaManager
{
    public class Influencer
    {
        public Influencer(string username, int followers)
        {
            Username = username;
            Followers = followers;
        }

        public string Username{ get; }

        public int Followers { get; }
    }
}
