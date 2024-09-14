using System.Threading.Tasks;

namespace SteamPipe.Clients
{
    public interface ICommunityClient
    {
        /// <summary>
        /// Search the Steam Community
        /// </summary>
        /// <param name="query">What text to search for</param>
        /// <param name="filter">What the search should filter on</param>
        /// <returns>Search results</returns>
        Task<IApiResponse<CommunitySearch>> CommunitySearchAsync(string query, string filter);
    }
}