namespace SteamPipe.Tests.Models
{
    public class ContentDescriptorsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
    ""ids"": [
      2,
      5
    ],
    ""notes"": ""Includes cartoon violence and gore.""
  }";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var content = JsonDeserializer.DeserializeResponse<ContentDescriptors>(response).Body;

            Assert.Equal(2, content.Ids[0]);
            Assert.Equal("Includes cartoon violence and gore.", content.Notes);
        }
    }
}