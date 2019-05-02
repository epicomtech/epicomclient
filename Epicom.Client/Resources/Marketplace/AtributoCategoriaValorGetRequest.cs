using System.Collections.Generic;
using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/atributos/{Codigo}/valores", "GET")]
    public class AtributoCategoriaValorGetRequest : IResponse<IEnumerable<AtributoCategoriaValorGetResponse>>
    {
        public string Codigo { get; set; }
    }
}
