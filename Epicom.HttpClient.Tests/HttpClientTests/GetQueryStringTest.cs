using Epicom.Http.Client.Annotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
    public class GetQueryStringTest : BaseApiTest
    {
        private FakeApiClient sut;
        private FakeGetResponse response;

        public GetQueryStringTest()
        {
            response = new FakeGetResponse();
            var responseHandler = ResponseHandler<FakeGetResponse>("get/123?AnyProp1=any value&AnyProp2=1&AnyProp3=True", HttpStatusCode.OK, response);

            var client = new HttpClient(responseHandler);
            client.BaseAddress = baseUri;

            sut = new FakeApiClient(client);
        }

        [Fact]
        public async Task Retorna_Ok_Se_Request_Possui_Propriedade_Nao_Configurada_Na_Rota()
        {
            // Act
            var result = await sut.GetAsync(new FakeGetRequest
            {
                Id = 123,
                AnyProp1 = "any value",
                AnyProp2 = 1,
                AnyProp3 = true
            });

            // Assert
            Assert.Equal(response, result);
        }

        [Route("/get/{Id}", "GET")]
        public class FakeGetRequest : IResponse<FakeGetResponse>
        {
            public int Id { get; set; }
            public string AnyProp1 { get; set; }
            public int AnyProp2 { get; set; }
            public bool AnyProp3 { get; set; }
        }

        public class ComplexProp
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
