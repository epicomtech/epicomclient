using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/produtos/{IdProduto}/skus/{Id}", "GET")]
    public class ProdutoSkuGetRequest : IResponse<SkuGetResponse>
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
    }
}
