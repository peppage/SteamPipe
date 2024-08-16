namespace SteamPipe.Tests.Integration
{
    public static class Helper
    {
        private static Lazy<string> SteamDevApiKeyLazy => new(() => Environment.GetEnvironmentVariable("KETTLE_APIKEY"));

        public static string SteamDevApiKey => SteamDevApiKeyLazy.Value;

        public static ISteamClient GetAuthClient()
        {
            var client = new SteamClient();
            client.SetApiKey(SteamDevApiKey);
            return client;
        }
    }
}