using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Details about an App
    /// </summary>
    public class AppData
    {
        /// <summary>
        /// Text on app store page, in main area
        /// </summary>
        [JsonPropertyName("about_the_game")]
        public virtual string AboutTheGame { get; internal set; } = string.Empty;

        /// <summary>
        /// Highlighted achievements listed on the store page
        /// </summary>
        [JsonPropertyName("achievements")]
        public virtual Achievements? Achievements { get; internal set; }

        /// <summary>
        /// Id of the app
        /// </summary>
        [JsonPropertyName("steam_appid")]
        public virtual uint AppId { get; internal set; }

        /// <summary>
        /// URL to background image of store page
        /// </summary>
        [JsonPropertyName("background")]
        public virtual string Background { get; internal set; } = string.Empty;

        /// <summary>
        /// URL to background image of store page without effects
        /// </summary>
        [JsonPropertyName("background_raw")]
        public virtual string BackgroundRaw { get; internal set; } = string.Empty;

        /// <summary>
        /// Categories shown in the sidebar
        /// </summary>
        [JsonPropertyName("categories")]
        public virtual IReadOnlyList<Category> Categories { get; internal set; } = new List<Category>();

        /// <inheritdoc cref="SteamPipe.ContentDescriptors"/>
        [JsonPropertyName("content_descriptors")]
        public virtual ContentDescriptors ContentDescriptors { get; internal set; }

        /// <summary>
        /// How supported the controller is, ex "full"
        /// </summary>
        [JsonPropertyName("controller_support")]
        public virtual string ControllerSupport { get; internal set; } = string.Empty;

        /// <summary>
        /// Text on app store page, in main area
        /// </summary>
        [JsonPropertyName("detailed_description")]
        public virtual string DetailedDescription { get; internal set; } = string.Empty;

        /// <summary>
        /// Company/people/person who created the app
        /// </summary>
        [JsonPropertyName("developers")]
        public virtual IReadOnlyList<string>? Developers { get; internal set; }

        /// <summary>
        /// List of DLC App IDs for this app
        /// </summary>
        [JsonPropertyName("dlc")]
        public virtual IReadOnlyList<uint>? Dlc { get; internal set; }

        /// <summary>
        /// Genres shown in the sidebar
        /// </summary>
        [JsonPropertyName("genres")]
        public virtual IReadOnlyList<Genre> Genres { get; internal set; } = new List<Genre>();

        /// <summary>
        /// Url to image in sidebar on app page
        /// </summary>
        [JsonPropertyName("header_image")]
        public virtual string HeaderImage { get; internal set; } = string.Empty;

        /// <summary>
        /// If the app is free
        /// </summary>
        [JsonPropertyName("is__free")]
        public virtual bool IsFree { get; internal set; }

        /// <summary>
        /// Text under system requirements
        /// </summary>
        [JsonPropertyName("legal_notice")]
        public virtual string LegalNotice { get; internal set; } = string.Empty;

        /// <summary>
        /// Specifications to run app on Linux
        /// </summary>
        [JsonPropertyName("linux_requirements")]
        public virtual Requirements? LinuxRequirements { get; internal set; }

        /// <summary>
        /// Specifications to run app on Apple
        /// </summary>
        [JsonPropertyName("mac_requirements")]
        public virtual Requirements? MacRequirements { get; internal set; }

        /// <summary>
        /// Data for external site Metacritic
        /// </summary>
        [JsonPropertyName("metacritic")]
        public virtual Metacritic? Metacritic { get; internal set; }

        /// <summary>
        /// Videos shown on the store page
        /// </summary>
        [JsonPropertyName("movies")]
        public virtual IReadOnlyList<Movie> Movies { get; internal set; } = new List<Movie>();

        /// <summary>
        /// Name of the app
        /// </summary>
        [JsonPropertyName("name")]
        public virtual string Name { get; internal set; } = string.Empty;

        /// <summary>
        /// Package groups associated with this app, see <seealso cref="Sub"/>
        /// </summary>
        [JsonPropertyName("package_groups")]
        public virtual IReadOnlyList<PackageGroup>? PackageGroups { get; internal set; }

        /// <summary>
        /// Packages associated with this app, see <seealso cref="Sub"/>
        /// </summary>
        [JsonPropertyName("packages")]
        public virtual IReadOnlyList<uint>? Packages { get; internal set; }

        /// <summary>
        /// Specifications to run app on PC
        /// </summary>
        [JsonPropertyName("pc_requirements")]
        public virtual Requirements? PCRequirements { get; internal set; }

        /// <summary>
        /// Which operating systems the app is available on
        /// </summary>
        [JsonPropertyName("platforms")]
        public virtual Platforms Platforms { get; internal set; }

        /// <summary>
        /// Current pricing details, null if app is free
        /// </summary>
        [JsonPropertyName("price_overview")]
        public virtual Price? PriceOverview { get; internal set; }

        /// <summary>
        /// Company/people/person who distributed the app
        /// </summary>
        [JsonPropertyName("publishers")]
        public virtual IReadOnlyList<string>? Publishers { get; internal set; }

        /// <summary>
        /// Shown on store page next to all reviews score. Can be null if the game
        /// isn't released yet.
        /// </summary>
        [JsonPropertyName("recommendations")]
        public virtual Recommendations? Recommendations { get; internal set; }

        /// <inheritdoc cref="SteamPipe.ReleaseDate"/>
        [JsonPropertyName("release_date")]
        public virtual ReleaseDate ReleaseDate { get; internal set; }

        /// <summary>
        /// The age to view the app page.
        /// </summary>
        [JsonPropertyName("required_age")]
        public virtual string RequiredAge { get; internal set; } = string.Empty;

        /// <summary>
        /// Text describing review scores/quotes for app. Optional
        /// </summary>
        [JsonPropertyName("reviews")]
        public virtual string Reviews { get; internal set; } = string.Empty;

        /// <summary>
        /// Links to images shown on the store page
        /// </summary>
        [JsonPropertyName("screenshots")]
        public virtual IReadOnlyList<Screenshot> Screenshots { get; internal set; } = new List<Screenshot>();

        /// <summary>
        /// Text in sidebar below header image
        /// </summary>
        [JsonPropertyName("short_description")]
        public virtual string ShortDescription { get; internal set; } = string.Empty;

        /// <summary>
        /// Text describing which languages are available
        /// </summary>
        [JsonPropertyName("supported_languages")]
        public virtual string SupportedLanguages { get; internal set; } = string.Empty;

        /// <inheritdoc cref="SteamPipe.SupportInfo"/>
        [JsonPropertyName("support_info")]
        public virtual SupportInfo SupportInfo { get; internal set; }

        /// <summary>
        /// App type, ex "game"
        /// </summary>
        [JsonPropertyName("type")]
        public virtual string Type { get; internal set; } = string.Empty;

        /// <summary>
        /// Url to app external website
        /// </summary>
        [JsonPropertyName("website")]
        public virtual string Website { get; internal set; } = string.Empty;
    }
}