using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Promoted <see cref="Achievements" /> to the store page
    /// </summary>
    public class Highlighted
    {
        [JsonConstructor]
        public Highlighted(string name, string path) =>
            (Name, Path) = (name, path);

        /// <summary>
        /// Name of the achievement
        /// </summary>
        [JsonPropertyName("name")]
        public virtual string Name { get; }

        /// <summary>
        /// URL to the image for the achievement
        /// </summary>
        [JsonPropertyName("path")]
        public virtual string Path { get; }
    }
}