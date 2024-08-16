namespace SteamPipe.Tests.Models
{
    public class PackageGroupTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""name"": ""default"",
  ""title"": ""Buy The Witcher® 3: Wild Hunt"",
  ""description"": ""test descript"",
  ""selection_text"": ""Select a purchase option"",
  ""save_text"": ""test save text"",
  ""display_type"": 1,
  ""is_recurring_subscription"": ""false"",
  ""subs"": [
    {
      ""packageid"": 68476,
      ""percent_savings_text"": "" "",
      ""percent_savings"": 0,
      ""option_text"": ""The Witcher 3: Wild Hunt - 29,99€"",
      ""option_description"": """",
      ""can_get_free_license"": ""0"",
      ""is_free_license"": false,
      ""price_in_cents_with_discount"": 2999
    }
  ]
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var subGroup = JsonDeserializer.DeserializeResponse<PackageGroup>(response).Body;

            Assert.Equal("default", subGroup.Name);
            Assert.Equal("Buy The Witcher® 3: Wild Hunt", subGroup.Title);
            Assert.Equal("test descript", subGroup.Description);
            Assert.Equal("Select a purchase option", subGroup.SelectionText);
            Assert.Equal("test save text", subGroup.SaveText);
            Assert.Equal(1, subGroup.DisplayType);
            Assert.Equal("false", subGroup.IsRecurringSubscription);
            Assert.NotEmpty(subGroup.Subs);
        }

        [Fact]
        public void CanBeSerializedWithStringDisplayType()
        {
            const string json = @"{
  ""name"": ""subscriptions"",
  ""title"": ""Buy Chernobyl VR Project Subscription Plan"",
  ""description"": ""To be billed on a recurring basis."",
  ""selection_text"": ""Starting at $19.99 / month"",
  ""save_text"": """",""display_type"": ""1"",
  ""is_recurring_subscription"": ""true"",
  ""subs"": [
    {
      ""packageid"": 165077,
      ""percent_savings_text"": "" "",
      ""percent_savings"": 0,
      ""option_text"": ""$19.99 / month"",
      ""option_description"": ""<p class=\""game_purchase_subscription\"">$19.99 at checkout, auto-renewed every 1 month(s) at $19.99.</p>"",
      ""can_get_free_license"": ""0"",
      ""is_free_license"": false,
      ""price_in_cents_with_discount"": 1999
    }
  ]
}";
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var subGroup = JsonDeserializer.DeserializeResponse<PackageGroup>(response).Body;

            Assert.Equal("subscriptions", subGroup.Name);
            Assert.Equal("Buy Chernobyl VR Project Subscription Plan", subGroup.Title);
            Assert.Equal("To be billed on a recurring basis.", subGroup.Description);
            Assert.Equal("Starting at $19.99 / month", subGroup.SelectionText);
            Assert.Equal(1, subGroup.DisplayType);
            Assert.Equal("true", subGroup.IsRecurringSubscription);
            Assert.NotEmpty(subGroup.Subs);
        }

        [Fact]
        public void IsNull()
        {
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, JsonTokenType.Null);
            var appDetails = JsonDeserializer.DeserializeResponse<PackageGroup>(response);
            Assert.Null(appDetails.Body);
        }

        [Fact]
        public void NotJsonException()
        {
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, "<html>");
            Assert.Throws<SteamPipe.HtmlResponseException>(() => JsonDeserializer.DeserializeResponse<PackageGroup>(response));
        }
    }
}