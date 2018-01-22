using System;
using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using Epicom.Client.Resources.Shared;
using Newtonsoft.Json;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/pedidos", "POST")]
    public class PedidoPostRequest : IResponse<PedidoPostResponse>
    {
        public string CodigoPedido { get; set; }
        public DateTimeOffset DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorJuros { get; set; }
        public List<PedidoPostSku> Itens { get; set; }
        public PedidoDestinatario Destinatario { get; set; }
        public PedidoEndereco Endereco { get; set; }
        public string FormaEntrega { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PrazoEntrega { get; set; }

        public class PedidoPostSku
        {
            public int Id { get; set; }
            public int Quantidade { get; set; }
            public decimal Valor { get; set; }
            public decimal ValorFrete { get; set; }
            public List<string> IdsItensMarketplace { get; set; }
            public string FormaEntrega { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string PrazoEntrega { get; set; }
        }

    }
}
