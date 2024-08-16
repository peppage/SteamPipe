using SteamPipe.Helpers;
using SteamPipe.Http;
using System;
using System.Collections;
using System.Text.Json;

namespace SteamPipe.Internal
{
    /// <summary>
    /// Serialize the response from JSON
    /// </summary>
    public static class JsonDeserializer
    {
        /// <summary>
        /// Deserialize the JSON body from <see cref="Response"/> into an
        /// <see cref="IApiResponse{T}"/>
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="response">The response from the API</param>
        /// <returns></returns>
        /// <exception cref="HtmlResponseException">When the response is HTML</exception>
        public static IApiResponse<T> DeserializeResponse<T>(Response response)
        {
            Ensure.ArgumentNotNull(response, nameof(response));

            var body = response.Body as string;
            if (!string.IsNullOrEmpty(body) && body != "{}")
            {
                var typeIsDictionary = typeof(IDictionary).IsAssignableFrom(typeof(T)) || typeof(T).IsAssignableToGenericType(typeof(System.Collections.Generic.IDictionary<,>));
                var typeIsEnumerable = typeof(IEnumerable).IsAssignableFrom(typeof(T));
                var responseIsObject = body.StartsWith("{", StringComparison.Ordinal);

                // If we're expecting an array, but we get a single object, just wrap it.
                // This supports an API that dynamically changes the return type based on the content.
                if (!typeIsDictionary && typeIsEnumerable && responseIsObject)
                {
                    body = "[" + body + "]";
                }

                try
                {
                    var json = JsonSerializer.Deserialize<T>(body);
                    return new ApiResponse<T>(response, json);
                }
                catch (JsonException ex)
                {
                    if (ex.Message.Contains("'<' is an invalid start of a value"))
                    {
                        throw new HtmlResponseException("Failed to parse", ex);
                    }

                    throw;
                }
            }

            return new ApiResponse<T>(response);
        }
    }
}