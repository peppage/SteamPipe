using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Gettting the app details returned success = false. The API returns
    /// a 200 OK for this but it could be the app doesn't exist or it was
    /// removed from Steam.
    /// </summary>
    [Serializable]
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "Not a general exception")]
    public class NoSuccessException : SteamAppException
    {
        /// <summary>
        /// Constructs an instance of AppDetailsException
        /// </summary>
        /// <param name="appId">The application id that failed</param>
        /// <param name="message">The exception message</param>
        /// <param name="statusCode">The HTTP status code returned by the response</param>
        public NoSuccessException(uint appId, string message, HttpStatusCode statusCode) : base(appId, message, statusCode)
        {
        }

        /// <summary>
        /// Constructs an instance of AppDetailsException
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        protected NoSuccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}