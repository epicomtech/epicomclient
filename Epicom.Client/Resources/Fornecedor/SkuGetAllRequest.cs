using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus", "GET")]
    public class SkuGetAllRequest : IResponse<IEnumerable<SkuGetResponse>>
    {
        public string CodigoProduto { get; set; }
    }
}
