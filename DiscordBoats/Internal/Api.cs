namespace DiscordBoats.Internal
{
    internal static class Api
    {
        internal static readonly int MaxRequestsPerMinute = 50;
        internal static readonly string BaseUrl = "https://discord.boats/api";
        internal static readonly string BotEndpoint = "bot";
        internal static readonly string UserEndpoint = "user";
        internal static readonly int CurrentVersion = 2;

        internal static string GetBaseUrl()
            => $"{BaseUrl}/v{CurrentVersion}";
    }
}
