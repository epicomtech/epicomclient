using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
	[Route("marketplace/arquivos", "POST")]
	public class ArquivoPostRequest : IResponse<List<ArquivoPostResponse>>
	{		
		public string SellerCode { get; set; }
		public string Url { get; set; }
	}
}
