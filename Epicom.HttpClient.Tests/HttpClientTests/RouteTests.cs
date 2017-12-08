using System;
using Xunit;
using Epicom.Http.Client.Annotations;
namespace Epicom.Http.Client.Tests.HttpClientTests
{
	public class RouteTests
	{	
		public RouteTests()
		{			
		}

		[Fact]
		public void Serializa_Data_Na_Rota()
		{
			
			var testRequet = new DateGetRequest
			{
				Id = 3007,
				Data1 = new DateTime(2017, 11, 1, 16, 29, 33),
				Data2 = new DateTime(2017, 12, 10, 1, 47, 5)
			};
			

			var reqBuilder = new RequestBuilder();
			var req = reqBuilder.BuildRequest(testRequet);			
			Assert.True(req.RequestUri.ToString() == "/get/3007/path?Data1=2017-11-01T16:29:33&Data2=2017-12-10T01:47:05");
		}

		[Fact]
		public void Serializa_Data_Nullable_Na_Rota()
		{

			var testRequet = new DateNullableGetRequest
			{
				Id = 3007,
				Data1 = new DateTime(2017, 11, 1, 16, 29, 33)				
			};


			var reqBuilder = new RequestBuilder();
			var req = reqBuilder.BuildRequest(testRequet);
			var r = req.RequestUri.ToString();
			Assert.True(req.RequestUri.ToString() == "/get/3007/path?Data1=2017-11-01T16:29:33&Data2=");
		}

		[Route("/get/{Id}/path?Data1={Data1}&Data2={Data2}", "GET")]
		public class DateGetRequest : IResponse<FakeGetResponse>
		{
			public int Id { get; set; }
			public DateTime Data1 { get; set; }
			public DateTime Data2 { get; set; }
		}

		[Route("/get/{Id}/path?Data1={Data1}&Data2={Data2}", "GET")]
		public class DateNullableGetRequest : IResponse<FakeGetResponse>
		{
			public int Id { get; set; }
			public DateTime? Data1 { get; set; }
			public DateTime? Data2 { get; set; }
		}

		public class FakeGetResponse
		{

		}
	}
}
