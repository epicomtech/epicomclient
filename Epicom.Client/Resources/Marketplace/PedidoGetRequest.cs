using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
	[Route("marketplace/pedidos/{Id}", "GET")]
	public class PedidoGetRequest : IResponse<PedidoGetResponse>
	{
		public long Id { get; set; }
	}
}