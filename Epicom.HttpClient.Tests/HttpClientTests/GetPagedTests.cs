using Epicom.Client.Resources.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EasyAsyncEnumerable;
using Epicom.Http.Client.Annotations;

namespace Epicom.Http.Client.Tests.HttpClientTests
{
	public class GetPagedTests : BaseApiTest
	{
		private readonly FakeApiClient sut;
		private FakeGetResponse responsePage1;
		private FakeGetResponse responsePage2;

		public GetPagedTests()
		{
			responsePage1 = new FakeGetResponse();
			responsePage2 = new FakeGetResponse();
			var fakePagedResponseHandler = ArrangeFakePagedResponse();

			sut = new FakeApiClient(new HttpClient(fakePagedResponseHandler)
			{
				BaseAddress = baseUri
			});
		}

		[Fact]
		public void Retorna_Todas_As_Paginas()
		{
			var response = sut.GetPaged(new FakePagedGetRequest { Id = 123, Offset = 0, Limit = 2 });
			var result = new List<FakeGetResponse>();
			response.ForEachAsync(async item =>
			{
				result.Add(await Task.FromResult(item));
			}).Wait();

			Assert.True(result.Contains(responsePage1));
			Assert.True(result.Contains(responsePage2));
		}

		private FakeResponseHandler ArrangeFakePagedResponse()
		{
			var fakePagedResponseHandler = new FakeResponseHandler();

			var firstPageUri = new Uri(baseUri.ToString() + "get/123?offset=0&limit=2");
			var secondPageUri = new Uri(baseUri.ToString() + "get/123?offset=2&limit=2");

			var httpResponse1 = new HttpResponseMessage(HttpStatusCode.OK);
			httpResponse1.Headers.Add("Link", new List<string> { BuildLink(secondPageUri, "next") });
			httpResponse1.Content = new ObjectContent<IList<FakeGetResponse>>(new List<FakeGetResponse> { responsePage1 }, new JsonMediaTypeFormatter());
			fakePagedResponseHandler.AddFakeResponse(firstPageUri, httpResponse1);

			var httpResponse2 = new HttpResponseMessage(HttpStatusCode.OK);
			httpResponse2.Headers.Add("Link", new List<string> { BuildLink(firstPageUri, "previous") });
			httpResponse2.Content = new ObjectContent<IList<FakeGetResponse>>(new List<FakeGetResponse> { responsePage2 }, new JsonMediaTypeFormatter());
			fakePagedResponseHandler.AddFakeResponse(new Uri(baseUri.ToString() + "get/123?offset=2&limit=2"), httpResponse2);

			return fakePagedResponseHandler;
		}

		private static string BuildLink(Uri uri, string name)
		{
			return string.Format("<{0}>; rel={1}", uri, name);
		}

		[Route("/get/{Id}?offset={Offset}&limit={Limit}", "GET")]
		public class FakePagedGetRequest : PagedRequest, IResponse<IEnumerable<FakeGetResponse>>
		{
			public int Id { get; set; }
		}
	}
}
