using Epicom.Client.Resources.Shared;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/categorias", "GET")]
    public class CategoriaGetAllRequest : PagedRequest, IResponse<IEnumerable<CategoriaGetResponse>>
    {
        public string Nome { get; set; }
        public string CodigoParceiro { get; set; }
    }
}
