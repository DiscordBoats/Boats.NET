using Newtonsoft.Json;

namespace DiscordBoats.Internal
{
    internal class CountObject
    {
        [JsonConstructor]
        public CountObject(int serverCount)
        {
            ServerCount = serverCount;
        }

        [JsonProperty("server_count")]
        internal int ServerCount { get; }
    }
}
