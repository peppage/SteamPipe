using System.Text.Json.Serialization;

namespace SteamPipe.Internal
{
    public class NewsContainer
    {
        [JsonConstructor]
        public NewsContainer(AppNews appNews) => AppNews = appNews;

        [JsonPropertyName("appnews")]
        public virtual AppNews AppNews { get; }
    }
}