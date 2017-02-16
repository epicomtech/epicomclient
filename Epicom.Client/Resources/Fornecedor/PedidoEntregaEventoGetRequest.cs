using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{CodigoPedido}/entregas/{CodigoEntrega}/eventos", "GET")]
    public class PedidoEntregaEventoGetRequest : IResponse<IEnumerable<PedidoEntregaEventoGetResponse>>
    {
        public string CodigoPedido { get; set; }
        public string CodigoEntrega { get; set; }
    }
}
