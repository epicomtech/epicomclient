using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos/{IdPedido}/entregas", "GET")]
    public class PedidoEntregaGetListRequest : IResponse<IEnumerable<PedidoEntregaGetResponse>>
    {
        public long IdPedido { get; set; }        
    }
}