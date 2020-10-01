using Xunit;
using System.Threading.Tasks;
using DiscordBoats.Models;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace DiscordBoats.Tests
{
    public class BaseClientTests
    {
        private readonly BaseBoatClient _client;
        private readonly ITestOutputHelper _output;

        public BaseClientTests(ITestOutputHelper output)
        {
            _output = output;
            _client = new BaseBoatClient();
        }

        [Fact]
        public async Task Test_BotExistsAsync()
        {
            IBoatBot bot = await _client.GetBotAsync(632293976661164052);
            Assert.NotNull(bot);
            _output.WriteLine(JsonConvert.SerializeObject(bot));
        }

        [Fact]
        public async Task Test_UserExistsAsync()
        {
            IBoatUser user = await _client.GetUserAsync(280158289667555328);
            Assert.NotNull(user);
            _output.WriteLine(JsonConvert.SerializeObject(user));
        }

        [Fact]
        public async Task Test_CheckVoteAsync()
        {
            bool hasVoted = await _client.HasVotedAsync(632293976661164052, 280158289667555328);
            _output.WriteLine($"{hasVoted}");
        }
    }
}
