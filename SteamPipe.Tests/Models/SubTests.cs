namespace SteamPipe.Tests.Models
{
    public class SubTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""packageid"": 197845,
  ""percent_savings_text"": ""test"",
  ""percent_savings"": 12,
  ""option_text"": ""Team Fortress 2 - Commercial License - Free"",
  ""option_description"": ""description"",
  ""can_get_free_license"": ""0"",
  ""is_free_license"": true,
  ""price_in_cents_with_discount"": 8
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var sub = JsonDeserializer.DeserializeResponse<Sub>(response).Body;

            Assert.Equal(197845, sub.PackageId);
            Assert.Equal("test", sub.PercentSavingsText);
            Assert.Equal(12, sub.PercentSavings);
            Assert.Equal("Team Fortress 2 - Commercial License - Free", sub.OptionText);
            Assert.Equal("description", sub.OptionDescription);
            Assert.Equal("0", sub.CanGetFreeLicense);
            Assert.True(sub.IsFreeLicense);
            Assert.Equal(8, sub.PriceInCentsWithDiscount);
        }
    }
}