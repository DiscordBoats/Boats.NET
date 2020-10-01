using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DiscordBoats.Internal;
using DiscordBoats.Models;

namespace DiscordBoats
{
    public class BoatClient : BaseBoatClient
    {
        public BoatClient(ulong botId, string token)
        {
            BotId = botId;
            Client.DefaultRequestHeaders.Add("Authorization", token);
        }

        protected ulong BotId { get; }

        public async Task<IBoatBot> GetSelfAsync()
        {
            return await GetBotAsync(BotId);
        }

        public string GetWidgetUrl(WidgetImageFormat imageFormat = WidgetImageFormat.Svg)
        {
            return GetWidgetUrl(BotId, imageFormat);
        }

        public async Task<bool> HasVotedAsync(ulong userId)
        {
            return await HasVotedAsync(BotId, userId);
        }

        public async Task<bool> UpdateGuildCountAsync(int guildCount)
        {
            string url = $"{Api.GetBaseUrl()}/{Api.BotEndpoint}/{BotId}";
            string json = JsonConvert.SerializeObject(new CountObject(guildCount));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}
