//-----------------------------------------------------------------------
// <copyright file="HttpRequestMessageExtensions.cs" company="OTIS">
//     Copyright (c) Sachin LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SchoolERP.WebApp.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    /// <summary>
    /// Extends the HttpRequestMessage collection
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// Returns a dictionary of QueryStrings that's easier to work with
        /// than GetQueryNameValuePairs KeyValuePairs collection.
        /// If you need to pull a few single values use GetQueryString instead.
        /// </summary>
        /// <param name="request">HTTP request message</param>
        /// <returns>
        /// Returns a dictionary of QueryStrings
        /// </returns>
        public static Dictionary<string, string> GetQueryStrings(this HttpRequestMessage request)
        {
            return request.GetQueryNameValuePairs()
                          .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the Query String value
        /// </summary>
        /// <param name="request">The HTTP request Message object</param>
        /// <param name="key">The key</param>
        /// <returns>
        /// Returns an individual Query String value
        /// </returns>
        public static string GetQueryString(this HttpRequestMessage request, string key)
        {
            // IEnumerable<KeyValuePair<string,string>> - right!
            var queryStrings = request.GetQueryNameValuePairs();
            if (queryStrings == null)
            {
                return null;
            }

            var match = queryStrings.FirstOrDefault(kv => string.Compare(kv.Key, key, true) == 0);
            if (string.IsNullOrEmpty(match.Value))
            {
                return null;
            }

            return match.Value;
        }

        /// <summary>
        /// Gets an individual HTTP Header value.
        /// </summary>
        /// <param name="request">HTTP request message</param>
        /// <param name="key">The key</param>
        /// <returns>
        /// Returns an individual HTTP Header value.
        /// </returns>
        public static string GetHeader(this HttpRequestMessage request, string key)
        {
            IEnumerable<string> keys = null;
            if (!request.Headers.TryGetValues(key, out keys))
            {
                return null;
            }

            return keys.First();
        }

        /// <summary>
        /// Gets an individual cookie from the cookies collection
        /// </summary>
        /// <param name="request">Http request message object</param>
        /// <param name="cookieName">The cookieName</param>
        /// <returns>
        /// returns an individual cookie from the cookies collection
        /// </returns>
        public static string GetCookie(this HttpRequestMessage request, string cookieName)
        {
            CookieHeaderValue cookie = request.Headers.GetCookies(cookieName).FirstOrDefault();
            if (cookie != null)
            {
                return cookie[cookieName].Value;
            }

            return null;
        }
    }
}