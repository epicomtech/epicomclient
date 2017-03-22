using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
	public class PostTests : BaseApiTest
	{
		private FakeApiClient sut;

		[Fact]
		public void Retorna_Null_Para_EmptyResponse()
		{
			//Arrange
			BuildSut(response: null);

			// Act
			var result = sut.PostAsync(new FakeEmptyPostRequest { Id = 123 }).Result;

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void Retorna_Response()
		{
			//Arrange
			BuildSut(response: new FakePostResponse());

			// Act
			var result = sut.PostAsync(new FakePostRequest { Id = 123, Name = "any name" }).Result;

			// Assert
			Assert.IsType<FakePostResponse>(result);
		}

		private void BuildSut(object response)
		{
			var responseHandler = ResponseHandler<object>("post/123", HttpStatusCode.Created, response);

			sut = new FakeApiClient(new HttpClient(responseHandler)
			{
				BaseAddress = baseUri
			});
		}
	}

	[Route("/post/{Id}", "POST")]
	public class FakeEmptyPostRequest : IEmptyResponse
	{
		public int Id { get; set; }
	}

	[Route("/post/{Id}", "POST")]
	public class FakePostRequest : IResponse<FakePostResponse>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class FakePostResponse
	{

	}
}
