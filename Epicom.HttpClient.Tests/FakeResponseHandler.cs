using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Epicom.Http.Client.Tests
{
    public class FakeResponseHandler : DelegatingHandler
    {
        private readonly Dictionary<Uri, HttpResponseMessage> _FakeResponses = new Dictionary<Uri, HttpResponseMessage>();

        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            _FakeResponses.Add(uri, responseMessage);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (_FakeResponses.ContainsKey(request.RequestUri))
            {
                return await Task.FromResult(_FakeResponses[request.RequestUri]);
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request };
        }
    }
}
