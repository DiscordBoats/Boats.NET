using System;
using System.Web;

namespace Boats.NET
{
    internal static class BoatsExtensions
    {
        // Stolen From: https://github.com/The-Grape-Vine/NewsAPI.Net/blob/master/NewsAPI.Net/Extensions/HttpExtensions.cs
        internal static Uri AddQuery(this Uri uri, string param, string val)
        {
            UriBuilder builder = new UriBuilder(uri);
            System.Collections.Specialized.NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);
            query[param] = val;
            builder.Query = query.ToString();

            return builder.Uri;
        }
    }
}