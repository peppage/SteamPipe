using System.Text.Json.Serialization;

namespace SteamPipe
{
    public class Requirements
    {
        [JsonConstructor]
        public Requirements(string minimum, string recommended) =>
            (Minimum, Recommended) = (minimum, recommended);

        [JsonPropertyName("minimum")]
        public virtual string Minimum { get; }

        [JsonPropertyName("recommended")]
        public virtual string Recommended { get; }
    }
}