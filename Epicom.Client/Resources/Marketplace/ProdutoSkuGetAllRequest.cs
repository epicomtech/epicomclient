using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/produtos/{IdProduto}/skus", "GET")]
    public class ProdutoSkuGetAllRequest : IResponse<IEnumerable<SkuGetResponse>>
    {
        public int IdProduto { get; set; }
    }
}
