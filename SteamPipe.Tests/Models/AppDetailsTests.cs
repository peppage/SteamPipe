namespace SteamPipe.Tests.Models
{
    public class AppDetailsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""292030"": {
    ""success"": true,
    ""data"": {
      ""type"": ""game"",
      ""name"": ""The Witcher® 3: Wild Hunt"",
      ""steam_appid"": 292030,
      ""required_age"": 0,
      ""is_free"": true,
      ""controller_support"": ""full"",
      ""dlc"": [
        355880
      ],
      ""detailed_description"": ""<h1>Check out other games from CD PROJEKT RED</h1><p><a href=\""https://store.steampowered.com/app/1091500\"" target=\""_blank\"" rel=\""\""  i"",
      ""about_the_game"": ""THE MOST AWARDED GAME OF A GENERATION<br>NOW ENHANCED FOR THE NEXT<br><br><img src=\""https://cdn.akamai.steamstatic.com/steam/apps/292030/extras/ABOUT_600x225_EN.png?t=1673427135\"" /><br><br>You are Geralt of Rivia, mercenary monster slayer. Before you"",
      ""short_description"": ""You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world."",
      ""supported_languages"": ""English<strong>*</strong>, French<strong>*</strong>, Italian, German<strong>*</strong>, Spanish - Spain, Arabic, Czech, Hungarian, Japanese<strong>*</strong>, Korean<strong>*</strong>, Polish<strong>*</strong>, Portuguese - Brazil<strong>*</strong>, Russian<strong>*</strong>, Traditional Chinese, Turkish, Simplified Chinese<strong>*</strong><br><strong>*</strong>languages with full audio support"",
      ""reviews"": ""“ONE OF THE BEST GAMES EVER MADE”<br>10/10 – <a href=\""https://steamcommunity.com/linkfilter/?url=http://www.gamespot.com/reviews/the-witcher-3-wild-hunt-review/1900-6416135/\"" target=\""_blank\"" rel=\"" noopener\""  >GameSpot</a><br><br>“AMAZING”<br>9.3/10 – <a href=\""http://uk.ign.com/articles/2015/05/12/the-witcher-3-the-wild-hunt-review\"" target=\""_blank\"" rel=\""\""  >IGN</a><br><br>“ONE OF THE BEST RPGs EVER MADE”<br>9.8/10 – <a href=\""http://www.gametrailers.com/reviews/j9qz9m/the-witcher-3--wild-hunt-review\"" target=\""_blank\"" rel=\""\""  >Game Trailers</a><br>"",
      ""header_image"": ""https://cdn.akamai.steamstatic.com/steam/apps/292030/header.jpg?t=1673427135"",
      ""website"": ""http://www.thewitcher.com"",
      ""pc_requirements"": {
        ""minimum"": ""<strong>Minimum:</strong><br><ul class=\""bb_ul\""><li><strong>OS:</strong> 64-bit Windows 7, 64-bit Windows 8 (8.1)<br></li><li><strong>Processor:</strong> Intel CPU Core i5-2500K 3.3GHz / AMD A10-5800K APU (3.8GHz)<br></li><li><strong>Memory:</strong> 6 GB RAM<br></li><li><strong>Graphics:</strong> Nvidia GPU GeForce GTX 660 / AMD GPU Radeon HD 7870<br></li><li><strong>DirectX:</strong> Version 11<br></li><li><strong>Storage:</strong> 50 GB available space</li></ul>"",
        ""recommended"": ""<strong>Recommended:</strong><br><ul class=\""bb_ul\""><li><strong>OS:</strong> 64-bit Windows 10/11<br></li><li><strong>Processor:</strong> Intel Core i5-7400 / Ryzen 5 1600<br></li><li><strong>Memory:</strong> 8 GB RAM<br></li><li><strong>Graphics:</strong> Nvidia GTX 1070 / Radeon RX 480<br></li><li><strong>DirectX:</strong> Version 12<br></li><li><strong>Storage:</strong> 50 GB available space</li></ul>""
      },
      ""mac_requirements"": [],
      ""linux_requirements"": [],
      ""legal_notice"": ""CD PROJEKT®, The Witcher® are registered trademarks of CD PROJEKT Capital Group. The Witcher game © CD PROJEKT S.A. Developed by CD PROJEKT S.A. All rights reserved. The Witcher game is set in the universe created by Andrzej Sapkowski in his series of books. All other copyrights and trademarks are the property of their respective owners."",
      ""developers"": [
        ""CD PROJEKT RED""
      ],
      ""publishers"": [
        ""CD PROJEKT RED PUB""
      ],
      ""price_overview"": {
        ""currency"": ""USD"",
        ""initial"": 3999,
        ""final"": 3999,
        ""discount_percent"": 0,
        ""initial_formatted"": """",
        ""final_formatted"": ""$39.99""
      },
      ""packages"": [
        68476
      ],
      ""package_groups"": [
        {
          ""name"": ""default"",
          ""title"": ""Buy The Witcher® 3: Wild Hunt"",
          ""description"": """",
          ""selection_text"": ""Select a purchase option"",
          ""save_text"": """",
          ""display_type"": 0,
          ""is_recurring_subscription"": ""false"",
          ""subs"": [
            {
              ""packageid"": 68476,
              ""percent_savings_text"": "" "",
              ""percent_savings"": 0,
              ""option_text"": ""The Witcher 3: Wild Hunt - $39.99"",
              ""option_description"": """",
              ""can_get_free_license"": ""0"",
              ""is_free_license"": false,
              ""price_in_cents_with_discount"": 3999
            }
          ]
        }
      ],
      ""platforms"": {
        ""windows"": true,
        ""mac"": false,
        ""linux"": false
      },
      ""metacritic"": {
        ""score"": 93,
        ""url"": ""https://www.metacritic.com/game/pc/the-witcher-3-wild-hunt?ftag=MCD-06-10aaa1f""
      },
      ""categories"": [
        {
          ""id"": 2,
          ""description"": ""Single-player""
        }
      ],
      ""genres"": [
        {
          ""id"": ""3"",
          ""description"": ""RPG""
        }
      ],
      ""screenshots"": [
        {
          ""id"": 0,
          ""path_thumbnail"": ""https://cdn.akamai.steamstatic.com/steam/apps/292030/ss_5710298af2318afd9aa72449ef29ac4a2ef64d8e.600x338.jpg?t=1673427135"",
          ""path_full"": ""https://cdn.akamai.steamstatic.com/steam/apps/292030/ss_5710298af2318afd9aa72449ef29ac4a2ef64d8e.1920x1080.jpg?t=1673427135""
        }
      ],
      ""movies"": [
        {
          ""id"": 256920684,
          ""name"": ""W3NG ESRB The Witcher 3: Wild Hunt - Reveal"",
          ""thumbnail"": ""https://cdn.akamai.steamstatic.com/steam/apps/256920684/movie.293x165.jpg?t=1670976373"",
          ""webm"": {
            ""480"": ""http://cdn.akamai.steamstatic.com/steam/apps/256920684/movie480_vp9.webm?t=1670976373"",
            ""max"": ""http://cdn.akamai.steamstatic.com/steam/apps/256920684/movie_max_vp9.webm?t=1670976373""
          },
          ""mp4"": {
            ""480"": ""http://cdn.akamai.steamstatic.com/steam/apps/256920684/movie480.mp4?t=1670976373"",
            ""max"": ""http://cdn.akamai.steamstatic.com/steam/apps/256920684/movie_max.mp4?t=1670976373""
          },
          ""highlight"": true
        }
      ],
      ""recommendations"": {
        ""total"": 643804
      },
      ""achievements"": {
        ""total"": 78,
        ""highlighted"": [
          {
            ""name"": ""Lilac and Gooseberries"",
            ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/292030/6078587189483353f06f48d0eefdaaa0791e9e13.jpg""
          }
        ]
      },
      ""release_date"": {
        ""coming_soon"": false,
        ""date"": ""May 18, 2015""
      },
      ""support_info"": {
        ""url"": ""http://en.cdprojektred.com/support"",
        ""email"": ""http://en.cdprojektred.com/contact-support/""
      },
      ""background"": ""https://cdn.akamai.steamstatic.com/steam/apps/292030/page_bg_generated_v6b.jpg?t=1673427135"",
      ""background_raw"": ""https://cdn.akamai.steamstatic.com/steam/apps/292030/page.bg.jpg?t=1673427135"",
      ""content_descriptors"": {
        ""ids"": [
          1,
          5
        ],
        ""notes"": null
      }
    }
  }
}";

            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, json);
            var appDetails = JsonDeserializer.DeserializeResponse<AppDetails>(response).Body;

            Assert.True(appDetails.Success);
            Assert.NotNull(appDetails.Data);
            Assert.Equal("game", appDetails.Data.Type);
            Assert.Equal("The Witcher® 3: Wild Hunt", appDetails.Data.Name);
            Assert.Equal((uint)292030, appDetails.Data.AppId);
            Assert.True(appDetails.Data.IsFree);
            Assert.Equal("full", appDetails.Data.ControllerSupport);
            Assert.NotEmpty(appDetails.Data.Dlc);
            Assert.Equal((uint)355880, appDetails.Data.Dlc[0]);
            Assert.Equal("<h1>Check out other games from CD PROJEKT RED</h1><p><a href=\"https://store.steampowered.com/app/1091500\" target=\"_blank\" rel=\"\"  i", appDetails.Data.DetailedDescription);
            Assert.Equal("THE MOST AWARDED GAME OF A GENERATION<br>NOW ENHANCED FOR THE NEXT<br><br><img src=\"https://cdn.akamai.steamstatic.com/steam/apps/292030/extras/ABOUT_600x225_EN.png?t=1673427135\" /><br><br>You are Geralt of Rivia, mercenary monster slayer. Before you", appDetails.Data.AboutTheGame);
            Assert.Equal("You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world.", appDetails.Data.ShortDescription);
            Assert.Equal("English<strong>*</strong>, French<strong>*</strong>, Italian, German<strong>*</strong>, Spanish - Spain, Arabic, Czech, Hungarian, Japanese<strong>*</strong>, Korean<strong>*</strong>, Polish<strong>*</strong>, Portuguese - Brazil<strong>*</strong>, Russian<strong>*</strong>, Traditional Chinese, Turkish, Simplified Chinese<strong>*</strong><br><strong>*</strong>languages with full audio support", appDetails.Data.SupportedLanguages);
            Assert.Equal("“ONE OF THE BEST GAMES EVER MADE”<br>10/10 – <a href=\"https://steamcommunity.com/linkfilter/?url=http://www.gamespot.com/reviews/the-witcher-3-wild-hunt-review/1900-6416135/\" target=\"_blank\" rel=\" noopener\"  >GameSpot</a><br><br>“AMAZING”<br>9.3/10 – <a href=\"http://uk.ign.com/articles/2015/05/12/the-witcher-3-the-wild-hunt-review\" target=\"_blank\" rel=\"\"  >IGN</a><br><br>“ONE OF THE BEST RPGs EVER MADE”<br>9.8/10 – <a href=\"http://www.gametrailers.com/reviews/j9qz9m/the-witcher-3--wild-hunt-review\" target=\"_blank\" rel=\"\"  >Game Trailers</a><br>", appDetails.Data.Reviews);
            Assert.Equal("https://cdn.akamai.steamstatic.com/steam/apps/292030/header.jpg?t=1673427135", appDetails.Data.HeaderImage);
            Assert.Equal("http://www.thewitcher.com", appDetails.Data.Website);
            Assert.NotNull(appDetails.Data.PCRequirements);
            Assert.Null(appDetails.Data.MacRequirements);
            Assert.Null(appDetails.Data.LinuxRequirements);
            Assert.Equal("CD PROJEKT®, The Witcher® are registered trademarks of CD PROJEKT Capital Group. The Witcher game © CD PROJEKT S.A. Developed by CD PROJEKT S.A. All rights reserved. The Witcher game is set in the universe created by Andrzej Sapkowski in his series of books. All other copyrights and trademarks are the property of their respective owners.", appDetails.Data.LegalNotice);
            Assert.NotEmpty(appDetails.Data.Developers);
            Assert.Equal("CD PROJEKT RED", appDetails.Data.Developers[0]);
            Assert.NotEmpty(appDetails.Data.Publishers);
            Assert.Equal("CD PROJEKT RED PUB", appDetails.Data.Publishers[0]);
            Assert.NotNull(appDetails.Data.PriceOverview);
            Assert.NotEmpty(appDetails.Data.Packages);
            Assert.Equal((uint)68476, appDetails.Data.Packages[0]);
            Assert.NotNull(appDetails.Data.PackageGroups);
            Assert.NotNull(appDetails.Data.Platforms);
            Assert.NotNull(appDetails.Data.Metacritic);
            Assert.NotEmpty(appDetails.Data.Categories);
            Assert.NotEmpty(appDetails.Data.Genres);
            Assert.NotEmpty(appDetails.Data.Screenshots);
            Assert.NotEmpty(appDetails.Data.Movies);
            Assert.NotNull(appDetails.Data.Recommendations);
            Assert.NotNull(appDetails.Data.Achievements);
            Assert.NotNull(appDetails.Data.ReleaseDate);
            Assert.NotNull(appDetails.Data.SupportInfo);
            Assert.Equal("https://cdn.akamai.steamstatic.com/steam/apps/292030/page_bg_generated_v6b.jpg?t=1673427135", appDetails.Data.Background);
            Assert.Equal("https://cdn.akamai.steamstatic.com/steam/apps/292030/page.bg.jpg?t=1673427135", appDetails.Data.BackgroundRaw);
            Assert.NotNull(appDetails.Data.ContentDescriptors);
        }

        [Fact]
        public void IsNull()
        {
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, JsonTokenType.Null);
            var appDetails = JsonDeserializer.DeserializeResponse<AppDetails>(response);
            Assert.Null(appDetails.Body);
        }

        [Fact]
        public void NotJsonException()
        {
            var response = TestSetup.CreateResponse(System.Net.HttpStatusCode.OK, "<html>");
            Assert.Throws<SteamPipe.HtmlResponseException>(() => JsonDeserializer.DeserializeResponse<AppDetails>(response));
        }
    }
}