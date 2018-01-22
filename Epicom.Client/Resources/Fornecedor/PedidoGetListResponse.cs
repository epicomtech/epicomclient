using Epicom.Client.Resources.Shared;
using System;

namespace Epicom.Client.Resources.Fornecedor
{
    public class PedidoGetListResponse
    {
        
        public long Id { get; set; }

        public string CodigoPedidoMarketplace { get; set; }

		public string CodigoMarketplace { get; set; }

		public string CodigoPedidoFornecedor { get; set; }

		public PedidoStatusEnum Status { get; set; }

	}
}