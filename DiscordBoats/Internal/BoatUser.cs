using DiscordBoats.Models;
using Newtonsoft.Json;

namespace DiscordBoats.Internal
{
    internal class BoatUser : IBoatUser
    {
        [JsonProperty("user_id")]
        public ulong Id { get; internal set; }

        [JsonProperty("user_name")]
        internal string Name { get; set; }

        // Messy patchwork, but it'll do for now
        public string Username => Name.Split('#')[0];
        public string Discriminator => Name.Split('#')[1];

        [JsonProperty("user_website")]
        public string WebsiteUrl { get; internal set; }

        [JsonProperty("user_twitter")]
        public string TwitterId { get; internal set; }

        [JsonProperty("user_github")]
        public string GitHubId { get; internal set; }

        [JsonProperty("user_instagram")]
        public string InstagramId { get; internal set; }

        [JsonProperty("user_reddit")]
        public string RedditId { get; internal set; }

        [JsonProperty("user_bio")]
        public string Biography { get; internal set; }

        [JsonProperty("user_premium")]
        public int PremiumTier { get; internal set; }

        public override string ToString()
            => Name;
    }
}
