using SteamPipe.Clients;
using System;

namespace SteamPipe
{
    public interface ISteamClient
    {
        /// <summary>
        /// Steam developer API key.
        /// </summary>
        /// <remarks>
        /// Get a key from <seealso href="https://steamcommunity.com/dev/apikey"/>. KEEP IT SECRET.
        /// </remarks>
        string ApiKey { get; }

        /// <summary>
        /// Base address of the Steam API. This defaults to https://api.steampowered.com/
        /// </summary>
        Uri BaseApiAddress { get; }

        /// <summary>
        /// Base address of Steam Store API. This defaults to https://store.steampowered.com/
        /// </summary>
        Uri BaseStoreAddress { get; }

        /// <summary>
        /// Access the Steam Store API.
        /// </summary>
        IStoreClient Store { get; }

        /// <summary>
        /// Access Steam API
        /// </summary>
        IApiClient Api { get; }


        /// <summary>
        /// Set the API key to use for API requests
        /// </summary>
        /// <param name="apiKey"></param>
        void SetApiKey(string apiKey);

        /// <summary>
        /// Override the base address for the Steam API
        /// </summary>
        /// <param name="baseApiAddress"></param>
        void SetBaseApiAddress(string baseApiAddress);

        /// <summary>
        /// Override the base address for the Steam Store API
        /// </summary>
        /// <param name="storeAddress"></param>
        void SetBaseStoreAddress(string storeAddress);
    }
}