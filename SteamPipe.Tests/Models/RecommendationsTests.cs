namespace SteamPipe.Tests.Models
{
    public class RecommendationsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""total"": 17152
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var recommendation = JsonDeserializer.DeserializeResponse<Recommendations>(response).Body;

            Assert.Equal(17152, recommendation.Total);
        }
    }
}