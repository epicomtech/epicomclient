using Epicom.Http.Client.Annotations;
using Epicom.Http.Client.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
    public class GetTests : BaseApiTest
    {
        private FakeApiClient sut;
        private FakeGetResponse response; 

        public GetTests()
        {
            response = new FakeGetResponse();
            var responseHandler = ResponseHandler<FakeGetResponse>("get/123", HttpStatusCode.OK, response);

            var client = new HttpClient(responseHandler);
            client.BaseAddress = baseUri;

            sut = new FakeApiClient(client);
        }

        [Fact]
        public void Retorna_Ok() 
        {
            // Act
            var result = sut.GetAsync(new FakeGetRequest { Id = 123 }).Result;

            // Assert
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task Dispara_Excecao_Se_Request_Nao_Possui_Rota() 
        {            
            // Act
            Exception exception = await Assert.ThrowsAsync<Exception>(async () => await sut.GetAsync(new InvalidRouteGetRequest { Id = 123 }));

            //Assert
            Assert.Equal("Atributo Route não definido no objeto de request", exception.Message);
        }

        [Fact]
        public async Task Dispara_Excecao_Se_Rota_Possui_Parametro_Vazio()
        {
            // Act
            Exception exception = await Assert.ThrowsAsync<Exception>(async () => await sut.GetAsync(new EmptyParamGetRequest { Id1 = 123 }));

            //Assert
            Assert.Equal("Parâmetro vazio na rota da classe EmptyParamGetRequest: {}", exception.Message);
        }

        [Fact]
        public async Task Dispara_Excecao_Com_Status_404_Para_Request_Invalido()
        {
            // Act
            EpicomHttpException exception = await Assert.ThrowsAsync<EpicomHttpException>(async () => await sut.GetAsync(new FakeGetRequest { Id = 456 }));

            //Assert
            Assert.Equal(404, exception.StatusCode);
        }
    }

    [Route("/get/{Id}", "GET")]
    public class FakeGetRequest : IResponse<FakeGetResponse>
    {
        public int Id { get; set; }
    }

    public class InvalidRouteGetRequest : IResponse<FakeGetResponse>
    {
        public int Id { get; set; }
    }

    [Route("/get/{Id}/path/{parametro1}/path/{parametro2}", "GET")]
    public class ParamRouteGetRequest : IResponse<FakeGetResponse>
    {
        public int Id { get; set; }
    }

    [Route("/get/{Id1}/path/{}", "GET")]
    public class EmptyParamGetRequest : IResponse<FakeGetResponse>
    {
        public int Id1 { get; set; }
    }

    public class FakeGetResponse 
    { 

    }
}
