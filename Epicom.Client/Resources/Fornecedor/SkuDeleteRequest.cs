using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus/{Codigo}", "DELETE")]
    public class SkuDeleteRequest : IEmptyResponse
    {
        public string CodigoProduto { get; set; }
        public string Codigo { get; set; }
    }
}
