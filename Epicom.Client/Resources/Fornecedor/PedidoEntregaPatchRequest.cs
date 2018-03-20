using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{IdPedido}/entregas/{Id}", "PATCH")]
    public class PedidoEntregaPatchRequest : IEmptyResponse
    {
        public int Id { get; set; }
        public long IdPedido { get; set; }
        public string Codigo { get; set; }
        public string Tracking { get; set; }

        public string PrevisaoEntrega { get; set; }
        public DateTime? DataEntrega { get; set; }

        public string NfSerie { get; set; }
        public string NfNumero { get; set; }
        public DateTime? NfDataEmissao { get; set; }
        public string NfChaveAcesso { get; set; }
		public string NfCFOP { get; set; }
		public string NfLink { get; set; }

        public string NomeTransportadora { get; set; }
        public string LinkRastreioEntrega { get; set; }
    }
}
