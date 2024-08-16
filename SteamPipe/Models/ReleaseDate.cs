using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Release date shown on the store page
    /// </summary>
    public class ReleaseDate
    {
        /// <summary>
        /// Create a new instance of the ReleaseDate
        /// </summary>
        /// <param name="comingSoon">If the app is unreleased</param>
        /// <param name="date">Date of release</param>
        [JsonConstructor]
        public ReleaseDate(bool comingSoon, string date) =>
            (ComingSoon, Date) = (comingSoon, date);

        /// <summary>
        /// True if the game is unreleased
        /// </summary>
        [JsonPropertyName("coming_soon")]
        public virtual bool ComingSoon { get; }

        /// <summary>
        /// <para>Date the app will be available to purchase.</para>
        /// <para>This is set by the developer and can be anything before launch.</para>
        /// <para>At launch the date should be in the format "MMM d, yyyy"</para>
        /// </summary>
        [JsonPropertyName("date")]
        public virtual string Date { get; }
    }
}