using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos/{IdPedido}/entregas/{IdEntrega}/eventos/{IdEvento}", "GET")]
    public class PedidoEntregaEventoGetRequest : IResponse<PedidoEntregaEventoGetResponse>
    {
        public long IdPedido { get; set; }
        public int IdEntrega { get; set; }
        public int IdEvento { get; set; }
    }
}