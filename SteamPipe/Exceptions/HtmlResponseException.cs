using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// The response from the API was HTML, should probably retry
    /// </summary>
    [Serializable]
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "Not a general exception")]
    public class HtmlResponseException : ApiException
    {
        /// <summary>
        /// Constructs an instance of HTMLResponseException
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public HtmlResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructs an instance of HTMLResponseException
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        protected HtmlResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}