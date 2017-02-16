using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Epicom.Http.Client.Util
{
    internal static class HttpResponseMessageExtensions
    {
        public static bool HasNextPage(this HttpResponseMessage response)
        {
            var link = response.ExtractLink("next");
            return !String.IsNullOrWhiteSpace(link);
        }

        public static string NextPageLink(this HttpResponseMessage response)
        {
            return response.ExtractLink("next");
        }

        public static string ExtractLink(this HttpResponseMessage response, string name)
        {
            var links = response.Headers.GetValues("Link");
            foreach (var link in links)
            {
                var matches = Regex.Matches(link, @"<(?<link>.*?)>; rel=" + name);
                if (matches.Count > 0)
                {
                    return matches[0].Groups["link"].Value;
                }
            }

            return null;
        }
    }
}
