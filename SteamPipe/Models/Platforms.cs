using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Which operating system the app runs on.
    /// </summary>
    public class Platforms
    {
        [JsonConstructor]
        public Platforms(bool linux, bool mac, bool windows) =>
            (Linux, Mac, Windows) = (linux, mac, windows);

        /// <summary>
        /// If the app is available on the Linux operating system.
        /// </summary>
        [JsonPropertyName("linux")]
        public virtual bool Linux { get; }

        /// <summary>
        /// If the app is available on the Apple operating system.
        /// </summary>
        [JsonPropertyName("mac")]
        public virtual bool Mac { get; }

        /// <summary>
        /// If the app is available on the Windows operating system.
        /// </summary>

        [JsonPropertyName("windows")]
        public virtual bool Windows { get; }
    }
}