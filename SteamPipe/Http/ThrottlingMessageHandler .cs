using SteamPipe.Helpers;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SteamPipe.Http
{
    internal class ThrottlingMessageHandler : DelegatingHandler
    {
        private readonly TimeSpanSemaphore semaphore;

        public ThrottlingMessageHandler(TimeSpanSemaphore semaphore) : this(semaphore, new HttpClientHandler())
        {
        }

        public ThrottlingMessageHandler(TimeSpanSemaphore semaphore, HttpMessageHandler messageHandler) : base(messageHandler)
        {
            Ensure.ArgumentNotNull(semaphore, nameof(semaphore));

            this.semaphore = semaphore;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return semaphore.RunAsync(base.SendAsync, request, cancellationToken);
        }
    }
}