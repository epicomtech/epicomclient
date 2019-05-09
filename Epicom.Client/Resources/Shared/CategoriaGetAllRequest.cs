using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using Newtonsoft.Json;

namespace Epicom.Client.Resources.Shared
{
    [Route("shared/categorias", "GET")]
    public class CategoriaGetAllRequest : PagedRequest, IResponse<IEnumerable<CategoriaGetResponse>>
    {
    }
}