namespace SteamPipe.Tests.Models
{
    public class AppNewsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
    ""appid"": 440,
    ""newsitems"": [
      {
        ""gid"": ""91593954435862753"",
        ""title"": ""UGC League Winter 2017 Season is Starting!"",
        ""url"": ""http://store.steampowered.com/news/externalpost/tf2_blog/91593954435862753"",
        ""is_external_url"": true,
        ""author"": """",
        ""contents"": ""<a href=\""http://www.ugcleague.com/\""> </a> Prepare yourself, the UGC League Winter Season is about to start! Join the thousands of teams that played last season for some competitive TF2 action! The first week of matches starts <b>January 23rd for Highlander, January 25th for 6v6 and January 27th for 4v4.</b> UGC has divisions across North America..."",
        ""feedlabel"": ""TF2 Blog"",
        ""date"": 1483470600,
        ""feedname"": ""tf2_blog""
      },
      {
        ""gid"": ""91593954391732173"",
        ""title"": ""Good will to all teams in TF2 s new autobalancing"",
        ""url"": ""http://store.steampowered.com/news/externalpost/rps/91593954391732173"",
        ""is_external_url"": true,
        ""author"": ""contact@rockpapershotgun.com (Alice O'Connor)"",
        ""contents"": """",
        ""feedlabel"": ""Rock, Paper, Shotgun"",
        ""date"": 1482417561,
        ""feedname"": ""rps""
      }
    ],
    ""count"":32
  }";
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var appNews = JsonDeserializer.DeserializeResponse<AppNews>(response).Body;

            Assert.Equal((uint)440, appNews.AppId);
            Assert.NotEmpty(appNews.NewsItems);
            Assert.Equal(32, appNews.Count);
        }
    }
}