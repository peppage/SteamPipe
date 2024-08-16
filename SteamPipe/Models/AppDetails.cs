using SteamPipe.Serialization;
using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Wrapper around <see cref="AppData"/>
    /// </summary>
    [JsonConverter(typeof(AppDetailsContainerJsonConverter))]
    public class AppDetails
    {
        /// <summary>
        /// Create a new instance of the AppDetails
        /// </summary>
        /// <param name="data"></param>
        /// <param name="success"></param>
        [JsonConstructor]
        public AppDetails(AppData data, bool success) => (Data, Success) = (data, success);

        /// <summary>
        /// The details about the app
        /// </summary>
        [JsonPropertyName("data")]
        public virtual AppData Data { get; }

        /// <summary>
        /// If the request has data
        /// </summary>
        [JsonPropertyName("success")]
        public virtual bool Success { get; }
    }
}