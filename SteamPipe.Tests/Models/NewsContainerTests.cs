namespace SteamPipe.Tests.Models
{
    public class NewsContainerTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""appnews"": {
    ""appid"": 1366540,
    ""newsitems"": [
      {
        ""gid"": ""5000716037492774876"",
        ""title"": ""Dyson Sphere Program Patch Notes Version 0.9.27.15466"",
        ""url"": ""https://steamstore-a.akamaihd.net/news/externalpost/steam_community_announcements/5000716037492774876"",
        ""is_external_url"": true,
        ""author"": ""Mien"",
        ""contents"": ""test content"",
        ""feedlabel"": ""Community Announcements"",
        ""date"": 1672909448,
        ""feedname"": ""steam_community_announcements"",
        ""feed_type"": 1,
        ""appid"": 1366540
      }
    ],
    ""count"": 111
  }
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var newsContainer = JsonDeserializer.DeserializeResponse<NewsContainer>(response).Body;

            Assert.NotNull(newsContainer.AppNews);
        }
    }
}