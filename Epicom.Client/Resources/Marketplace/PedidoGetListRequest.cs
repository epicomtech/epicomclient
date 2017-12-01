using System;
using System.Collections.Generic;
using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos?Criterio={Criterio}&DataInicio={DataInicio}&DataFim={DataFim}&Offset={Offset}&Limit={Limit}", "GET")]
    public class PedidoGetListRequest : PagedRequest, IResponse<IEnumerable<PedidoGetListResponse>>
    {
		public PedidoStatusEnum? Status { get; set; }

		public string CodigoPedidoMarketplace { get; set; }

		public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }
    }
}