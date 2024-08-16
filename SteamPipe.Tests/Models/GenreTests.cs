namespace SteamPipe.Tests.Models
{
    public class GenreTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""id"": ""1"",
  ""description"": ""Action""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var genre = JsonDeserializer.DeserializeResponse<Genre>(response).Body;

            Assert.Equal("1", genre.Id);
            Assert.Equal("Action", genre.Description);
        }
    }
}