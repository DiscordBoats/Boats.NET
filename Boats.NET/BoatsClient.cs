using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Boats.NET.Entities;
using System.Threading.Tasks;

namespace Boats.NET
{
    public class BoatsClient: IDisposable
    {
        private readonly string _key;
        private static string _version = "v2";
        private string _baseUrl = $"https://discord.boats/api/{_version}";
        private bool disposed = false;
        private HttpClient _client = new HttpClient();

        public BoatsClient(string token)
        {
            _key = token;
        }

        public async Task<BotEntity> GetBot(string id)
        {
            Uri uri = new Uri($"{_baseUrl}/bot/{id}");
            HttpResponseMessage res = await _client.GetAsync(uri);
            res.EnsureSuccessStatusCode();

            string req = await res.Content.ReadAsStringAsync();
            BotEntity result = JsonConvert.DeserializeObject<BotEntity>(req);

            return result;
        }

        public async Task<bool> PostStatistics(string id, int servercount)
        {
            Uri uri = new Uri($"{_baseUrl}/bot/{id}");
            _client.DefaultRequestHeaders.Add("Authorization", _key);
            HttpResponseMessage res = await _client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(new ServerCount(servercount)), Encoding.UTF8, "application/json"));
            res.EnsureSuccessStatusCode();

            if (res.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<NormalUserEntity> GetUser(string username)
        {
            Uri uri = new Uri($"{_baseUrl}/user/{username}");
            HttpResponseMessage res = await _client.GetAsync(uri);
            res.EnsureSuccessStatusCode();
            
            string req = await res.Content.ReadAsStringAsync();
            NormalUserEntity entity = JsonConvert.DeserializeObject<NormalUserEntity>(req);

            return entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    internal class ServerCount
    {
        private int server_count;

        public ServerCount(int count)
        {
            server_count = count;
        }
    }
}