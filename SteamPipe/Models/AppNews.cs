using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamPipe
{
    public class AppNews
    {
        [JsonConstructor]
        public AppNews(uint appId, IReadOnlyList<News> newsItems, int count) =>
            (AppId, NewsItems, Count) = (appId, newsItems, count);

        [JsonPropertyName("appid")]
        public virtual uint AppId { get; }

        [JsonPropertyName("count")]
        public virtual int Count { get; }

        [JsonPropertyName("newsitems")]
        public virtual IReadOnlyList<News> NewsItems { get; }
    }
}