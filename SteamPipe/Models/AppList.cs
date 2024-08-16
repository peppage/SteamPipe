using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Wrapper around list of apps
    /// </summary>
    public class AppList
    {
        /// <summary>
        /// Create a new instance of the AppList.
        /// </summary>
        /// <param name="apps"></param>
        [JsonConstructor]
        public AppList(IReadOnlyList<App> apps) => Apps = apps;

        /// <summary>
        /// List of apps on steam
        /// </summary>
        [JsonPropertyName("apps")]
        public virtual IReadOnlyList<App> Apps { get; }
    }
}