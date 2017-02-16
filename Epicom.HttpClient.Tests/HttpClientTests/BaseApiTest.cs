using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
    public abstract class BaseApiTest
    {
        protected readonly Uri baseUri;

        protected BaseApiTest()
        {
            baseUri = new Uri("http://faketest.epicom.com.br/");
        }

        public FakeResponseHandler ResponseHandler<T>(string path, HttpStatusCode status, T content) 
        {
            var response = new HttpResponseMessage(status);
            response.Content = new ObjectContent<T>(content, new JsonMediaTypeFormatter());

            var fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri(baseUri.ToString() + path), response);

            return fakeResponseHandler;
        }
    }
}
