using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// App categories that can be used to search for other apps
    /// that have the same category.
    /// </summary>
    public class Category
    {
        [JsonConstructor]
        public Category(int id, string description) =>
            (Id, Description) = (id, description);

        /// <summary>
        /// Description of the category
        /// </summary>
        [JsonPropertyName("description")]
        public virtual string Description { get; }

        /// <summary>
        /// Unique id of the category
        /// </summary>
        [JsonPropertyName("id")]
        public virtual int Id { get; }
    }
}