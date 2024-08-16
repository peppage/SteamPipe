using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamPipe.Internal
{
    internal static class HttpClientExtensions
    {
        public static async Task<IApiResponse<T>> SendRequestAsync<T>(this HttpClient httpClient, Uri url)
        {
            var responseMessage = await httpClient.GetAsync(url);
            responseMessage.EnsureSuccessStatusCode();

            var responseBody = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseHeaders = responseMessage.Headers.ToDictionary(h => h.Key, h => h.Value.First());

            var response = new Response(responseMessage.StatusCode, responseBody, responseHeaders);
            return JsonDeserializer.DeserializeResponse<T>(response);
        }
    }
}