using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/marcas", "GET")]
    public class MarcaGetAllRequest : PagedRequest, IResponse<IEnumerable<MarcaGetResponse>>
    {
    }
}
