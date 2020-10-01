using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DiscordBoats.Tests
{
    public class ClientTests
    {
        private readonly BoatClient _client;
        private readonly ITestOutputHelper _output;

        public ClientTests(ITestOutputHelper output)
        {
            _output = output;
            _client = new BoatClient(0, "");
        }

        [Fact]
        public async Task Test_CanUpdateGuildCountAsync()
        {
            bool isSuccess = await _client.UpdateGuildCountAsync(54);
            _output.WriteLine($"{isSuccess}");
        }
    }
}
