using SteamPipe.Helpers;
using SteamPipe.Http;
using SteamPipe.Internal;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamPipe.Clients
{
    internal class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly Uri _baseAddress;

        /// <summary>
        /// Setup a new news API client
        /// </summary>
        /// <param name="client">The httpClient to make requests with</param>
        /// <param name="apiKey">Steam API Key</param>
        /// <param name="baseAddress">Base of the URL for the Steam API</param>
        public ApiClient(HttpClient client, string apiKey, Uri baseAddress)
        {
            _httpClient = client;
            _apiKey = apiKey;
            _baseAddress = baseAddress;
        }

        /// <inheritdoc/>
        public async Task<IApiResponse<NewsContainer>> GetNewsAsync(uint id, int maxLength = 0, DateTime? endDate = null, int count = 0, IEnumerable<string>? feeds = null)
        {
            Ensure.ArgumentNotZero((int)id, nameof(id));

            var parameters = new Dictionary<string, string>(4)
            {
                ["maxlength"] = maxLength > 0 ? maxLength.ToString() : string.Empty,
                ["count"] = count > 0 ? count.ToString() : string.Empty,
                ["enddate"] = endDate?.ToUnixTimeSeconds().ToString() ?? string.Empty,
                ["feedname"] = feeds != null ? string.Join(",", feeds) : string.Empty
            };

            var url = new Uri(_baseAddress, $"ISteamNews/GetNewsForApp/v0002?appid={id}").ApplyParameters(parameters);

            var resp = await _httpClient.SendRequestAsync<NewsContainer>(url);

            if (resp?.Body == null)
            {
                var response = new Response(System.Net.HttpStatusCode.InternalServerError, null, null);
                return new ApiResponse<NewsContainer>(response)
                {
                    ErrorMessage = "Get News had no response"
                };
            }

            return resp;
        }

        public async Task<IApiResponse<AppListContainer>> GetAppListAsync()
        {
            var url = new Uri(_baseAddress, "ISteamApps/GetAppList/v2/");
            return await _httpClient.SendRequestAsync<AppListContainer>(url);
        }
    }
}