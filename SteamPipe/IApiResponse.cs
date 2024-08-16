namespace SteamPipe
{
    /// <summary>
    /// Wrapper for a response from the API
    /// </summary>
    /// <typeparam name="T">Paylost contained in the response</typeparam>
    public interface IApiResponse<out T>
    {
        /// <summary>
        /// Payload of the response
        /// </summary>
        T Body { get; }

        /// <summary>
        /// If the request was a success
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Error message, empty string if no error
        /// </summary>
        string ErrorMessage { get; }
    }
}