using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus/{CodigoSku}/disponibilidades/{CodigoMarketplace}", "GET")]
    public class DisponibilidadeGetRequest : IResponse<DisponibilidadeGetResponse>
    {
        public string CodigoProduto { get; set; }
        public string CodigoSku { get; set; }
        public string CodigoMarketplace { get; set; }
    }
}
