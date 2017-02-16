using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/calculocarrinho?entregaUnica={EntregaUnica}", "POST")]
    public class CalculoCarrinhoEntregaUnicaPostRequest : IResponse<List<CalculoCarrinhoEntregaUnicaPostResponse>>
    {
        public CalculoCarrinhoEntregaUnicaPostRequest()
        {
            Itens = new List<ItemCalculoCarrinho>();
        }

        public List<ItemCalculoCarrinho> Itens { get; set; }

        public string Cep { get; set; }

        public class ItemCalculoCarrinho
        {
            public int Id { get; set; }

            public int Quantidade { get; set; }
        }

        public bool EntregaUnica { get; set; }
    }
}
