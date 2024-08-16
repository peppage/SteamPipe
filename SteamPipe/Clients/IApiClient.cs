using SteamPipe.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamPipe.Clients
{
    public interface IApiClient
    {
        /// <summary>
        /// Returns the latest news of a game specified by its id. Check
        /// <see cref="Constants.NewsFeeds"/> for a list of feeds.
        /// </summary>
        /// <param name="id">The game app id.</param>
        /// <param name="maxLength">Max length of content field.</param>
        /// <param name="endDate">News before this time.</param>
        /// <param name="count">Max number of items to get.</param>
        /// <param name="feeds">List of feeds to return news for. See <see cref="Constants.NewsFeeds"/></param>
        /// <exception cref="SteamAppException">Thrown when there is no response</exception>
        /// <returns>A list of news items</returns>
        /// <remarks>
        /// <seealso href="https://developer.valvesoftware.com/wiki/Steam_Web_API#GetNewsForApp_.28v0002.29"/><br></br>
        /// <seealso href="https://wiki.teamfortress.com/wiki/WebAPI/GetNewsForApp"/>
        /// </remarks>
        Task<IApiResponse<NewsContainer>> GetNewsAsync(uint id, int maxLength = 0, DateTime? endDate = null, int count = 0, IEnumerable<string>? feeds = null);

        /// <summary>
        /// A list of all apps on the Steam store
        /// </summary>
        /// <returns>A list of all Apps</returns>
        /// <remarks><seealso href="https://wiki.teamfortress.com/wiki/WebAPI/GetAppList"/></remarks>
        Task<IApiResponse<AppListContainer>> GetAppListAsync();
    }
}