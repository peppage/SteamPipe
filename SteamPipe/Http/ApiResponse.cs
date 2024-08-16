using SteamPipe.Helpers;
using SteamPipe.Internal;

namespace SteamPipe.Http
{
    internal class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse(Response response) : this(response, GetBodyAsObject(response))
        { }

        public ApiResponse(Response response, T bodyAsObject)
        {
            Ensure.ArgumentNotNull(response, nameof(response));

            Response = response;
            Body = bodyAsObject;
        }

        public T Body { get; private set; }

        public bool IsSuccess => Response.IsSuccess;

        public string ErrorMessage { get; internal set; } = "";

        internal Response Response { get; }

        private static T GetBodyAsObject(Response response)
        {
            var body = response.Body;
            if (body is T t) return t;
            return default;
        }
    }
}