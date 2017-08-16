using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/produtos2?codigo={Codigo}", "GET")]
    public class ProdutoGetRequestQS : IResponse<ProdutoGetResponse>
    {
        public string Codigo { get; set; }
    }
}
