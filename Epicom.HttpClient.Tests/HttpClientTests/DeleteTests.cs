using Epicom.Http.Client.Annotations;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
    public class DeleteTests : BaseApiTest
    {
        [Fact]
        public void Retorna_Null_Para_EmptyResponse()
        {
            //Arrange
            BuildSut(response: null);

            // Act
            var result = sut.DeleteAsync(new FakeEmptyDeleteRequest { Id = 123 }).Result;

            // Assert
            Assert.Null(result);
        }

        private FakeApiClient sut;

        private void BuildSut(object response)
        {
            var responseHandler = ResponseHandler("delete/123", HttpStatusCode.OK, response);
            var client = new HttpClient(responseHandler) { BaseAddress = baseUri };
            sut = new FakeApiClient(client);
        }
    }

    [Route("/delete/{Id}", "DELETE")]
    public class FakeEmptyDeleteRequest : IEmptyResponse
    {
        public int Id { get; set; }
    }
}
