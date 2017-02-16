using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{codigoProduto}/skus", "GET")]
    public class SkuGetPorProdutoRequest : IResponse<IEnumerable<SkuGetResponse>>
    {
        public string codigoProduto { get; set; }
    }
}
