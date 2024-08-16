namespace SteamPipe.Tests.Models
{
    public class AchievementsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""total"": 520,
  ""highlighted"": [
    {
      ""name"": ""Head of the Class"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_play_game_everyclass.jpg""
    },
    {
      ""name"": ""World Traveler"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_play_game_everymap.jpg""
    },
    {
      ""name"": ""Team Doctor"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_get_healpoints.jpg""
    },
    {
      ""name"": ""Flamethrower"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_burn_playersinminimumtime.jpg""
    },
    {
      ""name"": ""Sentry Gunner"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_get_turretkills.jpg""
    },
    {
      ""name"": ""Nemesis"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_kill_nemesis.jpg""
    },
    {
      ""name"": ""Hard to Kill"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_get_consecutivekills_nodeaths.jpg""
    },
    {
      ""name"": ""Master of Disguise"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_get_healed_byenemy.jpg""
    },
    {
      ""name"": ""With Friends Like these..."",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_play_game_friendsonly.jpg""
    },
    {
      ""name"": ""Dynasty"",
      ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_win_multiplegames.jpg""
    }
  ]
}";
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var achievements = JsonDeserializer.DeserializeResponse<Achievements>(response).Body;

            Assert.Equal(520, achievements.Total);
            Assert.NotEmpty(achievements.Highlighted);
        }
    }
}