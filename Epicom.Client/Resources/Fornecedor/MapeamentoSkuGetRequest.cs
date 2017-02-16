using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/mapeamentos/skus", "GET")]
    public class MapeamentoSkuGetRequest : IResponse<IEnumerable<MapeamentoSkuGetResponse>>
    {
        public string CodigoProduto { get; set; }
        public string CodigoSku { get; set; }
    }
}