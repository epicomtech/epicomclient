using System;
using System.Collections.Generic;
using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos?Status={Status}&DataInicio={DataInicio}&DataFim={DataFim}&Offset={Offset}&Limit={Limit}&CodigoPedidoFornecedor={CodigoPedidoFornecedor}", "GET")]
    public class PedidoGetListRequest : PagedRequest, IResponse<IEnumerable<PedidoGetListResponse>>
    {
		/// <summary>
		/// Critério de pesquisa
		/// </summary>
		public PedidoStatusEnum? Status { get; set; }

		public string CodigoPedidoFornecedor { get; set; }

		public DateTime? DataInicio { get; set; }

		public DateTime? DataFim { get; set; }
		
    }
}