using SteamPipe.Clients;
using SteamPipe.Helpers;
using SteamPipe.Http;
using System;
using System.Net.Http;

namespace SteamPipe
{
    /// <summary>
    /// A client for the Steam API. You can read more <see href="https://wiki.teamfortress.com/wiki/WebAPI"/>
    /// </summary>
    public class SteamClient : ISteamClient
    {
        /// <summary>
        /// The default URL for the Steam API
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "Not changing, default for Valve")]
        public Uri SteamApiUrl { get; private set; } = new Uri("https://api.steampowered.com/");

        /// <summary>
        /// The default URL for the Steam store API
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "Not changing, default for Valve")]
        public Uri SteamStoreApiUrl { get; private set; } = new Uri("https://store.steampowered.com/");

        private const int SafeDelayBetweenCalls = 1500;

        /// <summary>
        /// Create a new instance of the Steam API client that doesn't need an API key.
        /// </summary>
        public SteamClient() : this(new HttpClient(new ThrottlingMessageHandler(new TimeSpanSemaphore(1, TimeSpan.FromMilliseconds(SafeDelayBetweenCalls)))))
        {
        }

        /// <summary>
        /// Create a new instance of the Steam API client that doesn't need an
        /// API key but you want to specify your own <see cref="HttpClient"/>
        /// </summary>
        /// <param name="httpClient">Client to make requests through</param>
        public SteamClient(HttpClient httpClient)
        {
            Ensure.ArgumentNotNull(httpClient, nameof(httpClient));

            _httpClient = httpClient;

            Store = new StoreClient(_httpClient, BaseStoreAddress);
        }

        /// <inheritdoc/>
        public string ApiKey { get; private set; } = "";

        /// <inheritdoc/>
        public Uri BaseApiAddress => SteamApiUrl;

        /// <inheritdoc/>
        public Uri BaseStoreAddress => SteamStoreApiUrl;

        /// <inheritdoc/>
        public IStoreClient Store { get; private set; }

        /// <inheritdoc/>
        public IApiClient Api { get; private set; }

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Set the API key to use for API requests
        /// <remarks>Get an API key here <see href="https://steamcommunity.com/dev/apikey"/>. KEEP IT SECRET</remarks>
        /// </summary>
        /// <param name="apiKey"></param>
        public void SetApiKey(string apiKey)
        {
            Ensure.ArgumentNotNullOrEmptyString(apiKey, nameof(apiKey));

            ApiKey = apiKey;
            Api = new ApiClient(_httpClient, ApiKey, SteamApiUrl);
        }

        public void SetBaseApiAddress(string baseApiAddress)
        {
            var uri = new Uri(baseApiAddress);

            if (!uri.IsAbsoluteUri)
            {
                throw new ArgumentException($"The base address '{baseApiAddress}' must be an absolute URI", nameof(baseApiAddress));
            }

            SteamApiUrl = uri;
            Store = new StoreClient(_httpClient, SteamStoreApiUrl);
        }

        public void SetBaseStoreAddress(string storeAddress)
        {
            var uri = new Uri(storeAddress);

            if (!uri.IsAbsoluteUri)
            {
                throw new ArgumentException($"The base address '{storeAddress}' must be an absolute URI", nameof(storeAddress));
            }

            SteamStoreApiUrl = uri;

            if (!string.IsNullOrEmpty(ApiKey))
            {
                Api = new ApiClient(_httpClient, ApiKey, SteamStoreApiUrl);
            }
        }
    }
}