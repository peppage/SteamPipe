using System.Threading.Tasks;

namespace SteamPipe.Clients
{
    /// <summary>
    /// A client for Steam's store API.
    /// </summary>
    public interface IStoreClient
    {
        /// <summary>
        /// Get detailed information about a app on Steam
        /// </summary>
        /// <param name="appId">The id for the app, get from URL of steam page</param>
        /// <remarks><seealso href="https://wiki.teamfortress.com/wiki/User:RJackson/StorefrontAPI#appdetails"/></remarks>
        /// <exception cref="SteamAppException">Throw when a general API errors occurs</exception>
        /// <exception cref="NoSuccessException">
        /// Throw when the call succeeds but success is false, it's still an error.
        /// </exception>
        /// <returns>The details about an app</returns>
        Task<IApiResponse<AppDetails>> AppDetailsAsync(uint appId);
    }
}