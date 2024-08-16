using SteamPipe.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace SteamPipe.Internal
{
    /// <summary>
    /// An internal class used for <see cref="IApiResponse{T}"/>
    /// </summary>
    public class Response
    {
        public Response(HttpStatusCode statusCode, object body, IDictionary<string, string> headers)
        {
            Ensure.ArgumentNotNull(headers, nameof(headers));

            StatusCode = statusCode;
            Body = body;
            Headers = new ReadOnlyDictionary<string, string>(headers);
        }

        /// <inheritdoc/>
        public object Body { get; }

        /// <inheritdoc/>
        public IReadOnlyDictionary<string, string> Headers { get; }

        /// <inheritdoc/>
        public HttpStatusCode StatusCode { get; }

        public bool IsSuccess => (int)StatusCode >= 200 && (int)StatusCode < 300;
    }
}