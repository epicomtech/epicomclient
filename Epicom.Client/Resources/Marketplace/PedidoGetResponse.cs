using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    public class PedidoGetResponse
    {        
		public long Id { get; set; }

		public DateTime DataAbertura { get; set; }

		public decimal ValorTotal { get; set; }

		public List<Sku> Itens { get; set; }

		public PedidoDestinatario Destinatario { get; set; }

		public string CodigoPedidoMarketplace { get; set; }

		public PedidoEndereco Endereco { get; set; }

		public string Status { get; set; }

		public class Sku
		{
			public int Id { get; set; }
			public int Quantidade { get; set; }
			public decimal Valor { get; set; }
			public decimal ValorFrete { get; set; }
			public string CodigoFornecedor { get; set; }
			public string NomeFornecedor { get; set; }
			public string CodigoPedidoFornecedor { get; set; }
			public List<string> IdsItensMarketplace { get; set; }

			public string FormaEntrega { get; set; }

			public string PrazoEntrega { get; set; }
		}
	}
}