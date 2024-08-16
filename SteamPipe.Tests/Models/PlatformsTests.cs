namespace SteamPipe.Tests.Models
{
    public class PlatformsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""windows"": true,
  ""mac"": true,
  ""linux"": true
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var platforms = JsonDeserializer.DeserializeResponse<Platforms>(response).Body;

            Assert.True(platforms.Mac);
            Assert.True(platforms.Windows);
            Assert.True(platforms.Linux);
        }
    }
}