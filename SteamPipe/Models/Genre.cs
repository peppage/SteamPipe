using System.Text.Json.Serialization;

namespace SteamPipe
{
    public class Genre
    {
        [JsonConstructor]
        public Genre(string id, string description) =>
            (Id, Description) = (id, description);

        [JsonPropertyName("description")]
        public virtual string Description { get; }

        [JsonPropertyName("id")]
        public virtual string Id { get; }
    }
}