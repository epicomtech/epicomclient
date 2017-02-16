using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos/{CodigoProduto}/skus/{CodigoSku}/disponibilidades", "GET")]
    public class DisponibilidadeGetAllRequest : IResponse<IEnumerable<DisponibilidadeGetResponse>>
    {
        public string CodigoProduto { get; set; }
        public string CodigoSku { get; set; }
    }
}
