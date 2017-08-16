using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/skus2?codigoProduto={CodigoProduto}&codigoSku={Codigo}", "DELETE")]
    public class SkuDeleteRequestQS : IEmptyResponse
    {
        public string CodigoProduto { get; set; }
        public string Codigo { get; set; }
    }
}
