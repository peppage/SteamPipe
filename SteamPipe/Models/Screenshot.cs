using System.Text.Json.Serialization;

namespace SteamPipe
{
    public class Screenshot
    {
        [JsonConstructor]
        public Screenshot(int id, string pathThumbnail, string pathFull) =>
            (Id, PathThumbnail, PathFull) = (id, pathThumbnail, pathFull);

        /// <summary>
        /// Order of screenshot on page
        /// </summary>
        [JsonPropertyName("id")]
        public virtual int Id { get; }

        /// <summary>
        /// URL to lower resolution image
        /// </summary>
        [JsonPropertyName("path_thumbnail")]
        public virtual string PathThumbnail { get; }

        /// <summary>
        /// URL to maximum resolution image
        /// </summary>
        [JsonPropertyName("path_full")]
        public virtual string PathFull { get; }
    }
}