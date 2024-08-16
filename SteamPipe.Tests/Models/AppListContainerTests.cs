namespace SteamPipe.Tests.Models
{
    public class AppListContainerTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""applist"": {
    ""apps"": [
      {
        ""appid"": 1941401,
        ""name"": """"
      }
    ]
  }
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var appContainer = JsonDeserializer.DeserializeResponse<AppListContainer>(response).Body;

            Assert.NotNull(appContainer);
            Assert.NotNull(appContainer.AppList);
        }
    }
}