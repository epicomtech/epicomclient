using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/skus2?codigoProduto={CodigoProduto}", "GET")]
    public class SkuGetAllRequestOS : IResponse<IEnumerable<SkuGetResponse>>
    {
        public string CodigoProduto { get; set; }
    }
}
