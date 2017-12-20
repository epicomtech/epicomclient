using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{IdPedido}/entregas/{IdEntrega}/eventos", "GET")]
    public class PedidoEntregaEventoGetRequest : IResponse<IEnumerable<PedidoEntregaEventoGetResponse>>
    {
        public long IdPedido { get; set; }
        public long IdEntrega { get; set; }
    }
}
