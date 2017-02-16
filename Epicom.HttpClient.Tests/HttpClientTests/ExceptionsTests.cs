using Epicom.Http.Client.Exceptions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
    public class ExceptionsTests : BaseApiTest
    {
        private readonly FakeApiClient sut;
        private readonly FakeGetResponse response;

        public ExceptionsTests()
        {
            response = new FakeGetResponse();
            var responseHandler = ResponseHandler("post/123", HttpStatusCode.InternalServerError, response);
            var client = new HttpClient(responseHandler) { BaseAddress = baseUri };
            sut = new FakeApiClient(client);
        }

        [Fact]
        public void Retorna_Excecao()
        {
            var request = new FakePostRequest { Id = 123 };

            var exception = Assert.ThrowsAsync<EpicomHttpException>(() => sut.PostAsync(request)).Result;
            Assert.Equal("http://faketest.epicom.com.br/post/123", exception.Url);
            Assert.Equal(500, exception.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(response), exception.Response);
            Assert.Equal(JsonConvert.SerializeObject(request), exception.Request);
        }
    }
}
