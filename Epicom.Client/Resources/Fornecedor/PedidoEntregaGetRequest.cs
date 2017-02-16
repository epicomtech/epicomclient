using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{CodigoPedido}/entregas", "GET")]
    public class PedidoEntregaGetRequest : IResponse<IEnumerable<PedidoEntregaGetResponse>>
    {
        public string CodigoPedido { get; set; }
    }
}
