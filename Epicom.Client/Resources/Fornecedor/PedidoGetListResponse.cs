using Epicom.Client.Resources.Shared;
using System;

namespace Epicom.Client.Resources.Fornecedor
{
    public class PedidoGetListResponse
    {
        
        /// <summary>
        /// Código do Pedido na Epicom
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Código do Pedido no Marketplace
        /// </summary>
        public string CodigoPedidoMarketplace { get; set; }

        /// <summary>
        /// Código do Pedido no Fornecedor
        /// </summary>
        public string CodigoPedidoFornecedor { get; set; }


		public PedidoStatusEnum Status { get; set; }

	}
}