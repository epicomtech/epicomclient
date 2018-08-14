using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos/{IdPedido}/entregas/{IdEntrega}", "GET")]
    public class PedidoEntregaGetRequest : IResponse<PedidoEntregaGetResponse>
    {
        public long IdPedido { get; set; }
        public int Id { get; set; }
    }
}