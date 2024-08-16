using SteamPipe.Helpers;
using SteamPipe.Internal;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteamPipe.Clients
{
    /// <inheritdoc cref="IStoreClient"/>
    internal class StoreClient : IStoreClient
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseAddress;

        /// <summary>
        /// Setup a new Steam Store API client
        /// </summary>
        /// <param name="client">The httpClient to make requests with</param>
        /// <param name="baseAddress"></param>
        public StoreClient(HttpClient client, Uri baseAddress)
        {
            _httpClient = client;
            _baseAddress = baseAddress;
        }

        /// <inheritdoc/>
        public async Task<AppData> AppDetailsAsync(uint appId)
        {
            Ensure.ArgumentNotZero((int)appId, nameof(appId));

            IApiResponse<AppDetails> resp;

            try
            {
                var url = new Uri(_baseAddress, $"api/appdetails/?appids={appId}");
                resp = await _httpClient.SendRequestAsync<AppDetails>(url);
            }
            catch (HtmlResponseException ex)
            {
                throw new SteamAppException(appId, ex);
            }
            catch (JsonException ex)
            {
                throw new SteamAppException(appId, "Failed to parse JSON", ex);
            }
            catch (Exception ex)
            {
                throw new SteamAppException(appId, "Failed", ex);
            }

            if (resp.Body == null)
            {
                throw new SteamAppException(appId, "Nothing returned", new NullReferenceException());
            }

            if (!resp.Body.Success)
            {
                throw new NoSuccessException(appId, "Success returned as false", System.Net.HttpStatusCode.OK);
            }

            return resp.Body.Data;
        }
    }
}