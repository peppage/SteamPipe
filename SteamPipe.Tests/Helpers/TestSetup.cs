using System.Net;

namespace SteamPipe.Tests
{
    public static class TestSetup
    {
        public static Response CreateResponse(HttpStatusCode statusCode)
        {
            object body = null;
            return CreateResponse(statusCode, body);
        }

        public static Response CreateResponse(HttpStatusCode statusCode, object body)
        {
            return new Response(statusCode, body, new Dictionary<string, string>());
        }
    }
}