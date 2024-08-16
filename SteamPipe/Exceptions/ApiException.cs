using SteamPipe.Helpers;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// Represents errors that occur from the Steam API
    /// </summary>
    [Serializable]
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "Not a general exception")]
    public class ApiException : Exception
    {
        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="statusCode">The HTTP status code returned by the response</param>
        public ApiException(string message, HttpStatusCode statusCode) : base(message, null)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The inner exception</param>
        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="innerException">The inner exception</param>
        protected ApiException(ApiException innerException)
        {
            Ensure.ArgumentNotNull(innerException, nameof(innerException));

            StatusCode = innerException.StatusCode;
        }

        /// <summary>
        /// Constructs an instance of ApiException
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// The HTTP status code associated with the response
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }
}