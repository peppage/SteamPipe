using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// <para>An Application (or App) is the main representation of a product
    /// (game, DLC, movie, etc...) on Steam. An App generally has its own store
    /// page, it's own Community Hub, and is what appears in customers' libraries.</para>
    /// <para> Each App is represented by a unique ID called an App ID. Generally
    /// a single product will not span multiple Applications.</para>
    /// </summary>
    /// <remarks><seealso href="https://partner.steamgames.com/doc/store/application"/></remarks>
    public class App
    {
        [JsonConstructor]
        public App(uint appId, string name) => (AppId, Name) = (appId, name);

        /// <summary>
        /// The app's id
        /// </summary>
        [JsonPropertyName("appid")]
        public virtual uint AppId { get; }

        /// <summary>
        /// The app's name
        /// </summary>
        [JsonPropertyName("name")]
        public virtual string Name { get; }
    }
}