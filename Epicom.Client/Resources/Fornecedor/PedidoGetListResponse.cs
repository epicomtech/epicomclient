using System;

namespace Epicom.Client.Resources.Fornecedor
{
    public class PedidoGetListResponse
    {
        /// <summary>
        /// Data do pedido
        /// </summary>
        public DateTimeOffset Data { get; set; }

        /// <summary>
        /// Código do pedido do parceiro
        /// </summary>
        public string CodigoPedidoParceiro { get; set; }

        /// <summary>
        /// Código do Pedido na Epicom
        /// </summary>
        public long CodigoPedidoEpicom { get; set; }

        /// <summary>
        /// Código do Pedido no Marketplace
        /// </summary>
        public string CodigoPedidoMarketplace { get; set; }

        /// <summary>
        /// Código do Pedido no Fornecedor
        /// </summary>
        public string CodigoPedidoFornecedor { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string NomeCliente { get; set; }

        /// <summary>
        /// Valor total do pedido
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Situação do pedido
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Nome do fornecedor
        /// </summary>
        public string NomeMarketplace { get; set; }

        /// <summary>
        /// Itens do pedido
        /// </summary>
        public int QuantidadeItens { get; set; }

        /// <summary>
        /// Telefone do cliente
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// CPF / CNPJ do cliente
        /// </summary>
        public string CpfCnpj { get; set; }
    }
}