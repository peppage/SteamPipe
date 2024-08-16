using System.Text.Json.Serialization;

namespace SteamPipe
{
    public class AppListContainer
    {
        [JsonConstructor]
        public AppListContainer(AppList applist) => AppList = applist;

        [JsonPropertyName("applist")]
        public virtual AppList AppList { get; }
    }
}