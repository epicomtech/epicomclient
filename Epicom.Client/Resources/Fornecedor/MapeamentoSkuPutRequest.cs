using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/mapeamentos/skus", "PUT")]
    public class MapeamentoSkuPutRequest : IEmptyResponse
    {
        [Required]
        public string CodigoProduto { get; set; }

        [Required]
        public string CodigoSku { get; set; }

        [Required]
        public string CodigoMarketplace { get; set; }

        public string CodigoCategoria { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}