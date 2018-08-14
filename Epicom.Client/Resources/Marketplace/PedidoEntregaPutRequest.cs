using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos/{IdPedido}/entregas", "PUT")]
    public class PedidoEntregaPutRequest : IEmptyResponse
    {
        public long IdPedido { get; set; }
        public string Codigo { get; set; }
        public string Tracking { get; set; }
        public string NomeTransportadora { get; set; }
        public string LinkRastreioEntrega { get; set; }
		public string LinkEtiqueta { get; set; }
		public IList<PedidoEntregaMarketplaceItem> Itens { get; set; }
    }

    public class PedidoEntregaMarketplaceItem 
    {
        public int Id { get; set; }
    }
}
