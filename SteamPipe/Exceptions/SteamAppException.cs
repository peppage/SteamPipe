using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Represents any general error an app could have. This exception
    /// includes the App id.
    /// </summary>
    [Serializable]
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "Not a general exception")]
    public class SteamAppException : ApiException
    {
        /// <summary>
        /// Constructs an instance of SteamAppException
        /// </summary>
        /// <param name="appId">The application id that failed</param>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public SteamAppException(uint appId, string message, Exception innerException) : base(message, innerException)
        {
            AppId = appId;
        }

        /// <summary>
        /// Constructs an instance of SteamAppException
        /// </summary>
        /// <param name="appId">The application id that failed</param>
        /// <param name="message">The exception message</param>
        /// <param name="statusCode">The HTTP status code returned by the response</param>
        public SteamAppException(uint appId, string message, HttpStatusCode statusCode) : base(message, statusCode)
        {
            AppId = appId;
        }

        /// <summary>
        /// Constructs an instance of SteamAppException
        /// </summary>
        /// <param name="appId">The application id that failed</param>
        /// <param name="apiException">The inner exception of our custom type</param>
        public SteamAppException(uint appId, ApiException apiException) : base(apiException)
        {
            AppId = appId;
        }

        /// <summary>
        /// Constructs an instance of SteamAppException
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        protected SteamAppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Id of application that failed
        /// </summary>
        public uint AppId { get; }
    }
}