namespace DiscordBoats.Models
{
    public interface IBoatUser : IBoatEntity
    {
        string Discriminator { get; }

        string WebsiteUrl { get; }

        string TwitterId { get; }

        string GitHubId { get; }

        string InstagramId { get; }

        string RedditId { get; }

        string Biography { get; }

        int PremiumTier { get; }
    }
}
