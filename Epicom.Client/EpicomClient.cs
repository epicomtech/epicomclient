using Epicom.Http.Client;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Epicom.Client
{
    public class EpicomClient : EpicomHttpClient
    {
        private readonly string apiKey;
        private readonly string apiToken;

        public EpicomClient()
            : base()
        {
        }

        public EpicomClient(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public EpicomClient(string apiKey, string apiToken, RetryPolicyConfig retryPolicy = null)
            : base(retryPolicy)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException("apiKey");
            }

            if (string.IsNullOrWhiteSpace(apiToken))
            {
                throw new ArgumentNullException("apiToken");
            }

            this.apiKey = apiKey;
            this.apiToken = apiToken;
        }

        protected override AuthenticationHeaderValue Authentication
        {
            get
            {
                string key = apiKey ?? ConfigurationManager.AppSettings["Epicom.Api.Key"];
                if (key == null)
                {
                    throw new Exception("Epicom.Api.Key ausente no arquivo de configuração");
                }

                string token = apiToken ?? ConfigurationManager.AppSettings["Epicom.Api.Token"];
                if (token == null)
                {
                    throw new Exception("Epicom.Api.Token ausente no arquivo de configuração");
                }

                string tokenFormat = string.Format("{0}:{1}", key, token);
                string token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(tokenFormat));
                return new AuthenticationHeaderValue("Basic", token64);
            }
        }

        public override Uri BaseUri
        {
            get
            {
                var baseUri = ConfigurationManager.AppSettings["Epicom.Api.BaseUri"];
                if (baseUri == null)
                {
                    throw new Exception("Epicom.Api.BaseUri ausente no arquivo de configuração");
                }

                return new Uri(baseUri);
            }
        }
    }
}
