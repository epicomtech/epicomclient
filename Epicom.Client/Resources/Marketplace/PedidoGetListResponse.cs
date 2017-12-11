using System;

namespace Epicom.Client.Resources.Marketplace
{
	public class PedidoGetListResponse
	{
		public long Id { get; set; }

		public string CodigoPedidoMarketplace { get; set; }

		public string CodigoPedidoFornecedor { get; set; }

		public string CodigoFornecedor { get; set; }

		public string Status { get; set; }
	}
}