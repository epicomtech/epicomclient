using System;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus/{CodigoSku}/disponibilidades", "POST")]
    public class DisponibilidadePostRequest : IEmptyResponse
    {
        public string CodigoProduto { get; set; }
        public string CodigoSku { get; set; }
        public decimal Preco { get; set; }
        public decimal? PrecoDe { get; set; }
        public bool? Disponivel { get; set; }
        public string CodigoMarketplace { get; set; }
    }
}
