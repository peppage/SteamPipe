namespace SteamPipe.Tests.Models
{
    public class NewsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""gid"": ""91593954435862753"",
  ""title"": ""UGC League Winter 2017 Season is Starting!"",
  ""url"": ""http://store.steampowered.com/news/externalpost/tf2_blog/91593954435862753"",
  ""is_external_url"": true,
  ""author"": ""test"",
  ""contents"": ""<a href=\""http://www.ugcleague.com/\""> </a> Prepare yourself, the UGC League Winter Season is about to start! Join the thousands of teams that played last season for some competitive TF2 action! The first week of matches starts <b>January 23rd for Highlander, January 25th for 6v6 and January 27th for 4v4.</b> UGC has divisions across North America..."",
  ""feedlabel"": ""TF2 Blog"",
  ""date"": 1483470600,
  ""feedname"": ""tf2_blog""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var news = JsonDeserializer.DeserializeResponse<News>(response).Body;

            Assert.Equal("91593954435862753", news.Gid);
            Assert.Equal("UGC League Winter 2017 Season is Starting!", news.Title);
            Assert.Equal("http://store.steampowered.com/news/externalpost/tf2_blog/91593954435862753", news.Url);
            Assert.True(news.ExternalUrl);
            Assert.Equal("test", news.Author);
            Assert.Equal("<a href=\"http://www.ugcleague.com/\"> </a> Prepare yourself, the UGC League Winter Season is about to start! Join the thousands of teams that played last season for some competitive TF2 action! The first week of matches starts <b>January 23rd for Highlander, January 25th for 6v6 and January 27th for 4v4.</b> UGC has divisions across North America...", news.Contents);
            Assert.Equal("TF2 Blog", news.FeedLabel);
            Assert.Equal((uint)1483470600, news.Epoch);
            Assert.Equal("tf2_blog", news.FeedName);
        }

        [Fact]
        public void EpocConvertedCorrectly()
        {
            const uint epoch = 1674065389; // Wed, 18 Jan 2023 18:09:49 GMT
            var news = new News("", "", epoch, false, "", "", "", "", "");

            Assert.Equal(1, news.Date.Month);
            Assert.Equal(18, news.Date.Day);
            Assert.Equal(2023, news.Date.Year);
        }
    }
}