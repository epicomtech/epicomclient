using System.Collections;
using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos/{IdPedido}/entregas/{IdEntrega}/eventos", "GET")]
    public class PedidoEntregaGetListEventosRequest : IResponse<IEnumerable<PedidoEntregaEventoGetResponse>>
    {
        public long IdPedido { get; set; }
        public int IdEntrega { get; set; }
        public int IdEvento { get; set; }
    }
}