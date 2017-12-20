using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{IdPedido}/entregas/{IdEntrega}/eventos", "POST")]
    public class PedidoEntregaEventoPostRequest : IEmptyResponse
    {
        public string IdPedido { get; set; }
        public string IdEntrega { get; set; }

        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
