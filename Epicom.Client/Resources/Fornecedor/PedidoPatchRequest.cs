using Epicom.Http.Client.Annotations;
using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{CodigoPedido}", "PATCH")]
    public class PedidoPatchRequest : IEmptyResponse
    {
        public string CodigoPedido { get; set; }
        public PedidoStatusEnum Status { get; set; }
    }
}
