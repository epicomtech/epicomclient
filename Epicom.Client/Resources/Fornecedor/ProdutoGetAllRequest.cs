using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos", "GET")]
    public class ProdutoGetAllRequest : PagedRequest, IResponse<IEnumerable<ProdutoGetResponse>>
    {
    }
}
