using System.Net;
using System.Net.Http;
using Epicom.Http.Client.Annotations;
using Xunit;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
    public class PutTests : BaseApiTest
    {
        private FakeApiClient sut;

        [Fact]
        public void Retorna_Null_Para_EmptyResponse()
        {
            //Arrange
            BuildSut(response: null);

            // Act
            var result = sut.PutAsync(new FakeEmptyPutRequest { Id = 123 }).Result;

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Retorna_Response()
        {
            //Arrange
            BuildSut(response: new FakePostResponse());
            var fakePutRequest = new FakePutRequest { Id = 123 };

            // Act
            var result = sut.PutAsync(fakePutRequest).Result;
            var requestContent = ToJson(fakePutRequest);

            // Assert
            Assert.IsType<FakePutResponse>(result);
            Assert.Contains("123", requestContent);
        }

        [Fact]
        public void Retorna_Response_ChecksIgnoredField()
        {
            //Arrange
            BuildSut(response: new FakePostResponse());
            var fakePutWithJsonIgnoreRequest = new FakePutWithJsonIgnoreRequest { Id = 123, Code = "Blah" };

            // Act
            var result = sut.PutAsync(fakePutWithJsonIgnoreRequest).Result;
            var requestContent = ToJson(fakePutWithJsonIgnoreRequest);

            // Assert
            Assert.IsType<FakePutResponse>(result);
            Assert.DoesNotContain("123", requestContent);

        }

        private static string ToJson<T>(T request)
        {
            using (var writer = new System.IO.StringWriter())
            {
                new JsonMediaTypeFormatter().CreateJsonSerializer().Serialize(writer, request);
                return writer.ToString();
            }
        }

        private void BuildSut(object response)
        {
            var responseHandler = ResponseHandler("put/123", HttpStatusCode.OK, response);
            var client = new HttpClient(responseHandler) { BaseAddress = baseUri };
            sut = new FakeApiClient(client);
        }
    }

    [Route("/put/{Id}", "PUT")]
    public class FakeEmptyPutRequest : IEmptyResponse
    {
        public int Id { get; set; }
    }

    [Route("/put/{Id}", "PUT")]
    public class FakePutRequest : IResponse<FakePutResponse>
    {
        public int Id { get; set; }
    }

    [Route("/put/{Id}", "PUT")]
    public class FakePutWithJsonIgnoreRequest : IResponse<FakePutResponse>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Code { get; set; }
    }

    public class FakePutResponse
    {
    }
}