using SteamPipe.Serialization;
using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Webm links for a <see cref="Movie"/>
    /// </summary>
    [JsonConverter(typeof(MovieLinksJsonConverter))]
    public class MovieLinks
    {
        /// <summary>
        /// URL to lower resolution video
        /// </summary>
        [JsonPropertyName("480")]
        public virtual string Resolution480 { get; internal set; } = string.Empty;

        /// <summary>
        /// URL to maximum resolution video
        /// </summary>
        [JsonPropertyName("max")]
        public virtual string ResolutionMax { get; internal set; } = string.Empty;
    }
}