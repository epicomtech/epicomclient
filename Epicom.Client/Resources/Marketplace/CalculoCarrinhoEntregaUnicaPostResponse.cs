using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    public class CalculoCarrinhoEntregaUnicaPostResponse
    {
        /// <summary>
        /// "ok" caso item tenha sido calculado com sucesso ou a mensagem de erro caso haja erro
        /// </summary>        
        public string Status { get; set; }

        /// <summary>
        /// Itens para o calculo do carrinho
        /// </summary>
        public List<ItemCalculoCarrinhoEntregaUnica> Itens { get; set; }

        /// <summary>
        /// Fretes disponíveis para o item
        /// </summary>
        public List<ItemFreteCalculoEntregaUnicaCarrinho> Fretes { get; set; }

        /// <summary>
        /// Tipos de Frete disponíveis para um item
        /// </summary>
        public class ItemCalculoCarrinhoEntregaUnica
        {
            /// <summary>
            /// Id do Sku
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Quantidade de itens solicitada
            /// </summary>        
            public int Quantidade { get; set; }

            /// <summary>
            /// Quantidade do sku em estoque
            /// </summary>        
            public int? Estoque { get; set; }

            /// <summary>
            /// Preço do sku
            /// </summary>        
            public decimal? Preco { get; set; }

            /// <summary>
            /// Preço original do sku
            /// </summary>        
            public decimal? PrecoDe { get; set; }
        }

        /// <summary>
        /// Tipos de Frete disponíveis para um item
        /// </summary>
        public class ItemFreteCalculoEntregaUnicaCarrinho
        {
            /// <summary>
            /// A forma de entrega destes itens
            /// </summary>
            public string FormaEntrega { get; set; }

            /// <summary>
            /// A transportadora destes itens
            /// </summary>
            public string Transportadora { get; set; }

            /// <summary>
            /// Previsão de entrega em dias
            /// </summary>        
            public int DiasParaEntrega { get; set; }

            /// <summary>
            /// Valor total dos itens
            /// </summary>        
            public decimal ValorTotal { get; set; }

            /// <summary>
            /// Valor do frete dos itens
            /// </summary>        
            public decimal ValorTotalFrete { get; set; }

            /// <summary>
            /// Valor total dos itens (somando frete e itens)
            /// </summary>
            public decimal ValorTotalPedido { get; set; }

            /// <summary>
            /// Valor total dos impostos
            /// </summary>
            public decimal ValorTotalImpostos { get; set; }
        }
    }
}
