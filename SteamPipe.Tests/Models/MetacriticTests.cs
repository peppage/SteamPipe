namespace SteamPipe.Tests.Models
{
    public class MetacriticTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""score"": 92,
  ""url"": ""https://www.metacritic.com/game/pc/team-fortress-2?ftag=MCD-06-10aaa1f""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var metacritic = JsonDeserializer.DeserializeResponse<Metacritic>(response).Body;

            Assert.Equal(92, metacritic.Score);
            Assert.Equal("https://www.metacritic.com/game/pc/team-fortress-2?ftag=MCD-06-10aaa1f", metacritic.Url);
        }
    }
}