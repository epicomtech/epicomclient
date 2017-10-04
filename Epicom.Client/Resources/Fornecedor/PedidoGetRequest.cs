using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{id}", "GET")]
    public class PedidoGetRequest : IResponse<PedidoGetResponse>
    {
        public long Id { get; set; }
    }
}
