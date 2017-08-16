using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("/fornecedor/disponibilidades?codigoProduto={CodigoProduto}&codigoSku={CodigoSku}&codigoMarketplace={CodigoMarketplace}", "GET")]
    public class DisponibilidadeGetRequestQS : IResponse<DisponibilidadeGetResponse>
    {
        public string CodigoProduto { get; set; }
        public string CodigoSku { get; set; }
        public string CodigoMarketplace { get; set; }
    }
}
