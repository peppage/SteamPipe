using System;
using System.Text.Json.Serialization;

//TODO: missing feed_type, tags

namespace SteamPipe
{
    public class News
    {
        [JsonConstructor]
        public News(string author, string contents, uint epoch, bool externalUrl, string feedLabel, string feedName, string gid, string title, string url) =>
            (Author, Contents, Epoch, ExternalUrl, FeedLabel, FeedName, Gid, Title, Url) = (author, contents, epoch, externalUrl, feedLabel, feedName, gid, title, url);

        /// <summary>
        /// Who wrote the news item. It's optional.
        /// </summary>
        [JsonPropertyName("author")]
        public virtual string Author { get; }

        [JsonPropertyName("contents")]
        public virtual string Contents { get; }

        /// <summary>
        /// Helper for converting <see cref="Epoch"/> to a <see cref="DateTime"/>.
        /// </summary>
        [JsonIgnore]
        public virtual DateTime Date => DateTimeOffset.FromUnixTimeSeconds(Epoch).DateTime;

        /// <summary>
        /// Unix time in seconds when the news was released.
        /// <!-- Must be set to public for JSON deserialize -->
        /// </summary>
        [JsonPropertyName("date")]
        public virtual uint Epoch { get; }

        /// <summary>
        /// If the news is from an external site.
        /// </summary>
        [JsonPropertyName("is_external_url")]
        public virtual bool ExternalUrl { get; }

        [JsonPropertyName("feedlabel")]
        public virtual string FeedLabel { get; }

        [JsonPropertyName("feedname")]
        public virtual string FeedName { get; }

        /// <summary>
        /// Unique id for the news item.
        /// </summary>
        [JsonPropertyName("gid")]
        public virtual string Gid { get; }

        /// <summary>
        /// Title of the news item.
        /// </summary>
        [JsonPropertyName("title")]
        public virtual string Title { get; }

        /// <summary>
        /// Url to read the news item in a browser.
        /// </summary>
        [JsonPropertyName("url")]
        public virtual string Url { get; }
    }
}