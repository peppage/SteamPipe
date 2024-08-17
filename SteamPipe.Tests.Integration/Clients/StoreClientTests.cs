namespace SteamPipe.Tests.Integration.Clients
{
    public static class StoreClientTests
    {
        public class Methods
        {
            [Fact]
            public async Task GetAppDetails()
            {
                const string requirements = "<strong>Minimum:</strong><br><ul class=\"bb_ul\"><li><strong>OS *:</strong> Windows® 7 (32/64-bit)/Vista/XP<br></li><li><strong>Processor:</strong> 1.7 GHz Processor or better<br></li><li><strong>Memory:</strong> 512 MB RAM<br></li><li><strong>DirectX:</strong> Version 8.1<br></li><li><strong>Network:</strong> Broadband Internet connection<br></li><li><strong>Storage:</strong> 15 GB available space</li></ul>";

                var steam = Helper.GetAuthClient();

                var appDataResp = await steam.Store.AppDetailsAsync(440);
                var appData = appDataResp.Body.Data;
                Assert.Equal("Team Fortress 2", appData.Name);
                Assert.Equal("game", appData.Type);
                Assert.Equal<uint>(440, appData.AppId);
                Assert.True(appData.IsFree);
                Assert.Equal("", appData.RequiredAge);
                Assert.Equal(requirements, appData.PCRequirements?.Minimum);
                Assert.Equal("Valve", appData.Developers[0]);
                Assert.Equal("Valve", appData.Publishers[0]);
            }

            [Fact]
            public async Task MissingRequirements()
            {
                var steam = Helper.GetAuthClient();

                var appDataResp = await steam.Store.AppDetailsAsync(292030);
                var appData = appDataResp.Body.Data;
                Assert.NotNull(appData.PCRequirements);
                Assert.Null(appData.LinuxRequirements);
                Assert.Null(appData.MacRequirements);
            }

            [Fact]
            public async Task Advertisement()
            {
                var steam = Helper.GetAuthClient();

                var appDataResp = await steam.Store.AppDetailsAsync(7740);
                var appData = appDataResp.Body.Data;
                Assert.Equal("advertising", appData.Type);
            }

            [Fact]
            public async Task Failed()
            {
                var steam = Helper.GetAuthClient();
                await Assert.ThrowsAsync<NoSuccessException>(() => steam.Store.AppDetailsAsync(347653));
            }

            [Fact]
            public async Task NothingReturned()
            {
                var steam = Helper.GetAuthClient();
                await Assert.ThrowsAsync<SteamAppException>(() => steam.Store.AppDetailsAsync(2124470));
            }

            [Fact]
            public async Task Film()
            {
                var steam = Helper.GetAuthClient();
                var appDataResp = await steam.Store.AppDetailsAsync(207080);
                var appData = appDataResp.Body.Data;
                Assert.Equal("game", appData.Type);
                Assert.Equal("Indie Game: The Movie", appData.Name);
            }
        }
    }
}