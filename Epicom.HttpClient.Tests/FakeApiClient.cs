using System;
using System.Net.Http;

namespace Epicom.Http.Client.Tests
{
    public class FakeApiClient : EpicomHttpClient
    {
        public FakeApiClient()
        {
        }

        public FakeApiClient(HttpClient client)
            : base(client)
        {
        }

        public override Uri BaseUri
        {
            get { return null; }
        }

        protected override HttpClient ClientFactory()
        {
            return client;
        }
    }
}
