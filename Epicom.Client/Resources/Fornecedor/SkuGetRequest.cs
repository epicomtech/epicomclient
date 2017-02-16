using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus/{Codigo}", "GET")]
    public class SkuGetRequest : IResponse<SkuGetResponse>
    {
        public string Codigo { get; set; }
        public string CodigoProduto { get; set; }
    }
}
