namespace SteamPipe.Tests.Models
{
    public class CategoryTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""id"": 1,
  ""description"": ""Multi-player""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var category = JsonDeserializer.DeserializeResponse<Category>(response).Body;

            Assert.Equal(1, category.Id);
            Assert.Equal("Multi-player", category.Description);
        }
    }
}