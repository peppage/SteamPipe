namespace SteamPipe.Tests.Integration.Clients
{
    public static class CommunityClientTests
    {
        public class Methods
        {
            [Fact]
            public async Task CommunitySearch()
            {
                var steam = Helper.GetAuthClient();
                var response = await steam.Community.CommunitySearchAsync("Half-Life", "groups");
                Assert.NotNull(response);
                Assert.True(response.IsSuccess);

                var searchResults = response.Body;
                Assert.Equal("Half\\-Life", searchResults.SearchText);
            }
        }
    }
}