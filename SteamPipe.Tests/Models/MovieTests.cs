namespace SteamPipe.Tests.Models
{
    public class MovieTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""id"": 256698790,
  ""name"": ""Jungle Inferno"",
  ""thumbnail"": ""https://cdn.akamai.steamstatic.com/steam/apps/256698790/movie.293x165.jpg?t=1659929753"",
  ""webm"": {
    ""480"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie480.webm?t=1659929753"",
    ""max"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie_max.webm?t=1659929753""
  },
  ""mp4"": {
    ""480"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie480.mp4?t=1659929753"",
    ""max"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie_max.mp4?t=1659929753""
  },
  ""highlight"": true
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var movie = JsonDeserializer.DeserializeResponse<Movie>(response).Body;

            Assert.Equal(256698790, movie.Id);
            Assert.Equal("Jungle Inferno", movie.Name);
            Assert.Equal("https://cdn.akamai.steamstatic.com/steam/apps/256698790/movie.293x165.jpg?t=1659929753", movie.Thumbnail);
            Assert.True(movie.Highlight);
            Assert.NotNull(movie.Webm);
            Assert.NotNull(movie.Mp4);
        }
    }
}