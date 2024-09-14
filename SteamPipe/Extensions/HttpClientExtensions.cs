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

        public static async Task<string> GetSessionIdAsync(this HttpClient httpClient, Uri url)
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            if (response.Headers.TryGetValues("Set-Cookie", out var cookies))
            {
                var sessionIdCookie = cookies.FirstOrDefault(x => x.Contains("sessionid"));
                if (sessionIdCookie != null)
                {
                    var sessionIdValue = sessionIdCookie.Split(';')[0].Trim().Split('=')[1];
                    return sessionIdValue;
                }
            }

            throw new InvalidOperationException("Session ID cookie not found in the response.");
        }
    }
}