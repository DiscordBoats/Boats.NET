using Newtonsoft.Json;

namespace DiscordBoats.Internal
{
    internal class VoteObject
    {
        [JsonProperty("voted")]
        internal bool Voted { get; set; }
    }
}
