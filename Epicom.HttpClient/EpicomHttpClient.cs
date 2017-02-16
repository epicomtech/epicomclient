using EasyAsyncEnumerable;
using Epicom.Diagnostics;
using Epicom.Http.Client.Annotations;
using Epicom.Http.Client.Exceptions;
using Epicom.Http.Client.Util;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epicom.Http.Client
{
    public abstract class EpicomHttpClient : IEpicomHttpClient
    {
        private const string TraceIdHeader = "X-Trace-Id";

        private readonly Policy retryPolicy;
        protected HttpClient client;

        protected EpicomHttpClient(RetryPolicyConfig retryPolicy = null)
        {
            if (retryPolicy != null)
            {
                this.retryPolicy = Policy
                    .Handle<EpicomHttpException>(ex => ex.StatusCode >= 500)
                    .Or<TaskCanceledException>()
                    .WaitAndRetryAsync(retryPolicy.RetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            }
        }

        protected EpicomHttpClient(HttpClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            this.client = client;
        }

        public abstract Uri BaseUri { get; }

        protected virtual AuthenticationHeaderValue Authentication
        {
            get
            {
                return null;
            }
        }

        public virtual async Task<T> GetAsync<T>(IResponse<T> request)
        {
            return await SendAsync(request);
        }

        public virtual async Task<T> PostAsync<T>(IResponse<T> request)
        {
            return await SendAsync(request);
        }

        public virtual async Task<T> PatchAsync<T>(IResponse<T> request)
        {
            return await SendAsync(request);
        }

        public virtual async Task<T> PutAsync<T>(IResponse<T> request)
        {
            return await SendAsync(request);
        }

        public virtual async Task<T> DeleteAsync<T>(IResponse<T> request)
        {
            return await SendAsync(request);
        }

        public virtual IAsyncEnumerable<T> GetPaged<T>(IResponse<IEnumerable<T>> request)
        {
            bool shouldFetchNextPage = true;
            HttpRequestMessage httpRequest = BuildRequest(request);

            return AsyncEnumerable.Create<T>(async (yield, cancellationToken) =>
            {
                if (!shouldFetchNextPage)
                {
                    yield.Break();
                    return;
                }

                var response = await SendAsync(httpRequest);
                var result = await response.Content.ReadAsAsync<IEnumerable<T>>(cancellationToken);
                foreach (var item in result)
                {
                    yield.Return(item);
                }

                shouldFetchNextPage = response.HasNextPage();
                httpRequest = new HttpRequestMessage(HttpMethod.Get, response.NextPageLink());
            });
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest)
        {
            client = ClientFactory();
            string requestContent = httpRequest.Content != null ? await httpRequest.Content.ReadAsStringAsync() : null;
            httpRequest.Headers.Add("Connection", new string[] { "Keep-Alive" });

            HttpResponseMessage response;

            if (retryPolicy != null)
            {
                response = await retryPolicy.ExecuteAsync(async () => await client.SendAsync(httpRequest));
            }
            else
            {
                response = await client.SendAsync(httpRequest);
            }

            if (!response.IsSuccessStatusCode)
            {
                string responseError = response.Content != null ? await response.Content.ReadAsStringAsync() : null;

                string traceId = null;
                IEnumerable<string> traceIdValues = null;
                if (response.Headers.TryGetValues(TraceIdHeader, out traceIdValues) && traceIdValues.Any())
                {
                    traceId = traceIdValues.First();
                }

                throw new EpicomHttpException(httpRequest.RequestUri.ToString(), (int)response.StatusCode, responseError, requestContent, traceId);
            }

            return response;
        }

        protected HttpRequestMessage BuildRequest<T>(IResponse<T> request)
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

        private async Task<T> SendAsync<T>(IResponse<T> request)
        {
            using (var httpRequest = BuildRequest(request))
            {
                var response = await SendAsync(httpRequest);
                T result = await response.Content.ReadAsAsync<T>();
                return result;
            }
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
                    var propertyValueAsString = propertyValue != null ? propertyValue.ToString() : null;
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

        protected virtual HttpClient ClientFactory()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = BaseUri;
                if (Authentication != null)
                {
                    client.DefaultRequestHeaders.Authorization = Authentication;
                }
            }

            return client;
        }
    }
}
