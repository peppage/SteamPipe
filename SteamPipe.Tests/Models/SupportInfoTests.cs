namespace SteamPipe.Tests.Models
{
    public class SupportInfoTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""url"": ""http://steamcommunity.com/app/440"",
  ""email"": ""test@test.com""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var supportInfo = JsonDeserializer.DeserializeResponse<SupportInfo>(response).Body;

            Assert.Equal("http://steamcommunity.com/app/440", supportInfo.Url);
            Assert.Equal("test@test.com", supportInfo.Email);
        }
    }
}