using SteamPipe.Helpers;
using SteamPipe.Internal;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteamPipe.Clients
{
    internal class CommunityClient : ICommunityClient
    {
        private readonly Uri _baseAddress;
        private readonly HttpClient _httpClient;
        private string SessionId { get; set; }

        /// <summary>
        /// Setup a new Steam Community API client
        /// </summary>
        /// <param name="client">The httpClient to make requests with</param>
        /// <param name="baseAddress"></param>
        public CommunityClient(HttpClient client, Uri baseAddress)
        {
            _httpClient = client;
            _baseAddress = baseAddress;
            SessionId = string.Empty;
        }

        public async Task<IApiResponse<CommunitySearch>> CommunitySearchAsync(string query, string filter)
        {
            Ensure.ArgumentNotNullOrEmptyString(query, nameof(query));

            IApiResponse<CommunitySearch>? resp = default;
            int retryCount = 0;
            const int maxRetries = 3;
            bool retry;

            do
            {
                retry = false;

                if (string.IsNullOrEmpty(SessionId))
                {
                    try
                    {
                        SessionId = await _httpClient.GetSessionIdAsync(_baseAddress);
                    }
                    catch
                    {
                        // Retry getting the session ID and retry the request
                        SessionId = await _httpClient.GetSessionIdAsync(_baseAddress);
                    }
                }

                try
                {
                    var url = new Uri(_baseAddress, $"search/SearchCommunityAjax?text={query}&filter={filter}&sessionid={SessionId}&steamid_user=false");
                    resp = await _httpClient.SendRequestAsync<CommunitySearch>(url);
                }
                catch (HttpRequestException)
                {
                    // Clear SessionId and retry the entire function
                    SessionId = string.Empty;
                    retry = true;
                    retryCount++;
                }
                catch (HtmlResponseException ex)
                {
                    throw new SteamAppException(0, ex);
                }
                catch (JsonException ex)
                {
                    throw new SteamAppException(0, "Failed to parse JSON", ex);
                }
                catch (Exception ex)
                {
                    throw new SteamAppException(0, "Failed", ex);
                }
            } while (retry && retryCount < maxRetries);

            if (resp == null)
            {
                throw new ApiException("Failed to get a valid response after retries", System.Net.HttpStatusCode.Unauthorized);
            }

            return resp;
        }
    }
}