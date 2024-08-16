namespace SteamPipe.Tests.Models
{
    public class PriceTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""currency"": ""EUR"",
  ""initial"": 2999,
  ""final"": 3999,
  ""discount_percent"": 4,
  ""initial_formatted"": ""$39.00"",
  ""final_formatted"": ""29,99€""
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var price = JsonDeserializer.DeserializeResponse<Price>(response).Body;

            Assert.Equal("EUR", price.Currency);
            Assert.Equal(2999, price.Initial);
            Assert.Equal(3999, price.Final);
            Assert.Equal(4, price.DiscountPercent);
            Assert.Equal("$39.00", price.InitialFormatted);
            Assert.Equal("29,99€", price.FinalFormatted);
        }
    }
}