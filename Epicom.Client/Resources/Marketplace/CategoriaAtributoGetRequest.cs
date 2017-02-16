using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/categorias/{CodigoCategoria}/atributos", "GET")]
    public class CategoriaAtributoGetRequest : IResponse<IEnumerable<CategoriaAtributoGetResponse>>
    {
        public string CodigoCategoria { get; set; }
    }
}