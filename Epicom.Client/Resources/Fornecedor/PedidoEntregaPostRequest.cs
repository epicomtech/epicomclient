﻿using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{IdPedido}/entregas", "POST")]
    public class PedidoEntregaPostRequest : IResponse<PedidoEntregaPostResponse>
	{
        public long IdPedido { get; set; }

        public string Codigo { get; set; }
        public string PrevisaoEntrega { get; set; }
        public DateTime? DataEntrega { get; set; }
        public IEnumerable<Sku> Skus { get; set; }
        public string Tracking { get; set; }

        public class Sku
        {
            public string Codigo { get; set; }
        }

        public string NfSerie { get; set; }
        public string NfNumero { get; set; }
        public DateTime? NfDataEmissao { get; set; }
        public string NfChaveAcesso { get; set; }
        public string NfLink { get; set; }
		public string NfCFOP { get; set; }

		public string NomeTransportadora { get; set; }
        public string LinkRastreioEntrega { get; set; }
    }
}
