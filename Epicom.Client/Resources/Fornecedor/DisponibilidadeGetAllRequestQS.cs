using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("/fornecedor/disponibilidades2?codigoProduto={CodigoProduto}&codigoSku={CodigoSku}", "GET")]
    public class DisponibilidadeGetAllRequestQS : IResponse<IEnumerable<DisponibilidadeGetResponse>>
    {
        public string CodigoProduto { get; set; }
        public string CodigoSku { get; set; }
    }
}
