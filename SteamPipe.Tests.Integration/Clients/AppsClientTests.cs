namespace SteamPipe.Tests.Integration.Clients
{
    public static class AppsClientTests
    {
        public class Methods
        {
            [Fact]
            public async Task GetAppList()
            {
                var steam = Helper.GetAuthClient();

                var response = await steam.Api.GetAppListAsync();
                Assert.NotNull(response);
                Assert.True(response.IsSuccess);

                var appList = response.Body.AppList.Apps;

                Assert.Equal("Counter-Strike: Source", appList.First(x => x.AppId == 240).Name);
            }
        }
    }
}