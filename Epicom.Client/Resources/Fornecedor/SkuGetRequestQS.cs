using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/skus2?codigoProduto={CodigoProduto}&codigoSku={Codigo}", "GET")]
    public class SkuGetRequestQS : IResponse<SkuGetResponse>
    {
        public string Codigo { get; set; }
        public string CodigoProduto { get; set; }
    }
}
