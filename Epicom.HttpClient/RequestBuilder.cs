using Epicom.Diagnostics;
using Epicom.Http.Client.Annotations;
using Polly;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epicom.Http.Client
{
    public class RequestBuilder
    {

		private const string TraceIdHeader = "X-Trace-Id";

		protected virtual AuthenticationHeaderValue Authentication
        {
            get
            {
                return null;
            }
        }
       
        public HttpRequestMessage BuildRequest<T>(IResponse<T> request)
        {
            var method = GetMethod(request);
            string path = GetPath(request);
            var httpRequest = new HttpRequestMessage(method, path);
            if (method != HttpMethod.Get)
            {
                httpRequest.Content = new ObjectContent<IResponse<T>>(request, new JsonMediaTypeFormatter());
            }

            if (!String.IsNullOrEmpty(TraceId.Current))
            {
                httpRequest.Headers.Add(TraceIdHeader, TraceId.Current);
            }

            return httpRequest;
        }
       

        private HttpMethod GetMethod(object request)
        {
            var route = (RouteAttribute)request.GetType()
                .GetCustomAttributes(typeof(RouteAttribute), true)
                .SingleOrDefault();

            if (route == null)
            {
                throw new Exception("Atributo Route não definido no objeto de request");
            }

            return new HttpMethod(route.HttpMethod);
        }

        private string GetPath(object request)
        {
            var route = (RouteAttribute)request.GetType()
                .GetCustomAttributes(typeof(RouteAttribute), true)
                .SingleOrDefault();

            if (route == null)
                throw new Exception("Atributo Route não definido no objeto de request");

            string path = ReplacePathParameters(route.Path, request);

            if (route.HttpMethod == "GET")
                path += BuildQueryString(route.Path, request);

            return path;
        }

        private string ReplacePathParameters(string path, object request)
        {
            var matches = GetPropertyMatches(path);
            foreach (Match match in matches)
            {
                var parameterName = match.Groups["parameterName"].Value;
                var propertyName = match.Groups["propertyName"].Value;
                if (propertyName == "")
                    throw new Exception(string.Format("Parâmetro vazio na rota da classe {0}: {1}", request.GetType().Name, parameterName));

                var property = request.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    var propertyValue = property.GetValue(request);
					string propertyValueAsString = "";
					var p = property.GetMethod.ReturnType;
					if (property.GetMethod.ReturnType == typeof(DateTime))
					{
						propertyValueAsString = ((DateTime) propertyValue).ToString("yyyy-MM-ddTHH:mm:ss");
					}
					else
					{
						propertyValueAsString = propertyValue != null ? propertyValue.ToString() : null;
					}                    
                    path = path.Replace(parameterName, propertyValueAsString);
                }
            }
            return path;
        }

        private MatchCollection GetPropertyMatches(string path)
        {
            return Regex.Matches(path, @"(?<parameterName>{(?<propertyName>.*?)})");
        }

        private string BuildQueryString(string path, object request)
        {
            var pathProperties = GetPropertyMatches(path).Cast<Match>().Select(m => m.Groups["propertyName"].Value);
            var requestProperties = request.GetType().GetProperties().Select(p => p.Name).ToList();
            var propertiesNotOnPath = requestProperties.Except(pathProperties).ToList();

            var queryStringBuilder = new StringBuilder();
            char queryStringSeparator = '?';
            foreach (var prop in propertiesNotOnPath)
            {
                var property = request.GetType().GetProperty(prop);
                var propertyValue = property.GetValue(request);
                var queryStringRepresentation = propertyValue != null ? propertyValue.ToString() : null;

                queryStringBuilder.Append(string.Format("{0}{1}={2}", queryStringSeparator, property.Name, queryStringRepresentation));
                queryStringSeparator = '&';
            }

            return queryStringBuilder.ToString();
        }        
    }
}
