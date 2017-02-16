using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/mapeamentos/atributos/{CodigoMarketplace}", "PUT")]
    public class CategoriaAtributoMapeamentoPutRequest : IEmptyResponse
    {
        public string CodigoMarketplace { get; set; }
        public string CodigoAtributo { get; set; }
        public IEnumerable<MapeamentoPutRequest> Mapeamentos { get; set; }
        public IEnumerable<CategoriaAtributoValorPutRequest> Valores { get; set; }

        public class CategoriaAtributoValorPutRequest
        {
            public string Codigo { get; set; }
            public IEnumerable<MapeamentoPutRequest> Mapeamentos { get; set; }
        }

        public class MapeamentoPutRequest
        {
            public string Nome { get; set; }
        }
    }
}
