using System.Collections.Generic;
using DiscordBoats.Models;
using Newtonsoft.Json;

namespace DiscordBoats.Internal
{
    internal class BoatBot : IBoatBot
    {
        [JsonProperty("bot_id")]
        public ulong Id { get; internal set; }

        [JsonProperty("bot_name")]
        public string Username { get; internal set; }

        [JsonProperty("bot_prefix")]
        public string Prefix { get; internal set; }

        [JsonProperty("bot_library")]
        public string Library { get; internal set; }

        [JsonProperty("bot_avatar")]
        public string AvatarUrl { get; internal set; }

        [JsonProperty("bot_short_desc")]
        public string ShortDescription { get; internal set; }

        [JsonProperty("bot_long_desc")]
        public string LongDescription { get; internal set; }

        [JsonProperty("bot_owners")]
        internal List<ulong> OwnerIds { get; set; }

        IReadOnlyList<ulong> IBoatBot.OwnerIds => OwnerIds;

        [JsonProperty("bot_invite_link")]
        public string InviteUrl { get; internal set; }

        [JsonProperty("bot_support_discord")]
        public string SupportGuildUrl { get; internal set; }

        [JsonProperty("bot_website")]
        public string WebsiteUrl { get; internal set; }

        [JsonProperty("bot_github_repo")]
        public string RepositoryUrl { get; internal set; }

        [JsonProperty("bot_server_count")]
        internal string RawServerCount { get; set; }

        public ulong ServerCount => RawServerCount == null ? 0 : ulong.Parse(RawServerCount);

        [JsonProperty("bot_vote_count")]
        public ulong VoteCount { get; internal set; }

        [JsonProperty("bot_vanity_url")]
        public string VanityUrl { get; internal set; }

        [JsonProperty("bot_visible")]
        public VisibleStatus Visiblity { get; internal set; }

        [JsonProperty("bot_in_queue")]
        public bool IsQueued { get; internal set; }

        [JsonProperty("bot_certified")]
        public bool IsCertified { get; internal set; }


        [JsonProperty("bot_categories")]
        internal List<string> Categories { get; set; }

        IReadOnlyList<string> IBoatBot.Categories => Categories;

        [JsonProperty("bot_rate_one")]
        internal int OneStarRatingCount { get; set; }

        [JsonProperty("bot_rate_two")]
        internal int TwoStarRatingCount { get; set; }

        [JsonProperty("bot_rate_three")]
        internal int ThreeStarRatingCount { get; set; }

        [JsonProperty("bot_rate_four")]
        internal int FourStarRatingCount { get; set; }

        [JsonProperty("bot_rate_five")]
        internal int FiveStarRatingCount { get; set; }

        public IReadOnlyList<Rating> Ratings => GetRatings();

        [JsonProperty("bot_rate_average")]
        public float AverageRating { get; internal set; }

        private List<Rating> GetRatings()
        {
            return new List<Rating>
            {
                new Rating(1, OneStarRatingCount),
                new Rating(2, TwoStarRatingCount),
                new Rating(3, ThreeStarRatingCount),
                new Rating(4, FourStarRatingCount),
                new Rating(5, FiveStarRatingCount)
            };
        }
    }
}
