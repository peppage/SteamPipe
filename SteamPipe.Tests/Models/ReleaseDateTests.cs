namespace SteamPipe.Tests.Models
{
    public class ReleaseDateTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""coming_soon"": true,
  ""date"": ""10 Oct, 2007""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var releasedate = JsonDeserializer.DeserializeResponse<ReleaseDate>(response).Body;

            Assert.True(releasedate.ComingSoon);
            Assert.Equal("10 Oct, 2007", releasedate.Date);
        }
    }
}