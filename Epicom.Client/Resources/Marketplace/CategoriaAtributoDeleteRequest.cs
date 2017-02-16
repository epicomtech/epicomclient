using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/categorias/{CodigoCategoria}/atributos/{CodigoAtributo}", "DELETE")]
    public class CategoriaAtributoDeleteRequest : IEmptyResponse
    {
        public string CodigoCategoria { get; set; }
        public string CodigoAtributo { get; set; }
    }
}