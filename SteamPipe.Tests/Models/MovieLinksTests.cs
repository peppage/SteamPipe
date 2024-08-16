namespace SteamPipe.Tests.Models
{
    public class MovieLinksTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""480"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie480.webm?t=1659929753"",
  ""max"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie_max.webm?t=1659929753""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var links = JsonDeserializer.DeserializeResponse<MovieLinks>(response).Body;

            Assert.Equal("http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie480.webm?t=1659929753", links.Resolution480);
            Assert.Equal("http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie_max.webm?t=1659929753", links.ResolutionMax);
        }

        [Fact]
        public void IsNull()
        {
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, JsonTokenType.Null);
            var appDetails = JsonDeserializer.DeserializeResponse<MovieLinks>(response);
            Assert.Null(appDetails.Body);
        }

        [Fact]
        public void NotJsonException()
        {
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, "<html>");
            Assert.Throws<SteamPipe.HtmlResponseException>(() => JsonDeserializer.DeserializeResponse<MovieLinks>(response));
        }
    }
}