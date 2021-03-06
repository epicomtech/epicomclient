﻿using Epicom.Client.Resources.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    public class PedidoGetResponse
    {
        public long Id { get; set; }

        public string CodigoPedidoMarketplace { get; set; }

		public string CodigoPedidoFornecedor { get; set; }

		public DateTime DataAbertura { get; set; }
        
        public List<Sku> Itens { get; set; }

        public PedidoDestinatario Destinatario { get; set; }

        public PedidoEndereco Endereco { get; set; }

        public string Status { get; set; }
        public string Erro { get; set; }

        public string FormaEntrega { get; set; }

        public decimal? ValorComissaoMarketplace { get; set; }
        public decimal? CustoFreteFornecedor { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PrazoEntrega { get; set; }
        public string CodigoMarketplace { get; set; }

        public class Sku
        {
            public string Codigo { get; set; }
            public int Quantidade { get; set; }
            public decimal Valor { get; set; }
            public decimal ValorFrete { get; set; }
            public string FormaEntrega { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string PrazoEntrega { get; set; }
        }
    }
}
