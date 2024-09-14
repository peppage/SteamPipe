using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Search results from https://steamcommunity.com/search/groups
    /// </summary>
    public class CommunitySearch
    {
        [JsonConstructor]
        public CommunitySearch(string html, string searchFilter, int searchPage, int searchResultCount, string searchText, int success) =>
            (Html, SearchFilter, SearchPage, SearchResultCount, SearchText, Success) = (html, searchFilter, searchPage, searchResultCount, searchText, success);

        /// <summary>
        /// The results that would be added to the page. This needs to be parsed
        /// </summary>
        [JsonPropertyName("html")]
        public string Html { get; }

        /// <summary>
        /// The filter used for the search
        /// </summary>
        [JsonPropertyName("search_filter")]
        public string SearchFilter { get; }

        /// <summary>
        /// The page number of the search
        /// </summary>

        [JsonPropertyName("search_page")]
        public int SearchPage { get; }

        /// <summary>
        /// The number of results found
        /// </summary>

        [JsonPropertyName("search_result_count")]
        public int SearchResultCount { get; }

        /// <summary>
        /// The text that was searched for
        /// </summary>

        [JsonPropertyName("search_text")]
        public string SearchText { get; }

        /// <summary>
        /// If the search was successful
        /// </summary>

        [JsonPropertyName("success")]
        public int Success { get; }
    }
}