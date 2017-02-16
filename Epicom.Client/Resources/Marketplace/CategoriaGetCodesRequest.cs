using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/categorias/codes", "GET")]
    public class CategoriaGetCodesRequest : IResponse<IEnumerable<string>>
    {
    }
}
