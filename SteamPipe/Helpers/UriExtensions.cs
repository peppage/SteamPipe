using System;
using System.Collections.Generic;
using System.Linq;

namespace SteamPipe.Helpers
{
    /// <summary>
    /// Extensions for working with <see cref="Uri"/>
    /// </summary>
    internal static class UriExtensions
    {
        /// <summary>
        /// Merge a dictionary with an existing Uri
        /// </summary>
        /// <param name="uri">Original request Uri</param>
        /// <param name="parameters">Collection of key-value pairs</param>
        /// <returns>Updated request Uri</returns>
        public static Uri ApplyParameters(this Uri uri, IDictionary<string, string>? parameters)
        {
            Ensure.ArgumentNotNull(uri, nameof(uri));

            if (parameters?.Any() != true) return uri;

            //We want to remove any parameters that do not have a value
            IDictionary<string, string> p = parameters.Where(pair => !string.IsNullOrEmpty(pair.Value)).ToDictionary(pair => pair.Key, pair => pair.Value);

            var hasQueryString = uri.OriginalString.IndexOf("?", StringComparison.Ordinal);

            string uriWithoutQuery = hasQueryString == -1 ? uri.ToString() : uri.OriginalString[..hasQueryString];

            string queryString;
            if (uri.IsAbsoluteUri)
            {
                queryString = uri.Query;
            }
            else
            {
                queryString = hasQueryString == -1 ? "" : uri.OriginalString[hasQueryString..];
            }

            var values = queryString.Replace("?", "").Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            var existingParameters = values.ToDictionary(
                key => key[..key.IndexOf('=')],
                value => value[(value.IndexOf('=') + 1)..]);

            foreach (var existing in existingParameters)
            {
                if (!p.ContainsKey(existing.Key))
                {
                    p.Add(existing);
                }
            }

            string query = string.Join("&", p.Select(kvp => kvp.Key + "=" + kvp.Value));
            if (uri.IsAbsoluteUri)
            {
                var uriBuilder = new UriBuilder(uri)
                {
                    Query = query,
                };

                return uriBuilder.Uri;
            }

            return new Uri(uriWithoutQuery + "?" + query, UriKind.Relative);
        }
    }
}