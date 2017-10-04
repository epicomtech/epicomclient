using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{CodigoPedido}", "GET")]
    public class PedidoGetRequest : IResponse<PedidoGetResponse>
    {
		public string CodigoPedido { get; set; }
	}
}
