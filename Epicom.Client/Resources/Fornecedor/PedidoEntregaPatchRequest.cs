using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/pedidos/{CodigoPedido}/entregas/{Codigo}", "PATCH")]
    public class PedidoEntregaPatchRequest : IEmptyResponse
    {
        public string CodigoPedido { get; set; }
        public string Codigo { get; set; }
        public string Tracking { get; set; }

        public string PrevisaoEntrega { get; set; }
        public DateTime? DataEntrega { get; set; }

        public string NfNumero { get; set; }
        public DateTime? NfDataEmissao { get; set; }
        public string NfChaveAcesso { get; set; }
        public string NfLink { get; set; }

        public string NomeTransportadora { get; set; }
        public string LinkRastreioEntrega { get; set; }
    }
}
