using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/atributos/{CodigoAtributoCategoria}/valores", "POST")]
    public class AtributoCategoriaValorPostRequest : IEmptyResponse
    {
        public string CodigoAtributoCategoria { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }                        
    }
}
