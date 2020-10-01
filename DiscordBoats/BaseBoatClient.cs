using System;
using System.Net.Http;
using System.Threading.Tasks;
using DiscordBoats.Internal;
using DiscordBoats.Models;
using Newtonsoft.Json;

namespace DiscordBoats
{
    public class BaseBoatClient : IDisposable
    {
        public BaseBoatClient()
        {
            Client = new HttpClient();
        }

        protected bool Disposed { get; set; }

        protected HttpClient Client { get; }

        public async Task<IBoatBot> GetBotAsync(ulong id)
        {
            return await GetAsync<BoatBot>($"{Api.BotEndpoint}/{id}");
        }

        public async Task<IBoatUser> GetUserAsync(ulong id)
        {
            return await GetAsync<BoatUser>($"{Api.UserEndpoint}/{id}");
        }

        public string GetWidgetUrl(ulong botId, WidgetImageFormat imageFormat = WidgetImageFormat.Svg)
        {
            return $"{Api.GetBaseUrl()}/widget/{botId}?type={imageFormat.ToString().ToLower()}";
        }

        public async Task<bool> HasVotedAsync(ulong botId, ulong userId)
        {
            return (await GetAsync<VoteObject>($"bot/{botId}/voted?id={userId}")).Voted;
        }

        protected async Task<T> GetAsync<T>(string endpoint)
        {
            string url = $"{Api.GetBaseUrl()}/{endpoint}";
            HttpResponseMessage response = await Client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Remove after testing

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())
                : default;
        }

        public virtual void Dispose()
        {
            if (Disposed)
                return;


            Disposed = true;
        }
    }
}
