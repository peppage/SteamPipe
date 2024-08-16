namespace SteamPipe.Tests
{
    public static class SteamClientTests
    {
        public class TheApiKeyProperty
        {
            [Fact]
            public void ApiKeyIsSaved()
            {
                const string key = "asedf";
                var client = new SteamClient();
                client.SetApiKey(key);
                Assert.Same(key, client.ApiKey);
            }
        }

        public class TheBaseAddressProperty
        {
            [Fact]
            public void IsSetToSteam()
            {
                var client = new SteamClient();
                Assert.Equal(new Uri("https://api.steampowered.com/"), client.BaseApiAddress);
                Assert.Equal(new Uri("https://store.steampowered.com/"), client.BaseStoreAddress);
            }
        }
    }
}