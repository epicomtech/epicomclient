using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{IdPedido}/entregas", "GET")]
    public class PedidoEntregaGetRequest : IResponse<IEnumerable<PedidoEntregaGetResponse>>
    {
        public long IdPedido { get; set; }
    }
}
