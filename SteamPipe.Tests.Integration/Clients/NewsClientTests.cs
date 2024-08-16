namespace SteamPipe.Tests.Integration.Clients
{
    public static class NewsClientTests
    {
        public class Methods
        {
            [Fact]
            public async Task GetNews()
            {
                var steam = Helper.GetAuthClient();

                var response = await steam.Api.GetNewsAsync(440, count: 1);

                Assert.True(response.IsSuccess);

                var appNews = response.Body.AppNews;

                Assert.Equal((uint)440, appNews.AppId);
                Assert.NotEqual(0, appNews.Count);
                Assert.NotEmpty(appNews.NewsItems);

                var news = appNews.NewsItems[0];

                Assert.NotEqual("", news.Title);
                Assert.NotEqual("", news.Contents);
            }
        }
    }
}