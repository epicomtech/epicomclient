using System;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    public class PedidoEntregaGetResponse
    {
        public string Codigo { get; set; }
        public string PrevisaoEntrega { get; set; }
        public DateTime? DataEntrega { get; set; }
        public IEnumerable<Sku> Skus { get; set; }
        public string Tracking { get; set; }

        public string NomeTransportadora { get; set; }
        public string LinkRastreioEntrega { get; set; }

        public class Sku
        {
            public string Codigo { get; set; }
        }

        public string NfNumero { get; set; }
        public DateTime? NfDataEmissao { get; set; }
        public string NfChaveAcesso { get; set; }
        public string NfLink { get; set; }
    }
}
