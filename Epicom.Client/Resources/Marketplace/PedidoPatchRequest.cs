using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using Newtonsoft.Json;
using System;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos/{Id}", "PATCH")]
    public class PedidoPatchRequest : IEmptyResponse
    {
        public long Id { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// Endereço de entrega do pedido
        /// </summary>
        public PedidoEndereco Endereco { get; set; }

        public PedidoDestinatario Destinatario { get; set; }

        public string FormaEntrega { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PrazoEntrega { get; set; }

        public string CpfCnpj { get; set; }

        public DateTime? DataCancelamentoPedido { get; set; }
    }
}
